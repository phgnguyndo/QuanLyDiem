using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BE_QuanLiDiem.Constans;

namespace BE_QuanLiDiem.Models.DTO.User
{
    public class tblUserDTO
    {
        public string Code { get; set; }
        //public string? Name { get; set; }
        //public string? Email { get; set; }
        //public string? Phone { get; set; }
        public string Password { get; set; }
        //public bool? IsActive { get; set; } = true;
        public string? MaHV { get; set; } = null;
        public Guid? MaDaiDoi { get; set; } = null;
        public string? Role { get; set; } = UserRole.USER2;
    }
}
