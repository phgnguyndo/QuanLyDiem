using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.BoMon;
using BE_QuanLiDiem.Models.DTO.LopHocPhan;

namespace BE_QuanLiDiem.Repository.Abstract
{
    public interface ILopHocPhanRP
    {
        Task<List<LopHocPhan>> GetAllLHPAsync();
        Task<LopHocPhan> GetLHPByIdAsync(Guid MaLHP);
        Task<LopHocPhan> CreateLHPAsync(AddLopHocPhanDTO addLopHocPhanDTO);
        Task<LopHocPhan> UpdateLHPAsync(UpdateLopHocPhanDTO updateLopHocPhanDTO, Guid MaLHP);
        Task<LopHocPhan> DeleteLHPAsync(Guid MaLHP);
    }
}
