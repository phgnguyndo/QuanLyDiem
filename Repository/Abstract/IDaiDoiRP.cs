using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.BoMon;
using BE_QuanLiDiem.Models.DTO.DaiDoi;

namespace BE_QuanLiDiem.Repository.Abstract
{
    public interface IDaiDoiRP
    {
        Task<List<DaiDoi>> GetAllDaiDoiAsync();
        Task<DaiDoi> GetDaiDoiByIdAsync(Guid MaDaiDoi);
        Task<DaiDoi> CreateDaiDoiAsync(AUdaiDoiDTO aUdaiDoiDTO);
        Task<DaiDoi> UpdateDaiDoiAsync(AUdaiDoiDTO aUdaiDoiDTO, Guid MaDaiDoi);
        Task<DaiDoi> DeleteDaiDoiAsync(Guid MaDaiDoi);
    }
}
