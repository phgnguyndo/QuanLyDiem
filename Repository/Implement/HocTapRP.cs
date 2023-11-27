using BE_QuanLiDiem.Data;
using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.HocTap;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BE_QuanLiDiem.Repository.Implement
{
    public class HocTapRP : IHocTapRP
    {
        private QL_DiemDbContext dbContext;

        public HocTapRP(QL_DiemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<HocTap> CreateHocTapAsync(AUHocTapDTO aUHocTapDTO)
        {
            var newHocTap = new HocTap
            {
                HocVienId = aUHocTapDTO.HocVienId,
                LopHocPhanId = aUHocTapDTO.LopHocPhanId
            };
            dbContext.HocTaps.Add(newHocTap);
            await dbContext.SaveChangesAsync();
            return newHocTap;
        }

        public async Task<HocTap> DeleteHocTapAsync(Guid MaHocTap)
        {
            var ht= await dbContext.HocTaps.FirstOrDefaultAsync(x => x.MaHocTap == MaHocTap);
            if (ht == null) return null;
            dbContext.HocTaps.Remove(ht);   
            await dbContext.SaveChangesAsync();
            return ht;
        }

        public async Task<List<HocTap>> GetAllHocTapAsync()
        {
            return await dbContext.HocTaps.ToListAsync();
        }

        public async Task<List<HocTap>> GetHocTapByIdHVAsync(string MaHV)
        {
            var ht= await dbContext.HocTaps.Where(x=>x.HocVienId==MaHV).ToListAsync();
            if (ht == null) return null;
            return ht;
        }

        public async Task<HocTap> UpdateHocTapAsync(AUHocTapDTO aUHocTapDTO, Guid MaHocTap)
        {
            var ht = await dbContext.HocTaps.FirstOrDefaultAsync(x => x.MaHocTap == MaHocTap);
            if (ht == null) return null;
            ht.HocVienId=aUHocTapDTO.HocVienId;
            ht.LopHocPhanId = aUHocTapDTO.LopHocPhanId;
            await dbContext.SaveChangesAsync();
            return ht;
        }
    }
}
