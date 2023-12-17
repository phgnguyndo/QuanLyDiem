using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BE_QuanLiDiem.Models.Domain
{
    public class LopHocPhan
    {
        [Key]
        public string MaLopHocPhan { get; set; }
        public string DiaDiem { get; set; }
        public int SoHV { get; set; }
        public Guid GiangVienId {  get; set; }
        public Guid HocPhanId { get; set; }
        public HocPhan HocPhan { get; set; }

    }
}
