using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.BoMon;
using BE_QuanLiDiem.Models.DTO.LopHocPhan;

namespace BE_QuanLiDiem.Repository.Abstract
{
    public interface ILopHocPhanRP
    {
        Task<List<LopHocPhan>> GetAllLHPAsync();
        Task<LopHocPhan> GetLHPByIdAsync(string MaLHP);
        Task<LopHocPhan> CreateLHPAsync(AddLopHocPhanDTO addLopHocPhanDTO);
        Task<LopHocPhan> UpdateLHPAsync(UpdateLopHocPhanDTO updateLopHocPhanDTO, string MaLHP);
        Task<LopHocPhan> DeleteLHPAsync(string MaLHP);
    }
}
