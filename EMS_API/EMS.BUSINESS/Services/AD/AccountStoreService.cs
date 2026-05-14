using AutoMapper;
using Common;
using EMS.BUSINESS.Common;
using EMS.BUSINESS.Dtos.AD;
using EMS.CORE;
using EMS.CORE.Entities.AD;
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
using Common.Util;


namespace EMS.BUSINESS.Services.AD
{
    public interface IAccountStoreService : IGenericService<TblAdAccountStore, AccountStoreDto>
    {
        Task<IList<AccountStoreDto>> GetAll(BaseMdFilter filter);
        Task<IList<AccountStoreDto>> GetByStoreCode(string storeCode);
        Task<IList<AccountStoreDto>> GetByUserName(string userName);
        Task<AccountStoreDto> Create(IDto createAccountStoreDto);
        Task<IList<updateAccountStoreDto>> GetAllAccount(BaseMdFilter filter);
        Task<updateAccountStoreDto> UpdateAccount(IDto data);

    }

    public class AccountStoreService(AppDbContext dbContext, IMapper mapper) : GenericService<TblAdAccountStore, AccountStoreDto>(dbContext, mapper), IAccountStoreService
    {
        public override async Task<PagedResponseDto> Search(BaseFilter filter)
        {
            try
            {
                var query = _dbContext.TblAdAccountStore.AsQueryable();
                if (!string.IsNullOrWhiteSpace(filter.KeyWord))
                {
                    query = query.Where(x => x.UserName.ToString().Contains(filter.KeyWord) || x.StoreCode.Contains(filter.KeyWord));
                }
                if (filter.IsActive.HasValue)
                {
                    query = query.Where(x => x.IsActive == filter.IsActive);
                }
                return await Paging(query, filter);

            }
            catch (Exception ex)
            {
                Status = false;
                Exception = ex;
                return null;
            }
        }


        public async Task<IList<AccountStoreDto>> GetAll(BaseMdFilter filter)
        {
            try
            {
                var query = _dbContext.TblAdAccountStore.AsQueryable();
                if (filter.IsActive.HasValue)
                {
                    query = query.Where(x => x.IsActive == filter.IsActive);
                }

                return await base.GetAllMd(query, filter);
            }
            catch (Exception ex)
            {
                Status = false;
                Exception = ex;
                return null;
            }
        }
        public override async Task<AccountStoreDto> Add(IDto data)
        {
            try
            {
                var Dto = data as AccountStoreDto;
                if (Dto == null)
                    throw new Exception("Dữ liệu không hợp lệ");
                if (string.IsNullOrWhiteSpace(Dto.UserName))
                    throw new Exception("Tên đăng nhập không được để trống");
                var checkUserName = await _dbContext.TblAdAccountStore.AnyAsync(x => x.UserName == Dto.UserName);
                if (checkUserName)
                {
                    throw new Exception("Tên đăng nhập đã tồn tại");
                }

                Status = true;
                return await base.Add(Dto);
            }
            catch (Exception ex)
            {
                Status = false;
                Exception = ex;
                return null;
            }
        }

        public override async Task<AccountStoreDto> Update(IDto data)
        {
            try
            {
                if (data is not AccountStoreDto Dto)
                    throw new ArgumentException("Dữ liệu không hợp lệ");

                if (string.IsNullOrWhiteSpace(Dto.UserName))
                    throw new ArgumentException("USER_NAME không được để trống");

                var entity = await _dbContext.TblAdAccountStore
                    .FirstOrDefaultAsync(x => x.UserName == Dto.UserName);

                if (entity == null)
                    throw new InvalidOperationException("Bản ghi không tồn tại");
                if (string.IsNullOrWhiteSpace(Dto.UserName))
                    throw new ArgumentException("Tên đăng nhập không được để trống");

                _mapper.Map(Dto, entity);


                _dbContext.TblAdAccountStore.Update(entity);
                await _dbContext.SaveChangesAsync();

                return _mapper.Map<AccountStoreDto>(entity);
            }
            catch (Exception ex)
            {
                Status = false;
                Exception = ex;
                return null;
            }
        }

        public async Task<IList<AccountStoreDto>> GetByStoreCode(string storeCode)
        {
            try
            {
                var query = _dbContext.Set<TblAdAccountStore>().AsQueryable();
                query = query.Where(x => x.IsActive == true && x.StoreCode == storeCode);
                var lstEntity = await query.ToListAsync();
                return _mapper.Map<List<AccountStoreDto>>(lstEntity);
            }
            catch (Exception ex)
            {
                Status = false;
                Exception = ex;
                return null;
            }
        }
        public async Task<IList<AccountStoreDto>> GetByUserName(string userName)
        {
            try
            {
                var query = _dbContext.Set<TblAdAccountStore>().AsQueryable();
                query = query.Where(x => x.IsActive == true && x.UserName == userName);
                var lstEntity = await query.ToListAsync();
                return _mapper.Map<List<AccountStoreDto>>(lstEntity);
            }
            catch (Exception ex)
            {
                Status = false;
                Exception = ex;
                return null;
            }
        }

        public async Task<AccountStoreDto> Create(IDto createAccountStoreDto)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                var accountEntity = _mapper.Map<TblAdAccount>(createAccountStoreDto);
                var accountStoreEntity = _mapper.Map<TblAdAccountStore>(createAccountStoreDto);

                var checkUserName = await _dbContext.TblAdAccountStore.AnyAsync(x => x.UserName == accountStoreEntity.UserName);
                if (checkUserName)
                {
                    throw new Exception("Tên đăng nhập đã tồn tại");
                }
                accountEntity.Password = Utils.CryptographyMD5(accountEntity.Password);

                accountStoreEntity.TblAdAccount = accountEntity;
                accountStoreEntity.UserName = accountEntity.UserName;

                _dbContext.TblAdAccount.Add(accountEntity);
                _dbContext.TblAdAccountStore.Add(accountStoreEntity);

                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();

                return _mapper.Map<AccountStoreDto>(accountStoreEntity);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                Status = false;
                Exception = ex;
                return null;
            }
        }

        public async Task<IList<updateAccountStoreDto>> GetAllAccount(BaseMdFilter filter)
        {
            try
            {
                var query = _dbContext.TblAdAccountStore.Include(x => x.TblAdAccount).AsQueryable();
                if (filter.IsActive.HasValue)
                {
                    query = query.Where(x => x.IsActive == filter.IsActive);
                }
                var entities = await query.ToListAsync();
                return _mapper.Map<List<updateAccountStoreDto>>(entities);
            }
            catch (Exception ex)
            {
                Status = false;
                Exception = ex;
                return null;
            }
        }

        public async Task<updateAccountStoreDto> UpdateAccount(IDto data)
        {
            var Dto = data as updateAccountStoreDto;
            if (Dto == null)
                throw new Exception("Dữ liệu không hợp lệ");

            if(string.IsNullOrWhiteSpace(Dto.UserName) || string.IsNullOrWhiteSpace(Dto.StoreCode))
                throw new Exception("Tên đăng nhập hoặc storecode đang trống");

            try
            {
                var existingAccount = await _dbContext.TblAdAccount.FirstOrDefaultAsync(x => x.UserName == Dto.UserName);
                if (existingAccount == null)
                {
                    throw new Exception("ko tìm thấy tên tài khoản");
                }
                _mapper.Map(Dto, existingAccount);
                await _dbContext.SaveChangesAsync();
                return Dto;
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

