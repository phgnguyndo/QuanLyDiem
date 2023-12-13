using System.ComponentModel.DataAnnotations;

namespace BE_QuanLiDiem.Models.DTO.DTB
{
    public class AddDTBdto
    {
        public int HocKy { get; set; }
        public string HocVienId { get; set; }
        public float DTB { get; set; }
    }
}
