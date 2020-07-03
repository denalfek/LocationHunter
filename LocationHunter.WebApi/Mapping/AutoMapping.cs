using AutoMapper;
using LocationHunter.Core.Entities;
using LocationHunter.WebApi.IpStackModels;

namespace LocationHunter.WebApi.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<IpStackResponseModel, Location>();
        }
    }
}
