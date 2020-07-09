using AutoMapper;
using LocationHunter.Core.Entities;
using LocationHunter.Core.IpStackModels;

namespace LocationHunter.Core.Mapping
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<IpStackResponseModel, Location>();
        }
    }
}
