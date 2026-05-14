namespace Common
{
    public class BaseMdDto : SoftDeleteBaseDto
    {
        public bool? IsActive { get; set; }
    }
    public class BaseMdTemDto
    {
        public bool? IsActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? CreateBy { get; set; }
    }

    public class BaseMdEDto
    {
        public bool? IsActive { get; set; }
        public string? CreateBy { get; set; }
        public string? UpdateBy { get; set; }
        public virtual DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }


    }
}
