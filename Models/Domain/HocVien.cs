using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BE_QuanLiDiem.Models.Domain
{
    public class HocVien
    {

        [Key] public string MaHV { get; set; }
        public Guid LopChuyenNganhId { get; set; }
        public string TenHV { get; set; }
        public string AnhHV { get; set; }  
        public DateTime NgaySinh { get; set; }  
        public bool GioiTinh { get; set; }
        public string QueQuan { get; set; }
        public string CapBac { get; set; }
        public LopChuyenNganh LopChuyenNganh { get;set; }
        
    }
}
