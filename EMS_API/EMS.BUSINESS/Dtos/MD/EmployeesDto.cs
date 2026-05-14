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
    public class EmployeesDto : BaseMdEDto, IMapFrom, IDto
    {
        public string? Code { get; set; }

        public string? FullName { get; set; }

        public string? Position { get; set; }

        public string? PhoneNumber { get; set; }

        public string? DigitalSig { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TblMdEmployees, EmployeesDto>().ReverseMap();
        }

    }
}
