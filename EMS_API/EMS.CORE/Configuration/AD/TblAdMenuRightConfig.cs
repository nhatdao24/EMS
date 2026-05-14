using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EMS.CORE.Entities.AD;

namespace EMS.CORE.Configuration.AD
{
    public class TblAdMenuRightConfig : IEntityTypeConfiguration<TblAdMenuRight>
    {
        public void Configure(EntityTypeBuilder<TblAdMenuRight> builder)
        {
            builder.HasKey(x => new { x.MenuId, x.RightId });
        }
    }
}
