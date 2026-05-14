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
    [Table("T_MD_EMPLOYEES")] 
    public class TblMdEmployees : BaseEntity
    {
        [Key]
        [Required]
        [Column("CODE", TypeName = "VARCHAR(50)")]
        public string Code { get; set; }

        [Required]
        [Column("FULL_NAME", TypeName = "NVARCHAR(255)")]
        public string FullName { get; set; }

        [Required]
        [Column("POSITION", TypeName = "NVARCHAR(100)")]
        public string Position { get; set; }

        
        [Column("PHONENUMBER", TypeName = "VARCHAR(20)")]
        public string? PhoneNumber { get; set; }

        [Required]
        [Column("DIGITALSIG", TypeName = "VARCHAR(1000)")]
        public string DigitalSig { get; set; }

        [Required]
        [Column("EMAIL", TypeName = "VARCHAR(255)")]
        public string Email { get; set; }

        [Required]
        [Column("ADDRESS", TypeName = "NVARCHAR(255)")]
        public string Address { get; set; }
    }
}
