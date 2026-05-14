using AutoMapper;
using Common;
using EMS.CORE.Entities.MD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BUSINESS.Dtos.MD
{
    public class StoreDto : BaseMdDto, IMapFrom, IDto
    {

        [Key]
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? Area { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TblMdStore, StoreDto>().ReverseMap();
        }
    }
}
