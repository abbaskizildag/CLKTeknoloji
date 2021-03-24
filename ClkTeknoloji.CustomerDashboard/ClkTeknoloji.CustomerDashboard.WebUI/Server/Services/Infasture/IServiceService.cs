using ClkTeknoloji.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClkTeknoloji.CustomerDashboard.WebUI.Server.Services.Infasture
{
    public interface IServiceService
    {
        public Task<List<ServiceDto>> GetAllService();

    }
}
