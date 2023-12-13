using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_QuanLiDiem.Models.Domain
{
    public class HocTap
    {
        [Key] public Guid MaHocTap {  get; set; } 
        public Guid LopChuyenNganhId { get; set; }
        public string LopHocPhanId { get; set; }
        public LopHocPhan LopHocPhan { get; set; }
        public LopChuyenNganh LopChuyenNganh { get; set;}
    }
}
