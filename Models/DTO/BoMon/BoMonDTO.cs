using BE_QuanLiDiem.Models.Domain;

namespace BE_QuanLiDiem.Models.DTO.BoMon
{
    public class BoMonDTO
    {
        public Guid MaBM { get; set; }
        public string TenBM { get; set; }
        public Guid KhoaId { get; set; }
        //public Khoa Khoa { get; set; }
    }
}
