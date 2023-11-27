using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_QuanLiDiem.Models.Domain
{
    public class ChuongTrinh
    {
        [Key] public Guid MaChuongTrinh { get; set; }
        public Guid LopChuyenNganhId { get; set; }
        public Guid HocPhanId { get; set; }
        public LopChuyenNganh LopChuyenNganh { get; set; }
        public HocPhan HocPhan { get; set; }  
    }
}
