using BE_QuanLiDiem.Models.DTO.HocVien;
using System.ComponentModel.DataAnnotations;

namespace BE_QuanLiDiem.Models.DTO.DTB
{
    public class DiemTrungBinhDTO
    {
        public int Id { get; set; }
        public int HocKy { get; set; }
        public string HocVienId { get; set; }
        public float DTB { get; set; }
        public HocVienDTO HocVien { get; set; } 
    }
}
