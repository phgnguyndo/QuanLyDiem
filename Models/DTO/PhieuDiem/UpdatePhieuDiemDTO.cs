namespace BE_QuanLiDiem.Models.DTO.PhieuDiem
{
    public class UpdatePhieuDiemDTO
    {
        public Guid LopHocPhanId { get; set; }
        public string HocVienId { get; set; }
        public float DiemCC { get; set; }
        public float DiemTX { get; set; }
        public float DiemThi { get; set; }
        //public float DiemTBM { get; set; }
        //public float DiemTK_HocKy { get; set; }
        //public float DiemTK_Nam { get; set; }
        public float DiemThiLai { get; set; }
        public int LanThi { get; set; }
        //public string DiemChu { get; set; }
    }
}
