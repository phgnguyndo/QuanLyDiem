using BE_QuanLiDiem.Data;
using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.DaiDoi;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BE_QuanLiDiem.Repository.Implement
{
    public class DaiDoiRP : IDaiDoiRP
    {
        private QL_DiemDbContext dbContext;

        public DaiDoiRP(QL_DiemDbContext dbContext)
        {
            this.dbContext=dbContext;
        }
        public async Task<DaiDoi> CreateDaiDoiAsync(AUdaiDoiDTO aUdaiDoiDTO)
        {
            var newDaiDoi = new DaiDoi
            {
                TenDaiDoi = aUdaiDoiDTO.TenDaiDoi
            };
            dbContext.DaiDois.Add(newDaiDoi);
            await dbContext.SaveChangesAsync();
            return newDaiDoi;
        }

        public async Task<DaiDoi> DeleteDaiDoiAsync(Guid MaDaiDoi)
        {
            var exist= await dbContext.DaiDois.FirstOrDefaultAsync(x=>x.MaDaiDoi==MaDaiDoi);
            if (exist==null) { return null; }
            dbContext.DaiDois.Remove(exist);
            await dbContext.SaveChangesAsync();
            return exist;
        }

        public async Task<List<DaiDoi>> GetAllDaiDoiAsync()
        {
            return await dbContext.DaiDois.ToListAsync();
        }

        public async Task<DaiDoi> GetDaiDoiByIdAsync(Guid MaDaiDoi)
        {
            var exist = await dbContext.DaiDois.FirstOrDefaultAsync(x => x.MaDaiDoi == MaDaiDoi);
            if (exist == null) { return null; }
            return exist;
        }

        public async Task<DaiDoi> UpdateDaiDoiAsync(AUdaiDoiDTO aUdaiDoiDTO, Guid MaDaiDoi)
        {
            var exist = await dbContext.DaiDois.FirstOrDefaultAsync(x => x.MaDaiDoi == MaDaiDoi);
            if (exist == null) { return null; }
            exist.TenDaiDoi=aUdaiDoiDTO.TenDaiDoi;
            await dbContext.SaveChangesAsync();
            return exist;
        }
    }
}
