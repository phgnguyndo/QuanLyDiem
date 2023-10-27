using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BE_QuanLiDiem.Models.Domain
{
    public class Khoa
    {
        [Key] public Guid MaKhoa { get; set; }    
        public string TenKhoa { get; set; }
    }
}
