namespace BE_QuanLiDiem.Models.DTO.HocPhan
{
    public class AddHocPhanDTO
    {
        public string TenHocPhan { get; set; }
        public int SoTiet { get; set; }
        public int SoTC { get; set; }
        public int HocKy { get; set; }
        public Guid BoMonId { get; set; }
    }
}
