using AutoMapper;
using Common;
using EMS.BUSINESS.Common;
using EMS.BUSINESS.Dtos.MD;
using EMS.BUSINESS.Services.HUB;
using EMS.CORE;
using EMS.CORE.Entities.MD;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Minio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BUSINESS.Services.MD
{

    public interface IAccountTypeService : IGenericService<TblMdAccountType, AccountTypeDto>
    {
        Task<PagedResponseDto> Search(BaseFilter filter);

        Task<AccountTypeDto> Add(IDto data);

        Task<AccountTypeDto> Update(IDto data);

    }
    public class AccountTypeService : GenericService<TblMdAccountType, AccountTypeDto>, IAccountTypeService
    {
        private readonly IHubContext<RefreshServiceHub> _hubContext;
        private readonly IConfiguration _configuration;
        private readonly IMinioClient _minioClient;
        public AccountTypeService(AppDbContext dbContext, IMapper mapper, IHubContext<RefreshServiceHub> hubContext, IConfiguration configuration, IMinioClient minioClient) : base(dbContext, mapper)
        {
            _hubContext = hubContext;
            _configuration = configuration;
            _minioClient = minioClient;
        }

        public override async Task<PagedResponseDto> Search(BaseFilter filter)
        {
            try
            {
                var query = _dbContext.TblMdAccountTpye.AsQueryable();
                if (!string.IsNullOrWhiteSpace(filter.KeyWord))
                {
                    query = query.Where(x => x.Code.ToString().Contains(filter.KeyWord) || x.Name.Contains(filter.KeyWord));
                }
                if (filter.IsActive.HasValue)
                {
                    query = query.Where(x => x.IsActive == filter.IsActive);
                }
                query = query.OrderByDescending(x => x.CreateDate);
                return await Paging(query, filter);

            }
            catch (Exception ex)
            {
                Status = false;
                Exception = ex;
                return null;
            }
        }

        public override async Task<AccountTypeDto> Add(IDto data)
        {
            try
            {
                var Dto = data as AccountTypeDto;
                if (Dto == null)
                    throw new Exception("Dữ liệu không hợp lệ");

                if (string.IsNullOrWhiteSpace(Dto.Code) ||
                    string.IsNullOrWhiteSpace(Dto.Name) 
                    )
                    throw new ArgumentException("Không được để trống thông tin");

                bool exists = await _dbContext.TblMdAccountTpye
                    .AnyAsync(x => x.Code == Dto.Code);

                if (exists)
                    throw new Exception("Mã nhân viên đã tồn tại.");

                return await base.Add(Dto);
            }
            catch (Exception ex)
            {
                Status = false;
                Exception = ex;
                return null;
            }
        }

        public override async Task<AccountTypeDto> Update(IDto data)
        {
            try
            {
                if (data is not AccountTypeDto Dto)
                    throw new Exception("Dữ liệu không hợp lệ");

                var entity = await _dbContext.TblMdAccountTpye
                    .FirstOrDefaultAsync(x => x.Code == Dto.Code);

                if (entity == null)
                    throw new InvalidOperationException("Bản ghi không tồn tại");

                if (string.IsNullOrWhiteSpace(Dto.Code) ||
                      string.IsNullOrWhiteSpace(Dto.Name)
                      )
                    throw new Exception("Không được để trống thông tin");

                _mapper.Map(Dto, entity);

                _dbContext.TblMdAccountTpye.Update(entity);
                await _dbContext.SaveChangesAsync();

                return _mapper.Map<AccountTypeDto>(entity);
            }
            catch (Exception ex)
            {
                Status = false;
                Exception = ex;
                return null;
            }
        }

    }
}
