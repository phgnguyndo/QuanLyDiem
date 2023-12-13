namespace BE_QuanLiDiem.Models.DTO.LopHocPhan
{
    public class AddLopHocPhanDTO
    {
        public string MaLopHocPhan { get; set; }
        public string DiaDiem { get; set; }
        public int SoHV { get; set; }
        public Guid HocPhanId { get; set; }
    }
}
