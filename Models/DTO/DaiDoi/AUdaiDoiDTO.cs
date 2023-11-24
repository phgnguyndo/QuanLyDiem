namespace BE_QuanLiDiem.Models.DTO.DaiDoi
{
    public class AUdaiDoiDTO
    {
        public string TenDaiDoi { get; set; }
        public string DaiDoiTruong { get; set; }
        public int QuanSo { get; set; }
        public IFormFile? file { get; set; }
    }
}
