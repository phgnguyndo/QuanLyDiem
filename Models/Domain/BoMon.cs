using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BE_QuanLiDiem.Models.Domain
{
    public class BoMon
    {
        [Key] public Guid MaBM { get; set; }
        public string TenBM { get; set; }
        public Guid KhoaId { get; set; }
        public Khoa Khoa { get; set;}
    }
}
