using AutoMapper;
using Pioneers.DAL.Entities;
using StoreDashboard.Models;

namespace StoreDashboard.Mappers
{
    public class ChildDepartmentProfile:Profile
    {
        public ChildDepartmentProfile()
        {
            CreateMap<ChildDepartment,ChildDepartmentViewModel>().ReverseMap();
        }
    }
}
