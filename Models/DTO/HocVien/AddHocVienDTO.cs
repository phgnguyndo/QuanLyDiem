namespace BE_QuanLiDiem.Models.DTO.HocVien
{
    public class AddHocVienDTO
    {
        public string MaHV { get; set; }
        public Guid LopChuyenNganhId { get; set; }
        public string TenHV { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string QueQuan { get; set; }
        public string CapBac { get; set; }
        public IFormFile? file { get; set; }

    }
}
