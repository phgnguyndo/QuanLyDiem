using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.BoMon;
using BE_QuanLiDiem.Models.DTO.HocVien;

namespace BE_QuanLiDiem.Repository.Abstract
{
    public interface IHocVienRP
    {
        Task<List<HocVien>> GetAllHocVienAsync(int pageNumber=1, int pageSize=10);
        Task<List<HocVien>> GetHocVienByIdLopAsync(Guid MaLop);
        Task<HocVien> GetHocVienByIdAsync(string MaHV);
        Task<HocVien> CreateHocVienAsync(AddHocVienDTO addHocVienDTO);
        Task<HocVien> UpdateHocVienAsync(UpdateHocVienDTO updateHocVienDTO, string MaHV);
        Task<HocVien> DeleteHocVienAsync(string MaHV);
    }
}
