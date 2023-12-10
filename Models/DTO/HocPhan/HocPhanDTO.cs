using BE_QuanLiDiem.Models.DTO.BoMon;

namespace BE_QuanLiDiem.Models.DTO.HocPhan
{
    public class HocPhanDTO
    {
        public Guid MaHocPhan { get; set; }
        public string TenHocPhan { get; set; }
        public int SoTiet { get; set; }
        public int SoTC { get; set; }
        public int HocKy { get; set; }
        public Guid BoMonId { get; set; }
        public BoMonDTO BoMon { get; set; }
    }
}
