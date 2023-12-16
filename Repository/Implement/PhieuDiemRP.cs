using BE_QuanLiDiem.Data;
using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.PhieuDiem;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BE_QuanLiDiem.Repository.Implement
{
    public class PhieuDiemRP : IPhieuDiemRP
    {
        private QL_DiemDbContext dbContext;

        public PhieuDiemRP(QL_DiemDbContext dbContext)
        {
            this.dbContext=dbContext;
        }
        public async Task<PhieuDiem> CreatePhieuDiemAsync(AddPhieuDiemDTO addPhieuDiemDTO)
        {
            var a = (float)(addPhieuDiemDTO.DiemCC * 0.1 + addPhieuDiemDTO.DiemTX * 0.3 + addPhieuDiemDTO.DiemThi * 0.6);
            var newPhieuDiem = new PhieuDiem
            {
                HocPhanId=addPhieuDiemDTO.HocPhanId,
                HocVienId=addPhieuDiemDTO.HocVienId,
                DiemCC=addPhieuDiemDTO.DiemCC,
                DiemTX=addPhieuDiemDTO.DiemTX,
                DiemThi=addPhieuDiemDTO.DiemThi,
                DiemTBM = a
            };
            var exist = await dbContext.PhieuDiems.Where(x => x.HocPhanId == newPhieuDiem.HocPhanId && x.HocVienId==newPhieuDiem.HocVienId).ToListAsync();
            if (exist.Any()) { throw new InvalidOperationException("Phieu diem existed"); }
            dbContext.PhieuDiems.Add(newPhieuDiem);
            await dbContext.SaveChangesAsync();
            return newPhieuDiem;
        }

        public async Task<PhieuDiem> DeletePhieuDiemAsync(Guid MaPhieuDiem)
        {
            var exist= await dbContext.PhieuDiems.FirstOrDefaultAsync(x=>x.MaPhieuDiem==MaPhieuDiem);
            if (exist == null) return null;
            dbContext.PhieuDiems.Remove(exist);
            await dbContext.SaveChangesAsync();
            return exist;
        }

        public async Task<List<PhieuDiem>> GetAllPhieuDiemAsync()
        {
            return await dbContext.PhieuDiems.Include("HocPhan").ToListAsync();
        }

        public async Task<PhieuDiem> GetPhieuDiemByIdAsync(Guid MaPhieuDiem)
        {
            var exist = await dbContext.PhieuDiems.FirstOrDefaultAsync(x => x.MaPhieuDiem == MaPhieuDiem);
            if (exist == null) return null;
            return exist;
        }

        public async Task<List<PhieuDiem>> GetPhieuDiemByIdHVAsync(string MaHV)
        {
            var exist = await dbContext.PhieuDiems.Where(x => x.HocVienId == MaHV).Include("HocPhan").ToListAsync();
            if (exist == null) return null;
            return exist;
        }

        public async Task<PhieuDiem> UpdatePhieuDiemAsync(UpdatePhieuDiemDTO updatePhieuDiemDTO, Guid MaPhieuDiem)
        {
            var a = (float)(updatePhieuDiemDTO.DiemCC * 0.1 + updatePhieuDiemDTO.DiemTX * 0.3 + updatePhieuDiemDTO.DiemThi * 0.6);
            var exist = await dbContext.PhieuDiems.FirstOrDefaultAsync(x => x.MaPhieuDiem == MaPhieuDiem);
            if (exist == null) return null;
            exist.HocPhanId =updatePhieuDiemDTO.HocPhanId;
            exist.HocVienId = updatePhieuDiemDTO.HocVienId;
            exist.DiemCC = updatePhieuDiemDTO.DiemCC;
            exist.DiemTX = updatePhieuDiemDTO.DiemTX;
            exist.DiemThi = updatePhieuDiemDTO.DiemThi;
            exist.DiemTBM = a;
            await dbContext.SaveChangesAsync();
            return exist;
        }
    }
}
