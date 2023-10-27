using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.BoMon;
using BE_QuanLiDiem.Models.DTO.DayHoc;

namespace BE_QuanLiDiem.Repository.Abstract
{
    public interface IDayHocRP
    {
        Task<List<DayHoc>> GetAllDayHocAsync();
        Task<DayHoc> GetDayHocByIdAsync(Guid MaDayHoc);
        Task<DayHoc> CreateDayHocAsync(DayHocDTO dayHocDTO);
        Task<DayHoc> UpdateDayHocAsync(DayHocDTO dayHocDTO, Guid MaDayHoc);
        Task<DayHoc> DeleteDayHocAsync(Guid MaDayHoc);
    }
}
