using EMS.CORE.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml.Attributes;
using EMS.CORE.Entities.MD;

//using ExcelMapper;

namespace EMS.CORE.Entities.AD
{
    [Table("T_AD_ACCOUNT_STORE")]
    public class  TblAdAccountStore : BaseEntity
    {
        [Key]
        [Column("USER_NAME")]
        public string? UserName { get; set; }

        [Column("STORE_CODE")]
        public string? StoreCode { get; set; }

        [ForeignKey("UserName")]
        public virtual TblAdAccount TblAdAccount { get; set; }

        [ForeignKey("StoreCode")]
        public virtual TblMdStore TblMdStore { get; set; }


    }
}
