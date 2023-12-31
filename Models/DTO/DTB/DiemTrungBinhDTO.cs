﻿using BE_QuanLiDiem.Models.DTO.HocVien;
using BE_QuanLiDiem.Models.DTO.PhieuDiem;
using System.ComponentModel.DataAnnotations;

namespace BE_QuanLiDiem.Models.DTO.DTB
{
    public class DiemTrungBinhDTO
    {
        public int Id { get; set; }
        public int HocKy { get; set; }
        public string HocVienId { get; set; }
        public float DTB { get; set; }
        public int TongTC { get; set; }
        public HocVienDTO HocVien { get; set; } 
        public PhieuDiemDTO PhieuDiem { get; set;}
    }
}
