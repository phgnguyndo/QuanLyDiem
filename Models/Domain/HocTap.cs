using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_QuanLiDiem.Models.Domain
{
    public class HocTap
    {
        [Key] public Guid MaHocTap {  get; set; } 
        public string HocVienId { get; set; }
        public Guid LopHocPhanId { get; set; }
        public HocVien HocVien { get; set; }
        public LopHocPhan LopHocPhan { get; set;}
    }
}
