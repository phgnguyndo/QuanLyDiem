namespace BE_QuanLiDiem.Models.DTO.DaiDoi
{
    public class DaiDoiDTO
    {
        public Guid MaDaiDoi { get; set; }
        public string? AnhDaiDoi { get; set; }
        public string TenDaiDoi { get; set; }
        public string DaiDoiTruong { get; set; }
        public int QuanSo { get; set; }
    }
}
