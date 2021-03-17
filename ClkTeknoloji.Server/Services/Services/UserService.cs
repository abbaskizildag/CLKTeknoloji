using AutoMapper;
using AutoMapper.QueryableExtensions;
using ClkTeknoloji.Server.Data.Context;
using ClkTeknoloji.Server.Data.Models;
using ClkTeknoloji.Server.Services.Infasture;
using ClkTeknoloji.Shared.DTOs;
using ClkTeknoloji.Shared.Utilis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ClkTeknoloji.Server.Services.Services
{
    public class UserService : IUserService
    {

        private readonly AppDbContext context;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;

        public UserService(AppDbContext Context, IMapper Mapper, IConfiguration Configuration)
        {

            context = Context;
            mapper = Mapper;
            configuration = Configuration;
        }
        public async Task<UserDto> CreateUser(UserDto User)
        {
            var dbUser = await context.Users.Where(i => i.Id == User.Id).FirstOrDefaultAsync();
            if (dbUser != null)
            {
                throw new Exception("İlgili kayıt zaten mevcut");
            }
            User.Password = PasswordEncrypter.Encrypt(User.Password);
            dbUser = mapper.Map<User>(User);
            await context.Users.AddAsync(dbUser);
            await context.SaveChangesAsync();
            return mapper.Map<UserDto>(dbUser);
        }

        public async Task<bool> DeleteUserById(int Id)
        {
            var dbUser = await context.Users.FirstOrDefaultAsync(i => i.Id == Id);
            if (dbUser == null)
            {
                throw new Exception("Kullanıcı bulunanamadı");
            }
            context.Users.Remove(dbUser);
            int result = await context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<List<UserDto>> GetUser()
        {
            var users= await context.Users.Include(x=>x.Products).ToListAsync();
            return mapper.Map<List<UserDto>>(users);
        }

        public async Task<UserDto> GetUserById(int Id)
        {
            var user= await context.Users.Where(i => i.Id == Id).FirstOrDefaultAsync();
            return mapper.Map<UserDto>(user);
        }

        public async Task<UserLoginResponse> Login(UserLoginRequest userLoginRequest)
        {
            //veritabanı kullanıcı doğrulama işlemleri yapıldı.
            var encryptedPassword = PasswordEncrypter.Encrypt(userLoginRequest.Password);
            var dbUser = context.Users.Where(u => u.EMailAddress == userLoginRequest.EMail && u.Password == encryptedPassword).FirstOrDefault();
            if (dbUser == null) throw new Exception("Kullanıcı bulunamadı veya bilgiler yanlış");

            if (!dbUser.IsActive) throw new Exception("Kullanıcı Pasif Durumdadır");

            UserLoginResponse result = new UserLoginResponse();
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(int.Parse(configuration["JwtExpiryInDays"].ToString()));

            var claims = new[] //claim içinde email bilgisi barınsın dedik sdece.
            {
                    new Claim(ClaimTypes.Email,userLoginRequest.EMail),
                    new Claim(ClaimTypes.Name, dbUser.FirstName + " "+dbUser.LastName),
                    new Claim(ClaimTypes.UserData, dbUser.Id.ToString())
                };

            var token = new JwtSecurityToken(configuration["JwtIssuer"], configuration["JwtAudience"], claims, null, expiry, creds);
            result.ApiToken = new JwtSecurityTokenHandler().WriteToken(token); //burada token'ı görünen şekilde uzun stringe dönüştürüyor
            result.User = mapper.Map<UserDto>(dbUser);
            return result;
        }

        public async Task<UserDto> UpdateUser(UserDto User)
        {
            var dbUser = await context.Users.Where(i => i.Id == User.Id).FirstOrDefaultAsync();
            if (dbUser == null)
            {
                throw new Exception("İlgili kayıt bulunamadı");
            }
            //burada map ile kullanırsak veri tabanından gelen kayıt değilde yeni bir instanse oluşturuyor
            //normalde update akıllı bir şekilde değişkenle değişmeyeni ayırt ediyor. alttaki mappleme kodu ise yorum yatırı olan direk yeni instıns oluşturur.
            // dbUser = mapper.Map<Data.Models.Users>(User);
            mapper.Map(User, dbUser);// burada sadece farklı olanları alıyor. yukaırıdaki kodu iptal ettik.
            context.Users.Update(dbUser);
            await context.SaveChangesAsync();
            return mapper.Map<UserDto>(dbUser);
        }
    }
}
