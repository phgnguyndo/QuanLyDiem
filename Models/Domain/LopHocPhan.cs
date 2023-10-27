using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BE_QuanLiDiem.Models.Domain
{
    public class LopHocPhan
    {
        [Key]
        public Guid MaLopHocPhan { get; set; }
        public int SoHV { get; set; }
        public Guid HocPhanId { get; set; }
        public HocPhan HocPhan { get; set; }

    }
}
