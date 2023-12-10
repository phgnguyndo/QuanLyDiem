using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.BoMon;
using BE_QuanLiDiem.Models.DTO.GiangVIen;
using System.Threading.Tasks;

namespace BE_QuanLiDiem.Repository.Abstract
{
    public interface IGiangVienRP
    {
        Task<List<GiangVien>> GetAllGiangVienAsync();
        Task<List<GiangVien>> GetGiangVienBoMonAsync(Guid MaBM);
        Task<GiangVien> GetGiangVienByIdAsync(Guid MaGV);
        Task<GiangVien> CreateGiangVienAsync(AddGiangVienDTO addGiangVienDTO);
        Task<GiangVien> UpdateGiangVienAsync(UpdateGiangVienDTO updateGiangVienDTO, Guid MaGV);
        Task<GiangVien> DeleteGiangVienAsync(Guid MaGV);
    }
}
