using EMS.CORE.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMS.CORE.Entities.MD
{
    [Table("T_MD_TEST")]
    public class TblMdTest : BaseEntity
    {
        [Key]
        [Column("CODE", TypeName = "VARCHAR(50)")]
        public string Code { get; set; }
        [Column("NAME", TypeName = "NVARCHAR(255)")]
        public string Name { get; set; }
        [Column("DESCRIPTION", TypeName = "NVARCHAR(500)")]
        public string? Description { get; set; }
    }
}