using EMS.CORE.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.CORE.Entities.MD
{
    [Table("T_MD_ACCOUNT_TYPE")] 
    public class TblMdAccountType : BaseEntity
    {
        [Key]
        [Required]
        [Column("CODE", TypeName = "VARCHAR(50)")]
        public string Code { get; set; }

        [Required]
        [Column("NAME", TypeName = "NVARCHAR(255)")]
        public string Name { get; set; }

    }
}
