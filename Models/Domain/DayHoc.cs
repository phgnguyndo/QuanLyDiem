using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BE_QuanLiDiem.Models.Domain
{
    //[PrimaryKey(nameof(GiangVienId),nameof(LopHocPhanId))]
    public class DayHoc
    {
        [Key] public Guid MaDayHoc { get; set; }  
        public Guid GiangVienId { get; set; }

        public string LopHocPhanId { get; set; }

        [DeleteBehavior(DeleteBehavior.ClientSetNull)]
        public GiangVien GiangVien { get; set;}
        [DeleteBehavior(DeleteBehavior.ClientSetNull)]
        public LopHocPhan LopHocPhan { get; set; }
    }
}
