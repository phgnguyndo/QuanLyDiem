using BE_QuanLiDiem.Data;
using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.BoMon;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BE_QuanLiDiem.Repository.Implement
{
    public class BoMonRP : IBoMonRP
    {
        private readonly QL_DiemDbContext dbContext;
        public BoMonRP(QL_DiemDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        public async Task<BoMon> CreateBoMonAsync(AddBoMonDTO addBoMonDTO)
        {
            var newBM = new BoMon
            {
                TenBM = addBoMonDTO.TenBM,
                KhoaId = addBoMonDTO.KhoaId
            };
            var exist = await dbContext.BoMons.FirstOrDefaultAsync(x => x.TenBM == addBoMonDTO.TenBM);
            if (exist != null) { throw new InvalidOperationException("Bo mon existed."); }
            dbContext.BoMons.Add(newBM);
            await dbContext.SaveChangesAsync();
            return newBM;
        }

        public async Task<BoMon> DeleteBoMonAsync(Guid MaBM)
        {
            var exist = await dbContext.BoMons.FirstOrDefaultAsync(x => x.MaBM == MaBM);
            if (exist == null) { return null; }
            dbContext.BoMons.Remove(exist);
            await dbContext.SaveChangesAsync();
            return exist;
        }

        public async Task<List<BoMon>> GetAllBoMonAsync(int pageNumber, int pageSize)
        {
            var skipResults = (pageNumber - 1) * pageSize;
            return await dbContext.BoMons.Include("Khoa").Skip(skipResults).Take(pageSize).ToListAsync();
        }

        public async Task<BoMon> GetBoMonByIdAsync(Guid MaBM)
        {
            var exist = await dbContext.BoMons.FirstOrDefaultAsync(x => x.MaBM == MaBM);
            if (exist == null) { return null; }
            return exist;
        }

        public async Task<List<BoMon>> GetBoMonByIdKhoaAsync(Guid MaKhoa)
        {
            var exist = await dbContext.BoMons.Where(x => x.KhoaId == MaKhoa).ToListAsync();
            if (exist == null) { return null; }
            return exist;
        }

        public async Task<BoMon> UpdateBoMonAsync(UpdateBoMonDTO updateBoMonDTO, Guid MaBM)
        {
            var exist = await dbContext.BoMons.FirstOrDefaultAsync(x => x.MaBM == MaBM);
            if (exist == null) { return null; }
            exist.TenBM = updateBoMonDTO.TenBM;
            exist.KhoaId=updateBoMonDTO.KhoaId;
            await dbContext.SaveChangesAsync();
            return exist;
        }
    }
}
