using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.BoMon;
using BE_QuanLiDiem.Models.DTO.ChuongTrinh;

namespace BE_QuanLiDiem.Repository.Abstract
{
    public interface IChuongTrinhRP
    {
        Task<List<ChuongTrinh>> GetAllChuongTringAsync();
        Task<List<ChuongTrinh>> GetChuongTrinhnByIdLCNAsync(Guid MaLCN);
        Task<ChuongTrinh> CreateChuongTrinhAsync(AUChuongTrinhDTO aUChuongTrinhDTO);
        Task<ChuongTrinh> UpdateChuongTrinhAsync(AUChuongTrinhDTO aUChuongTrinhDTO, Guid MaCT);
        Task<ChuongTrinh> DeleteCHuongTrinhAsync(Guid MaCT);
    }
}
