using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BE_QuanLiDiem.Models.Domain
{
    public class LopChuyenNganh
    {
        [Key] public Guid MaLopChuyenNganh { get; set; }
        public Guid DaiDoiId { get; set; }
        public string TenLopChuyenNganh { get; set; }
        public int SoHV { get; set; } 
        public DaiDoi DaiDoi { get; set; }
    }
}
