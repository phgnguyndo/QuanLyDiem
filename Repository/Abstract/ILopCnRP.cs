using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.BoMon;
using BE_QuanLiDiem.Models.DTO.LCN;

namespace BE_QuanLiDiem.Repository.Abstract
{
    public interface ILopCnRP
    {
        Task<List<LopChuyenNganh>> GetAllLcnAsync();
        Task<LopChuyenNganh> GetLcnByIdAsync(Guid MaLCN);
        Task<LopChuyenNganh> CreateLcnAsync(AddLopCnDTO addLopCnDTO);
        Task<LopChuyenNganh> UpdateLcnAsync(UpdateLopCnDTO updateLopCnDTO, Guid MaLCN);
        Task<LopChuyenNganh> DeleteLcnAsync(Guid MaLCN);
    }
}
