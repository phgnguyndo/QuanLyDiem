using BE_QuanLiDiem.Data;
using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.HocVien;
using BE_QuanLiDiem.Models.DTO.LCN;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

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
            if (addLopCnDTO.file != null)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/ImageLCN", addLopCnDTO.file.FileName);
                using (FileStream ms = new FileStream(filePath, FileMode.Create))
                {
                    await addLopCnDTO.file.CopyToAsync(ms);
                }
                var pathImage = Path.Combine("ImageLCN", addLopCnDTO.file.FileName);
                newLCN.AnhLCN = pathImage;
            }
            var exist = await dbContext.LopChuyenNganhs.FirstOrDefaultAsync(x => x.TenLopChuyenNganh == addLopCnDTO.TenLopChuyenNganh);
            if (exist != null) { throw new InvalidOperationException("LCN with the same name already exists."); }
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

        public async Task<List<LopChuyenNganh>> GetLcnByIdDaiDoiAsync(Guid MaDaiDoi)
        {
            var listLCN = await dbContext.LopChuyenNganhs.Where(x=>x.DaiDoiId==MaDaiDoi).ToListAsync();
            if (listLCN == null) return null;
            return listLCN;
        }

        public async Task<LopChuyenNganh> UpdateLcnAsync(UpdateLopCnDTO updateLopCnDTO, Guid MaLCN)
        {
            var exist = await dbContext.LopChuyenNganhs.FirstOrDefaultAsync(x => x.MaLopChuyenNganh == MaLCN);
            if (exist == null) return null;
            //var exist1 = await dbContext.LopChuyenNganhs.FirstOrDefaultAsync(z => z.TenLopChuyenNganh == updateLopCnDTO.TenLopChuyenNganh);
            //if (exist1 != null) { throw new InvalidOperationException("LCN with the same name already exists."); }
            exist.DaiDoiId=updateLopCnDTO.DaiDoiId;
            exist.TenLopChuyenNganh = updateLopCnDTO.TenLopChuyenNganh;
            exist.SoHV=updateLopCnDTO.SoHV;

            if (updateLopCnDTO.file != null)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Images", updateLopCnDTO.file.FileName);
                using (FileStream ms = new FileStream(filePath, FileMode.Create))
                {
                    await updateLopCnDTO.file.CopyToAsync(ms);
                }
                var pathImage = Path.Combine("Images", updateLopCnDTO.file.FileName);
                exist.AnhLCN = pathImage;
            }
            await dbContext.SaveChangesAsync();
            return exist;
        }
    }
}
