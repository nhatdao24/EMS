using EMS.CORE.Common;
using EMS.CORE.Entities.AD;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.CORE.Entities.MD
{


    [Table("T_MD_STORE")]
    public class TblMdStore : SoftDeleteEntity
    {
        [Key]
        [Column("CODE", TypeName = "VARCHAR(50)")]
        public string? Code { get; set; }

        [Required]
        [Column("NAME", TypeName = "NVARCHAR(255)")]
        public string? Name { get; set; }

        [Column("PHONE", TypeName = "VARCHAR(20)")]
        public string? Phone { get; set; }

        [Required]
        [Column("ADDRESS", TypeName = "NVARCHAR(500)")]
        public string Address { get; set; }

        [Required]
        [Column("AREA", TypeName = "NVARCHAR(100)")]
        public string Area { get; set; }

        public virtual ICollection<TblAdAccountStore> AccountStores { get; set; }

    }

}
