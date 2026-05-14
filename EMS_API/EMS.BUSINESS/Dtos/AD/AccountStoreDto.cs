using AutoMapper;
using Common;
using EMS.CORE.Entities.AD;
using Microsoft.AspNetCore.Routing.Constraints;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.BUSINESS.Dtos.AD
{
    public class AccountStoreDto : BaseMdDto, IMapFrom, IDto
    {
        public string UserName { get; set; }
        public string? StoreCode { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AccountStoreDto, TblAdAccountStore>().ReverseMap();

        }
    }

    public class createAccountStoreDto : BaseMdDto, IMapFrom, IDto
    {
        public string UserName { get; set; }
        public string? StoreCode { get; set; }
        public string? FullName { get; set; }
        public string? UserId { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? OrganizeCode { get; set; }
        public string? ImageBase64 { get; set; }
        public string? UrlImage { get; set; }
        public string? FaceId { get; set; }


        public void Mapping(Profile profile)
        {
            profile.CreateMap<createAccountStoreDto, TblAdAccountStore>().ReverseMap();
            profile.CreateMap<createAccountStoreDto, TblAdAccount>().ReverseMap();

        }
    }

    public class updateAccountStoreDto : BaseMdDto, IMapFrom, IDto
    {
        public string UserName { get; set; }
        public string? StoreCode { get; set; }
        public string? FullName { get; set; }
        public string? UserId { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public bool? IsActive { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TblAdAccountStore, updateAccountStoreDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.TblAdAccount.FullName))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.TblAdAccount.UserId))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.TblAdAccount.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.TblAdAccount.Email))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.TblAdAccount.Address))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.TblAdAccount.IsActive));

            profile.CreateMap<updateAccountStoreDto, TblAdAccountStore>();

            profile.CreateMap<updateAccountStoreDto, TblAdAccount>().ReverseMap();
        }
    }




}
