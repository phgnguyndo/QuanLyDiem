namespace BE_QuanLiDiem.Models.DTO.TruyVet
{
    public class TruyVetDTO
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public DateTime? tgDangNhap { get; set; }
        public DateTime? tgDangXuat { get; set; }
    }
}
