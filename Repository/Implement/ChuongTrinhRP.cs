using BE_QuanLiDiem.Data;
using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.ChuongTrinh;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BE_QuanLiDiem.Repository.Implement
{
    public class ChuongTrinhRP : IChuongTrinhRP
    {
        private QL_DiemDbContext dbContext;

        public ChuongTrinhRP(QL_DiemDbContext dbContext)
        {
            this.dbContext=dbContext;
        }

        public async Task<ChuongTrinh> CreateChuongTrinhAsync(AUChuongTrinhDTO aUChuongTrinhDTO)
        {
            var newChuongTrinh = new ChuongTrinh
            {
                HocPhanId = aUChuongTrinhDTO.HocPhanId,
                LopChuyenNganhId = aUChuongTrinhDTO.LopChuyenNganhId
            };
            dbContext.ChuongTrinhs.AddAsync(newChuongTrinh);
            await dbContext.SaveChangesAsync();
            return newChuongTrinh;
        }

        public async Task<ChuongTrinh> DeleteCHuongTrinhAsync(Guid MaCT)
        {
            var ct= await dbContext.ChuongTrinhs.FirstOrDefaultAsync(x=>x.MaChuongTrinh==MaCT);
            if (ct == null) return null;
            dbContext.ChuongTrinhs.Remove(ct);
            await dbContext.SaveChangesAsync();
            return ct;
        }

        public async Task<List<ChuongTrinh>> GetAllChuongTringAsync()
        {
            return await dbContext.ChuongTrinhs.ToListAsync();
        }

        public async Task<List<ChuongTrinh>> GetChuongTrinhnByIdLCNAsync(Guid MaLCN)
        {
            var chuongTrinhs=await dbContext.ChuongTrinhs.Where(x=>x.LopChuyenNganhId==MaLCN).ToListAsync();
            if (chuongTrinhs == null) return null;
            return chuongTrinhs;
        }

        public async Task<ChuongTrinh> UpdateChuongTrinhAsync(AUChuongTrinhDTO aUChuongTrinhDTO, Guid MaCT)
        {
            var ct = await dbContext.ChuongTrinhs.FirstOrDefaultAsync(x => x.MaChuongTrinh == MaCT);
            if (ct == null) return null;
            ct.HocPhanId=aUChuongTrinhDTO.HocPhanId;
            ct.LopChuyenNganhId = aUChuongTrinhDTO.LopChuyenNganhId;
            await dbContext.SaveChangesAsync();
            return ct;
        }
    }
}
