using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.BoMon;
using BE_QuanLiDiem.Models.DTO.DTB;

namespace BE_QuanLiDiem.Repository.Abstract
{
    public interface IDtbRp
    {
        Task<List<DiemTrungBinh>> GetAllDTBAsync();
        Task<List<DiemTrungBinh>> GetDTBByIdHVAsync(string MaHV);
        Task<List<DiemTrungBinh>> GetDTBByHocKyAsync(int HocKy);
        Task<DiemTrungBinh> CreateDTBAsync(AddDTBdto addDTBdto);
        Task<DiemTrungBinh> UpdateDTBAsync(UpdateDTBdto updateDTBdto, int hocKy, string MaHV);
        Task<DiemTrungBinh> DeleteDTBAsync(int MaDTB);
    }
}
