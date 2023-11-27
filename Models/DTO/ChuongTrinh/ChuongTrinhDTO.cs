using BE_QuanLiDiem.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace BE_QuanLiDiem.Models.DTO.ChuongTrinh
{
    public class ChuongTrinhDTO
    {
        public Guid MaChuongTrinh { get; set; }
        public Guid LopChuyenNganhId { get; set; }
        public Guid HocPhanId { get; set; }
    }
}
