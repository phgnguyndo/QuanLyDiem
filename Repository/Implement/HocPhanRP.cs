using BE_QuanLiDiem.Data;
using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.HocPhan;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BE_QuanLiDiem.Repository.Implement
{
    public class HocPhanRP : IHocPhanRP
    {
        private QL_DiemDbContext dbContext;

        public HocPhanRP(QL_DiemDbContext dbContext)
        {
            this.dbContext=dbContext;
        }
        public async Task<HocPhan> CreateHocPhanAsync(AddHocPhanDTO addHocPhanDTO)
        {
            var newHocPhan = new HocPhan
            {
                TenHocPhan = addHocPhanDTO.TenHocPhan,
                SoTiet = addHocPhanDTO.SoTiet,
                SoTC = addHocPhanDTO.SoTC,
                HocKy = addHocPhanDTO.HocKy,
                BoMonId = addHocPhanDTO.BoMonId
            };
            var exist = await dbContext.HocPhans.FirstOrDefaultAsync(x => x.TenHocPhan == addHocPhanDTO.TenHocPhan);
            if (exist != null) { throw new InvalidOperationException("HocPhan existed."); }
            dbContext.Add(newHocPhan);
            await dbContext.SaveChangesAsync();
            return newHocPhan;
        }

        public async Task<HocPhan> DeleteHocPhanAsync(Guid MaHocPhan)
        {
            var exist=await dbContext.HocPhans.FirstOrDefaultAsync(x=>x.MaHocPhan==MaHocPhan);
            if (exist == null) return null;
            dbContext.HocPhans.Remove(exist);
            await dbContext.SaveChangesAsync();
            return exist;
        }

        public async Task<List<HocPhan>> GetAllHocPhanAsync(int pageNumber, int pageSize)
        {
            var skipResults = (pageNumber - 1) * pageSize;
            return await dbContext.HocPhans.Include("BoMon").Skip(skipResults).Take(pageSize).ToListAsync();
        }

        public async Task<HocPhan> GetHocPhanByIdAsync(Guid MaHocPhan)
        {
            var exist=await dbContext.HocPhans.FirstOrDefaultAsync(x=>x.MaHocPhan==MaHocPhan);
            if (exist == null) return null;
            return exist;
        }

        public async Task<HocPhan> UpdateHocPhanAsync(UpdateHocPhanDTO updateHocPhanDTO, Guid MaHocPhan)
        {
            var exist = await dbContext.HocPhans.FirstOrDefaultAsync(x => x.MaHocPhan == MaHocPhan);
            if (exist == null) return null;
            exist.TenHocPhan=updateHocPhanDTO.TenHocPhan;
            exist.SoTiet = updateHocPhanDTO.SoTiet;
            exist.SoTC=updateHocPhanDTO.SoTC;
            exist.HocKy = updateHocPhanDTO.HocKy;
            exist.BoMonId = updateHocPhanDTO.BoMonId;
            await dbContext.SaveChangesAsync();
            return exist;
        }
    }
}
