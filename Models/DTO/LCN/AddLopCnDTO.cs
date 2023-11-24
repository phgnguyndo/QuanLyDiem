namespace BE_QuanLiDiem.Models.DTO.LCN
{
    public class AddLopCnDTO
    {
        public Guid DaiDoiId { get; set; }
        public string TenLopChuyenNganh { get; set; }
        public int SoHV { get; set; }
        public IFormFile? file { get; set; }
    }
}
