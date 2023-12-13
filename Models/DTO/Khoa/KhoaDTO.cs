using BE_QuanLiDiem.Models.DTO.BoMon;
using System.ComponentModel.DataAnnotations;

namespace BE_QuanLiDiem.Models.DTO.Khoa
{
    public class KhoaDTO
    {
        public Guid MaKhoa { get; set; }
        public string TenKhoa { get; set; }
    }
}
