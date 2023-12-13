using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.HocTap;

namespace BE_QuanLiDiem.Repository.Abstract
{
    public interface IHocTapRP
    {
        Task<List<HocTap>> GetAllHocTapAsync();
        Task<List<HocTap>> GetHocTapByIdHVAsync(Guid MaLCN);
        Task<HocTap> CreateHocTapAsync(AUHocTapDTO aUHocTapDTO);
        Task<HocTap> UpdateHocTapAsync(AUHocTapDTO aUHocTapDTO, Guid MaHocTap);
        Task<HocTap> DeleteHocTapAsync(Guid MaHocTap);
    }
}
