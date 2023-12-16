namespace BE_QuanLiDiem.Models.DTO.PhieuDiem
{
    public class AddPhieuDiemDTO
    {
        public Guid HocPhanId { get; set; }
        public string HocVienId { get; set; }
        public float DiemCC { get; set; }
        public float DiemTX { get; set; }
        public float DiemThi { get; set; }
    }
}
