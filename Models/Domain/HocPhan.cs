using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BE_QuanLiDiem.Models.Domain
{
    public class HocPhan
    {
        [Key] public Guid MaHocPhan { get; set; }
        public string TenHocPhan { get; set; }
        public int SoTiet { get; set; }
        public int SoTC { get; set; }
        public int HocKy { get; set; }  
        public Guid BoMonId { get; set; }
        public BoMon BoMon { get; set; }
    }
}
