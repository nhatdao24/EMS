using AutoMapper;
using Common;
using EMS.BUSINESS.Common;
using EMS.BUSINESS.Dtos.MD;
using EMS.CORE;
using EMS.CORE.Entities.MD;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.BUSINESS.Services.MD
{
    public interface IPriorityService : IGenericService<TblMdPriority, PriorityDto>
    {
        Task<IList<PriorityDto>> GetAll(BaseMdFilter filter);
        Task<PagedResponseDto> Search(BaseFilter filter);

    }
    public class PriorityService(AppDbContext dbContext, IMapper mapper) : GenericService<TblMdPriority, PriorityDto>(dbContext, mapper), IPriorityService
    {
        public async Task<PagedResponseDto> Search(BaseFilter filter)
        {
            try
            {
                var query = _dbContext.TblMdPriority.AsQueryable();
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


        public async Task<IList<PriorityDto>> GetAll(BaseMdFilter filter)
        {
            try
            {
                var query = _dbContext.TblMdPriority.AsQueryable();
                return await base.GetAllMd(query, filter);
            }
            catch (Exception ex)
            {
                Status = false;
                Exception = ex;
                return null;
            }
        }
        public override async Task<PriorityDto> Add(IDto data)
        {
            try
            {
                var Dto = data as PriorityDto;
                if (Dto == null)
                    throw new Exception("Dữ liệu không hợp lệ");

                if (string.IsNullOrWhiteSpace(Dto.Code) ||
                    string.IsNullOrWhiteSpace(Dto.Name)
                    )
                    throw new ArgumentException("Không được để trống thông tin");

                bool exists = await _dbContext.TblMdPriority
                    .AnyAsync(x => x.Code == Dto.Code);

                if (exists)
                    throw new Exception("Mã cửa hàng đã tồn tại");

                return await base.Add(Dto);
            }
            catch (Exception ex)
            {
                Status = false;
                Exception = ex;
                return null;
            }
        }

        public override async Task<PriorityDto> Update(IDto data)
        {
            try
            {
                if (data is not PriorityDto Dto)
                    throw new Exception("Dữ liệu không hợp lệ");

                if (string.IsNullOrWhiteSpace(Dto.Code))
                    throw new Exception("Id không được để trống");

                var entity = await _dbContext.TblMdPriority
                    .FirstOrDefaultAsync(x => x.Code == Dto.Code);

                if (entity == null)
                    throw new InvalidOperationException("Bản ghi không tồn tại");

                if (string.IsNullOrWhiteSpace(Dto.Code) ||
                      string.IsNullOrWhiteSpace(Dto.Name)
                      )
                    throw new Exception("Không được để trống thông tin");

                _mapper.Map(Dto, entity);

                _dbContext.TblMdPriority.Update(entity);
                await _dbContext.SaveChangesAsync();

                return _mapper.Map<PriorityDto>(entity);
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
