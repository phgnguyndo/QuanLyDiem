using BE_QuanLiDiem.Models.DTO.BoMon;

namespace BE_QuanLiDiem.Models.DTO.GiangVIen
{
    public class GiangVienDTO
    {
        public Guid MaGV { get; set; }
        public string TenGV { get; set; }
        public bool? GioiTinh { get; set; }
        public string? CapBac { get; set; }
        public string sdt { get; set; }
        public Guid BoMonId { get; set; }
        public BoMonDTO BoMon { get; set; }
    }
}
