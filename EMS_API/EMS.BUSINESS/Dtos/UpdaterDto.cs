using AutoMapper;
using Common;
using EMS.CORE.Entities.AD;

namespace EMS.BUSINESS.Dtos.Common
{
    public class UpdaterDto : IMapFrom, IDto
    {
        public string FullName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TblAdAccount, UpdaterDto>().ReverseMap();
        }
    }
}
