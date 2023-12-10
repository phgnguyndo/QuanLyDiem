namespace BE_QuanLiDiem.Models.DTO.GiangVIen
{
    public class UpdateGiangVienDTO
    {
        public string TenGV { get; set; }
        public bool? GioiTinh { get; set; }
        public string? CapBac { get; set; }
        public string sdt { get; set; }
        public Guid BoMonId { get; set; }
    }
}
