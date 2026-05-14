using AutoMapper;
using EMS.BUSINESS.Common;
using EMS.BUSINESS.Dtos.AD;
using EMS.CORE;
using EMS.CORE.Entities.AD;
using Microsoft.EntityFrameworkCore;

namespace EMS.BUSINESS.Services.AD
{
    public interface IAppVersionService : IGenericService<TblAdAppVersion, AppVersionDto>
    {
        Task<AppVersionDto> GetCurrentVersion();
    }
    public class AppVersionService(AppDbContext dbContext, IMapper mapper) : GenericService<TblAdAppVersion, AppVersionDto>(dbContext, mapper), IAppVersionService
    {
        public async Task<AppVersionDto> GetCurrentVersion()
        {
            var data = await _dbContext.TblAdAppVersion.OrderByDescending(x => x.VersionCode).FirstOrDefaultAsync();

            return _mapper.Map<AppVersionDto>(data);
        }
    }
}
