namespace BE_QuanLiDiem.Models.DTO.TruyVet
{
    public class AddTruyVetDTO
    {
        public string Username { get; set; }
        public string Role { get; set; }
        public DateTime? tgDangNhap { get; set; }
        public DateTime? tgDangXuat { get; set; }
    }
}
