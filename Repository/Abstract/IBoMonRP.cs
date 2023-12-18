using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.BoMon;
using BE_QuanLiDiem.Models.DTO.Khoa;

namespace BE_QuanLiDiem.Repository.Abstract
{
    public interface IBoMonRP
    {
        Task<List<BoMon>> GetAllBoMonAsync(int pageNumber = 1, int pageSize = 10);
        Task<List<BoMon>> GetBoMonByIdKhoaAsync(Guid MaKhoa);
        Task<BoMon> GetBoMonByIdAsync(Guid MaBM);
        Task<BoMon> CreateBoMonAsync(AddBoMonDTO addBoMonDTO);
        Task<BoMon> UpdateBoMonAsync(UpdateBoMonDTO updateBoMonDTO, Guid MaBM);
        Task<BoMon> DeleteBoMonAsync(Guid MaBM);
    }
}
