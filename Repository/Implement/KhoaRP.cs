using BE_QuanLiDiem.Data;
using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.Khoa;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BE_QuanLiDiem.Repository.Implement
{
    public class KhoaRP : IKhoaRP
    {
        private readonly QL_DiemDbContext dbContext;
        public KhoaRP(QL_DiemDbContext dbContext)
        {
            this.dbContext = dbContext; 
        }

        public async Task<Khoa> CreateKhoaAsync(AddKhoaDTO addKhoaDTO)
        {
            var newKhoa = new Khoa
            {
                TenKhoa = addKhoaDTO.TenKhoa
            };
            var exist = await dbContext.Khoas.FirstOrDefaultAsync(x => x.TenKhoa == addKhoaDTO.TenKhoa);
            if (exist != null) { throw new InvalidOperationException("Khoa existed."); }
            dbContext.Khoas.Add(newKhoa);
            await dbContext.SaveChangesAsync();
            return newKhoa;
        }

        public async Task<Khoa> DeleteKhoaAsync(Guid MaKhoa)
        {
            var exist= await dbContext.Khoas.FirstOrDefaultAsync(x => x.MaKhoa == MaKhoa);
            if (exist == null) { return null; }
            dbContext.Khoas.Remove(exist);
            await dbContext.SaveChangesAsync();
            return exist;
        }

        public async Task<List<Khoa>> GetAllKhoaAsync()
        {
            return await dbContext.Khoas.ToListAsync();
        }

        public async Task<Khoa> GetKhoaByIdAsync(Guid MaKhoa)
        {
            var exist = await dbContext.Khoas.FirstOrDefaultAsync(x => x.MaKhoa == MaKhoa);
            if (exist == null) { return null; }
            return exist;
        }

        public async Task<Khoa> UpdateKhoaAsync(UpdateKhoaDTO updateKhoaDTO, Guid MaKhoa)
        {
            var exist = await dbContext.Khoas.FirstOrDefaultAsync(x => x.MaKhoa == MaKhoa);
            if (exist == null) { return null; }
            exist.TenKhoa=updateKhoaDTO.TenKhoa;
            await dbContext.SaveChangesAsync();
            return exist;
           
        }
    }
}
