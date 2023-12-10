using BE_QuanLiDiem.Constans;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BE_QuanLiDiem.Models.Domain
{
    public class tbl_user
    {
        [Key]
        [Column("Id")]
        [Unicode(false)]
        public int Id { get; set; }
        [Column("Code")]
        [StringLength(50)]
        [Unicode(false)]
        public string Code { get; set; }
        [Column("Name")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Name { get; set; }
        [Column("Email")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Email { get; set; }
        [Column("Phone")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Phone { get; set; }
        [Column("Password")]
        [StringLength(500)]
        [Unicode(false)]
        public string? Password { get; set; }
        [Column("IsActive")]
        [StringLength(50)]
        [Unicode(false)]
        public bool? IsActive { get; set; }
        [Column("Role")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Role { get; set; }
    }
}
