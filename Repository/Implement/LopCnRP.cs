using BE_QuanLiDiem.Data;
using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.LCN;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BE_QuanLiDiem.Repository.Implement
{
    public class LopCnRP : ILopCnRP
    {
        private QL_DiemDbContext dbContext;

        public LopCnRP(QL_DiemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<LopChuyenNganh> CreateLcnAsync(AddLopCnDTO addLopCnDTO)
        {
            var newLCN = new LopChuyenNganh
            {
                DaiDoiId = addLopCnDTO.DaiDoiId,
                TenLopChuyenNganh = addLopCnDTO.TenLopChuyenNganh,
                SoHV = addLopCnDTO.SoHV
            };
            dbContext.LopChuyenNganhs.Add(newLCN);
            await dbContext.SaveChangesAsync();
            return newLCN;
        }

        public async Task<LopChuyenNganh> DeleteLcnAsync(Guid MaLCN)
        {
            var exist=await dbContext.LopChuyenNganhs.FirstOrDefaultAsync(x=>x.MaLopChuyenNganh==MaLCN);
            if (exist == null) return null;
            dbContext.LopChuyenNganhs.Remove(exist);
            await dbContext.SaveChangesAsync();
            return exist;
        }

        public async Task<List<LopChuyenNganh>> GetAllLcnAsync()
        {
            return await dbContext.LopChuyenNganhs.ToListAsync();
        }

        public async Task<LopChuyenNganh> GetLcnByIdAsync(Guid MaLCN)
        {
            var exist = await dbContext.LopChuyenNganhs.FirstOrDefaultAsync(x => x.MaLopChuyenNganh == MaLCN);
            if (exist == null) return null;
            return exist;
        }

        public async Task<LopChuyenNganh> UpdateLcnAsync(UpdateLopCnDTO updateLopCnDTO, Guid MaLCN)
        {
            var exist = await dbContext.LopChuyenNganhs.FirstOrDefaultAsync(x => x.MaLopChuyenNganh == MaLCN);
            if (exist == null) return null;
            exist.DaiDoiId=updateLopCnDTO.DaiDoiId;
            exist.TenLopChuyenNganh = updateLopCnDTO.TenLopChuyenNganh;
            exist.SoHV=updateLopCnDTO.SoHV;
            await dbContext.SaveChangesAsync();
            return exist;
        }
    }
}
