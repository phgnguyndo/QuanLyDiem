namespace BE_QuanLiDiem.Models.DTO.HocVien
{
    public class HocVienDTO
    {
        public string MaHV { get; set; }
        public Guid LopChuyenNganhId { get; set; }
        public string TenHV { get; set; }
        public string AnhHV { get; set; }
        public string NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string QueQuan { get; set; }
        public string CapBac { get; set; }
    }
}
