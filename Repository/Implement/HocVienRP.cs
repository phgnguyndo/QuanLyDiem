using BE_QuanLiDiem.Data;
using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.HocVien;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BE_QuanLiDiem.Repository.Implement
{
    public class HocVienRP : IHocVienRP
    {
        private QL_DiemDbContext dbContext;

        public HocVienRP(QL_DiemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<HocVien> CreateHocVienAsync(AddHocVienDTO addHocVienDTO)
        {
            var newHV = new HocVien
            {
                MaHV = addHocVienDTO.MaHV,
                LopChuyenNganhId = addHocVienDTO.LopChuyenNganhId,
                TenHV = addHocVienDTO.TenHV,
                NgaySinh = addHocVienDTO.NgaySinh,
                GioiTinh = addHocVienDTO.GioiTinh,
                QueQuan = addHocVienDTO.QueQuan,
                CapBac = addHocVienDTO.CapBac
            };
            if (addHocVienDTO.file != null)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Images", addHocVienDTO.file.FileName);
                using (FileStream ms = new FileStream(filePath, FileMode.Create))
                {
                    await addHocVienDTO.file.CopyToAsync(ms);
                }
                var pathImage = Path.Combine("Images", addHocVienDTO.file.FileName);
                newHV.AnhHV = pathImage;
            }
            dbContext.HocViens.Add(newHV);
            await dbContext.SaveChangesAsync(); 
            return newHV;
        }

        public async Task<HocVien> DeleteHocVienAsync(string MaHV)
        {
            var exist= await dbContext.HocViens.FirstOrDefaultAsync(x=>x.MaHV==MaHV);
            if (exist == null) return null;
            dbContext.HocViens.Remove(exist);
            await dbContext.SaveChangesAsync();
            return exist;
        }

        public async Task<List<HocVien>> GetAllHocVienAsync()
        {
            return await dbContext.HocViens.ToListAsync();
        }

        public async Task<HocVien> GetHocVienByIdAsync(string MaHV)
        {
            var exist = await dbContext.HocViens.FirstOrDefaultAsync(x => x.MaHV == MaHV);
            if (exist == null) return null;
            return exist;
        }

        public async Task<List<HocVien>> GetHocVienByIdLopAsync(Guid MaLop)
        {
            var dsHV=await dbContext.HocViens.Where(x=>x.LopChuyenNganhId == MaLop).ToListAsync();
            if (dsHV == null) { return null; }
            return dsHV;
        }

        public async Task<HocVien> UpdateHocVienAsync(UpdateHocVienDTO updateHocVienDTO, string MaHV)
        {
            var exist = await dbContext.HocViens.FirstOrDefaultAsync(x => x.MaHV == MaHV);
            if (exist == null) return null;
            exist.LopChuyenNganhId = updateHocVienDTO.LopChuyenNganhId;
            exist.TenHV=updateHocVienDTO.TenHV;
            exist.GioiTinh=updateHocVienDTO.GioiTinh;
            exist.NgaySinh=updateHocVienDTO.NgaySinh;
            exist.QueQuan = updateHocVienDTO.QueQuan;
            exist.CapBac = updateHocVienDTO.CapBac;
            if (updateHocVienDTO.file != null)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Images", updateHocVienDTO.file.FileName);
                using (FileStream ms = new FileStream(filePath, FileMode.Create))
                {
                    await updateHocVienDTO.file.CopyToAsync(ms);
                }
                var pathImage = Path.Combine("Images", updateHocVienDTO.file.FileName);
                exist.AnhHV = pathImage;
            }
            await dbContext.SaveChangesAsync();
            return exist;
        }
    }
}
