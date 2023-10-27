using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.BoMon;
using BE_QuanLiDiem.Models.DTO.PhieuDiem;

namespace BE_QuanLiDiem.Repository.Abstract
{
    public interface IPhieuDiemRP
    {
        Task<List<PhieuDiem>> GetAllPhieuDiemAsync();
        Task<PhieuDiem> GetPhieuDiemByIdAsync(Guid MaPhieuDiem);
        Task<PhieuDiem> CreatePhieuDiemAsync(AddPhieuDiemDTO addPhieuDiemDTO);
        Task<PhieuDiem> UpdatePhieuDiemAsync(UpdatePhieuDiemDTO updatePhieuDiemDTO, Guid MaPhieuDeim);
        Task<PhieuDiem> DeletePhieuDiemAsync(Guid MaPhieuDeim);
    }
}
