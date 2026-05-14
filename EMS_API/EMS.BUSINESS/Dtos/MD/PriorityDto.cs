using AutoMapper;
using Common;
using EMS.CORE.Entities.MD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BUSINESS.Dtos.MD
{
    public class PriorityDto : BaseDto, IDto, IMapFrom
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<TblMdPriority, PriorityDto>().ReverseMap();
        }
    }
}
