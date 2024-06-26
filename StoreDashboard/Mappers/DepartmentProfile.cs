using AutoMapper;
using Pioneers.DAL.Entities;
using StoreDashboard.Models;

namespace PioneersStore.Mappers
{
    public class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DepartmentViewModel,Department>().ReverseMap();
        }
    }
}
