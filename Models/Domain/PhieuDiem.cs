using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_QuanLiDiem.Models.Domain
{
    public class PhieuDiem
    {
        [Key] public Guid MaPhieuDiem { get; set; } 
        //public Guid LopHocPhanId { get; set; }
        public Guid HocPhanId { get; set; }
        public string HocVienId { get; set; }
        //public LopHocPhan LopHocPhan { get; set; }
        public HocPhan HocPhan { get; set; }
        public HocVien HocVien { get; set; }
        public float DiemCC { get; set; }
        public float DiemTX { get; set; }
        public float DiemThi { get; set; }      
        public float DiemThiLai { get; set; }
        public int LanThi { get; set; }
        //public string DiemChu { get; set; }
        //public float DiemTBM { get; set; }
        //public float DiemTK_HocKy { get; set; }
        //public float DiemTK_Nam { get; set; }

    }
}

