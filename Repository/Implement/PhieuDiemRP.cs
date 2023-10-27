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
            var newPhieuDiem = new PhieuDiem
            {
                LopHocPhanId=addPhieuDiemDTO.LopHocPhanId,
                HocVienId=addPhieuDiemDTO.HocVienId,
                DiemCC=addPhieuDiemDTO.DiemCC,
                DiemTX=addPhieuDiemDTO.DiemTX,
                DiemThi=addPhieuDiemDTO.DiemThi,
                //DiemTBM=addPhieuDiemDTO.DiemTBM,
                //DiemTK_HocKy=addPhieuDiemDTO.DiemTK_HocKy,
                //DiemTK_Nam=addPhieuDiemDTO.DiemTK_Nam,
                DiemThiLai=addPhieuDiemDTO.DiemThiLai,
                LanThi=addPhieuDiemDTO.LanThi,
                //DiemChu=addPhieuDiemDTO.DiemChu
            };
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
            return await dbContext.PhieuDiems.ToListAsync();
        }

        public async Task<PhieuDiem> GetPhieuDiemByIdAsync(Guid MaPhieuDiem)
        {
            var exist = await dbContext.PhieuDiems.FirstOrDefaultAsync(x => x.MaPhieuDiem == MaPhieuDiem);
            if (exist == null) return null;
            return exist;
        }

        public async Task<PhieuDiem> UpdatePhieuDiemAsync(UpdatePhieuDiemDTO updatePhieuDiemDTO, Guid MaPhieuDiem)
        {
            var exist = await dbContext.PhieuDiems.FirstOrDefaultAsync(x => x.MaPhieuDiem == MaPhieuDiem);
            if (exist == null) return null;
            exist.LopHocPhanId=updatePhieuDiemDTO.LopHocPhanId;
            exist.HocVienId = updatePhieuDiemDTO.HocVienId;
            exist.DiemCC = updatePhieuDiemDTO.DiemCC;
            exist.DiemTX = updatePhieuDiemDTO.DiemTX;
            exist.DiemThi = updatePhieuDiemDTO.DiemThi;
            //exist.DiemTBM = updatePhieuDiemDTO.DiemTBM;
            //exist.DiemTK_HocKy = updatePhieuDiemDTO.DiemTK_HocKy;
            //exist.DiemTK_Nam = updatePhieuDiemDTO.DiemTK_Nam;
            exist.DiemThiLai = updatePhieuDiemDTO.DiemThiLai;
            exist.LanThi = updatePhieuDiemDTO.LanThi;
            //exist.DiemChu = updatePhieuDiemDTO.DiemChu;
            await dbContext.SaveChangesAsync();
            return exist;
        }
    }
}
