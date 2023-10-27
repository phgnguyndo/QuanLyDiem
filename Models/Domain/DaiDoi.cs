using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BE_QuanLiDiem.Models.Domain
{
    public class DaiDoi
    {
        [Key] public Guid MaDaiDoi { get; set; }
        public string TenDaiDoi { get; set; }
    }
}
