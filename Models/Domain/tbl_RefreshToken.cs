using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BE_QuanLiDiem.Models.Domain
{
    public class tbl_RefreshToken
    {
        [Key]
        [Column("Id")]
        [Unicode(false)]
        public int Id { get; set; }
        [Column("UserId")]
        [StringLength(50)]
        [Unicode(false)]
        public string UserId { get; set; }
        [Column("TokenId")]
        [StringLength(50)]
        [Unicode(false)]
        public string? TokenId { get; set; }
        [Column("RefreshToken")]
        [StringLength(1000)]
        [Unicode(false)]
        public string? RefreshToken { get; set; }
    }
}
