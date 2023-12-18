using System.ComponentModel.DataAnnotations;

namespace BE_QuanLiDiem.Models.Domain
{
    public class TruyVet
    {
        [Key] public Guid Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public DateTime? tgDangNhap { get; set; }
        public DateTime? tgDangXuat { get; set; }
    }
}
