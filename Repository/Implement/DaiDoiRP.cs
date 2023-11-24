using BE_QuanLiDiem.Data;
using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.DaiDoi;
using BE_QuanLiDiem.Models.DTO.HocVien;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.AspNetCore.Http.HttpResults;
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
                TenDaiDoi = aUdaiDoiDTO.TenDaiDoi,
                DaiDoiTruong=aUdaiDoiDTO.DaiDoiTruong,
                QuanSo=aUdaiDoiDTO.QuanSo
            };
            if (aUdaiDoiDTO.file != null)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/ImageDaiDoi", aUdaiDoiDTO.file.FileName);
                using (FileStream ms = new FileStream(filePath, FileMode.Create))
                {
                    await aUdaiDoiDTO.file.CopyToAsync(ms);
                }
                var pathImage = Path.Combine("ImageDaiDoi", aUdaiDoiDTO.file.FileName);
                newDaiDoi.AnhDaiDoi = pathImage;
            }
            var exist= await dbContext.DaiDois.FirstOrDefaultAsync(x=>x.TenDaiDoi==newDaiDoi.TenDaiDoi);
            if (exist!=null)
            {
                throw new InvalidOperationException("Dai Doi with the same name already exists.");
            }
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
            exist.DaiDoiTruong = aUdaiDoiDTO.DaiDoiTruong;
            exist.QuanSo=aUdaiDoiDTO.QuanSo;

            if (aUdaiDoiDTO.file != null)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Images", aUdaiDoiDTO.file.FileName);
                using (FileStream ms = new FileStream(filePath, FileMode.Create))
                {
                    await aUdaiDoiDTO.file.CopyToAsync(ms);
                }
                var pathImage = Path.Combine("Images", aUdaiDoiDTO.file.FileName);
                exist.AnhDaiDoi = pathImage;
            }
            await dbContext.SaveChangesAsync();
            return exist;
        }
    }
}
