using AutoMapper;
using Pioneers.DAL.Entities;
using StoreDashboard.Models;

namespace StoreDashboard.Mappers
{
    public class MarketProfile:Profile
    {
        public MarketProfile()
        {
            CreateMap<MarketViewModel,Market>().ReverseMap();
        }
    }
}
