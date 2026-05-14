using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EMS.CORE.Common;
namespace EMS.CORE.Entities.CM
{
    [Table("T_CM_FILE")]
    public class TblCmFile : SoftDeleteEntity
    {
        [Key]
        [Column("ID", TypeName = "VARCHAR(50)")]
        public string? Id { get; set; }
        [Column("REFRENCE_FILE_ID", TypeName = "VARCHAR(500)")]
        public string? RefrenceFileId { get; set; }
        [Column("FILE_NAME", TypeName = "NVARCHAR(500)")]
        public string? FileName { get; set; }
        [Column("FILE_TYPE", TypeName = "NVARCHAR(200)")]
        public string? FileType { get; set; }
        [Column("FILE_SIZE", TypeName = "DECIMAL(18,0)")]
        public decimal? FileSize { get; set; }
        [Column("PATH", TypeName = "NVARCHAR(500)")]
        public string? FilePath { get; set; }
        [Column("FILE_PATH", TypeName = "NVARCHAR(500)")]
        public string? FilePathFull { get; set; }
        [Column("FILE_NAME_KHONG_DAU", TypeName = "NVARCHAR(500)")]
        public string? FileNameKhongDau { get; set; }
        [Column("IS_ALLOW_DELETE")]
        public bool? IsAllowDelete { get; set; }
    }
}