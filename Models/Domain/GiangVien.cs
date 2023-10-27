using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BE_QuanLiDiem.Models.Domain
{
    public class GiangVien
    {
        [Key] public Guid MaGV { get; set; }
        public string TenGV { get; set; }
        public string sdt { get; set; }
        public Guid BoMonId { get; set; }
        public BoMon BoMon { get; set; }
    }
}
