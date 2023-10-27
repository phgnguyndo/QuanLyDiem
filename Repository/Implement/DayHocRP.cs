using BE_QuanLiDiem.Data;
using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.DayHoc;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BE_QuanLiDiem.Repository.Implement
{
    public class DayHocRP : IDayHocRP
    {
        private QL_DiemDbContext dbContext;

        public DayHocRP(QL_DiemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<DayHoc> CreateDayHocAsync(DayHocDTO dayHocDTO)
        {
            var dayHoc = new DayHoc
            {
                GiangVienId = dayHocDTO.GiangVienId,
                LopHocPhanId = dayHocDTO.LopHocPhanId
            };
            dbContext.DayHocs.Add(dayHoc);  
            await dbContext.SaveChangesAsync();
            return dayHoc;
        }

        public async Task<DayHoc> DeleteDayHocAsync(Guid MaDayHoc)
        {
            var exist = await dbContext.DayHocs.FirstOrDefaultAsync(x => x.MaDayHoc==MaDayHoc);
            if (exist == null) return null;
            dbContext.DayHocs.Remove(exist);
            await dbContext.SaveChangesAsync();
            return exist;
        }

        public async Task<List<DayHoc>> GetAllDayHocAsync()
        {
            return await dbContext.DayHocs.ToListAsync();
        }

        public async Task<DayHoc> GetDayHocByIdAsync(Guid MaDayHoc)
        {
            var exist = await dbContext.DayHocs.FirstOrDefaultAsync(x => x.MaDayHoc==MaDayHoc);
            if (exist == null) return null;
            return exist;
        }

        public async Task<DayHoc> UpdateDayHocAsync(DayHocDTO dayHocDTO, Guid MaDayHoc)
        {
            var exist = await dbContext.DayHocs.FirstOrDefaultAsync(x => x.MaDayHoc == MaDayHoc);
            if (exist == null) return null;
            exist.LopHocPhanId = dayHocDTO.LopHocPhanId;
            exist.GiangVienId= dayHocDTO.GiangVienId;
            await dbContext.SaveChangesAsync();
            return exist;

        }
    }
}
