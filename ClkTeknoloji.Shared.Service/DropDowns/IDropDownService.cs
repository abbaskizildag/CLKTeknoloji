using ClkTeknoloji.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClkTeknoloji.Shared.Service.DropDowns
{
    public interface IDropDownService
    {
        public Task<List<ServiceDto>> GetAllService();

    }
}
