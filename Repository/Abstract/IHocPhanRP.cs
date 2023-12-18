using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.GiangVIen;
using BE_QuanLiDiem.Models.DTO.HocPhan;

namespace BE_QuanLiDiem.Repository.Abstract
{
    public interface IHocPhanRP
    {
        Task<List<HocPhan>> GetAllHocPhanAsync(int pageNumber = 1, int pageSize = 10);
        Task<HocPhan> GetHocPhanByIdAsync(Guid MaHocPhan);
        Task<HocPhan> CreateHocPhanAsync(AddHocPhanDTO addHocPhanDTO);
        Task<HocPhan> UpdateHocPhanAsync(UpdateHocPhanDTO updateHocPhanDTO, Guid MaHocPhan);
        Task<HocPhan> DeleteHocPhanAsync(Guid MaHocPhan);
    }
}
