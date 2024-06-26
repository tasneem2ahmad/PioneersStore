using AutoMapper;
using Pioneers.DAL.Entities;
using StoreDashboard.Models;

namespace StoreDashboard.Mappers
{
    public class FeatureProfile:Profile
    {
        public FeatureProfile()
        {
           CreateMap<FeatureViewModel,Feature>().ReverseMap();
        }
    }
}
