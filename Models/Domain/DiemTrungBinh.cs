using System.ComponentModel.DataAnnotations;

namespace BE_QuanLiDiem.Models.Domain
{
    public class DiemTrungBinh
    {
        [Key]
        public int Id { get; set; }
        public int HocKy { get; set; }
        public string HocVienId { get; set; }
        public float DTB { get; set; } = 0;
        public int TongTC { get; set; }
        public HocVien HocVien { get; set; }    
    }
}
