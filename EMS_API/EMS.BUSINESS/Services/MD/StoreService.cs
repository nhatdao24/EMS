using AutoMapper;
using Common;
using EMS.BUSINESS.Common;
using EMS.BUSINESS.Dtos.MD;
using EMS.CORE;
using EMS.CORE.Entities.MD;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EMS.BUSINESS.Services.MD
{
    public interface IStoreService : IGenericService<TblMdStore, StoreDto>
    {
        Task<IList<StoreDto>> GetAll(BaseMdFilter filter);
        Task<IList<StoreDto>> GetByStoreCode(string storeCode);
        Task<PagedResponseDto> Search(BaseFilter filter);
    }

    public class StoreService(AppDbContext dbContext, IMapper mapper) : GenericService<TblMdStore, StoreDto>(dbContext, mapper), IStoreService
    {
        public async Task<PagedResponseDto> Search(BaseFilter filter)
        {
            try
            {
                var query = _dbContext.TblMdStore.AsQueryable();
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


        public async Task<IList<StoreDto>> GetAll(BaseMdFilter filter)
        {
            try
            {
                var query = _dbContext.TblMdStore.AsQueryable();
                return await base.GetAllMd(query, filter);
            }
            catch (Exception ex)
            {
                Status = false;
                Exception = ex;
                return null;
            }
        }
        public override async Task<StoreDto> Add(IDto data)
        {
            try
            {
                var Dto = data as StoreDto;
                if (Dto == null)
                    throw new Exception("Dữ liệu không hợp lệ");

                if (string.IsNullOrWhiteSpace(Dto.Code) ||
                    string.IsNullOrWhiteSpace(Dto.Name)
                    )
                    throw new ArgumentException("Không được để trống thông tin");

                bool exists = await _dbContext.TblMdStore
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

        public override async Task<StoreDto> Update(IDto data)
        {
            try
            {
                if (data is not StoreDto Dto)
                    throw new Exception("Dữ liệu không hợp lệ");

                if (string.IsNullOrWhiteSpace(Dto.Code))
                    throw new Exception("Id không được để trống");

                var entity = await _dbContext.TblMdStore
                    .FirstOrDefaultAsync(x => x.Code == Dto.Code);

                if (entity == null)
                    throw new InvalidOperationException("Bản ghi không tồn tại");

                if (string.IsNullOrWhiteSpace(Dto.Code) ||
                      string.IsNullOrWhiteSpace(Dto.Name)
                      )
                    throw new Exception("Không được để trống thông tin");

                _mapper.Map(Dto, entity);

                _dbContext.TblMdStore.Update(entity);
                await _dbContext.SaveChangesAsync();

                return _mapper.Map<StoreDto>(entity);
            }
            catch (Exception ex)
            {
                Status = false;
                Exception = ex;
                return null;
            }
        }
        public async Task<IList<StoreDto>> GetByStoreCode(string storeCode)
        {
            try
            {
                var query = _dbContext.Set<TblMdStore>().AsQueryable();
                query = query.Where(x => x.Code == storeCode);
                var lstEntity = await query.ToListAsync();
                return _mapper.Map<List<StoreDto>>(lstEntity);
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
