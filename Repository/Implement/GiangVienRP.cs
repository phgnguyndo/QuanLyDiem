using BE_QuanLiDiem.Data;
using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.GiangVIen;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BE_QuanLiDiem.Repository.Implement
{
    public class GiangVienRP : IGiangVienRP
    {
        private readonly QL_DiemDbContext dbContext;
        public GiangVienRP(QL_DiemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<GiangVien> CreateGiangVienAsync(AddGiangVienDTO addGiangVienDTO)
        {
            var newGV = new GiangVien
            { 
                TenGV = addGiangVienDTO.TenGV,
                sdt = addGiangVienDTO.sdt,
                BoMonId = addGiangVienDTO.BoMonId
            };
            dbContext.GiangViens.AddAsync(newGV);
            await dbContext.SaveChangesAsync();
            return newGV;
        }

        public async Task<GiangVien> DeleteGiangVienAsync(Guid MaGV)
        {
            var exist=await dbContext.GiangViens.FirstOrDefaultAsync(x=>x.MaGV==MaGV);
            if(exist==null) { return null; }
            dbContext.GiangViens.Remove(exist);
            await dbContext.SaveChangesAsync();
            return exist;
        }

        public async Task<List<GiangVien>> GetAllGiangVienAsync()
        {
            return await dbContext.GiangViens.ToListAsync();
        }

        public async Task<GiangVien> GetGiangVienByIdAsync(Guid MaGV)
        {
            var exist = await dbContext.GiangViens.FirstOrDefaultAsync(x => x.MaGV == MaGV);
            if (exist == null) { return null; }
            return exist;
        }

        public async Task<GiangVien> UpdateGiangVienAsync(UpdateGiangVienDTO updateGiangVienDTO, Guid MaGV)
        {
            var exist = await dbContext.GiangViens.FirstOrDefaultAsync(x => x.MaGV == MaGV);
            if (exist == null) { return null; }
            exist.TenGV=updateGiangVienDTO.TenGV;
            exist.sdt=updateGiangVienDTO.sdt;
            exist.BoMonId = updateGiangVienDTO.BoMonId;
            await dbContext.SaveChangesAsync();
            return exist;
        }
    }
}
