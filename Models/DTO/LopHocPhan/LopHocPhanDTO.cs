using BE_QuanLiDiem.Models.DTO.DayHoc;
using BE_QuanLiDiem.Models.DTO.GiangVIen;
using BE_QuanLiDiem.Models.DTO.HocPhan;

namespace BE_QuanLiDiem.Models.DTO.LopHocPhan
{
    public class LopHocPhanDTO
    {
        public string MaLopHocPhan { get; set; }
        public int SoHV { get; set; }
        public string DiaDiem { get; set; }
        public Guid HocPhanId { get; set; }
        public HocPhanDTO HocPhan { get; set; }
        //public GiangVienDTO GiangVien { get; set; }
        //public DayHocDTO DayHoc { get; set; }
    }
}
