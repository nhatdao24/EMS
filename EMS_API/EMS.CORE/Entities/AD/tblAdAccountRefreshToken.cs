using EMS.CORE.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.CORE.Entities.AD
{
    [Table("T_AD_REFRESH_TOKEN")]
    public class TblAdAccountRefreshToken : BaseEntity
    {
        [Key]
        [Column("ID")]
        public Guid Id { get; set; }

        [Column("USER_NAME", TypeName = "VARCHAR(50)")]
        public string UserName { get; set; }

        [Column("REFRESH_TOKEN", TypeName = "NVARCHAR(2000)")]
        public string RefreshToken { get; set; }

        [Column("EXPIRE_TIME")]
        public DateTime ExpireTime { get; set; }

        public virtual TblAdAccount Account { get; set; }
    }
}
