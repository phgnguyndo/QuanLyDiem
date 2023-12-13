using BE_QuanLiDiem.Data;
using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.LopHocPhan;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace BE_QuanLiDiem.Repository.Implement
{
    public class LopHocPhanRP : ILopHocPhanRP
    {
        private QL_DiemDbContext dbContext;

        public LopHocPhanRP(QL_DiemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<LopHocPhan> CreateLHPAsync(AddLopHocPhanDTO addLopHocPhanDTO)
        {
            var newLHP = new LopHocPhan
            {
                MaLopHocPhan= addLopHocPhanDTO.MaLopHocPhan,
                DiaDiem= addLopHocPhanDTO.DiaDiem,
                SoHV = addLopHocPhanDTO.SoHV,
                HocPhanId = addLopHocPhanDTO.HocPhanId
            };
            dbContext.LopHocPhans.Add(newLHP);
            await dbContext.SaveChangesAsync();
            return newLHP;
        }

        public async Task<LopHocPhan> DeleteLHPAsync(string MaLHP)
        {
            var exist= await dbContext.LopHocPhans.FirstOrDefaultAsync(x=>x.MaLopHocPhan==MaLHP);
            if (exist==null) { return null; }
            dbContext.LopHocPhans.Remove(exist);
            await dbContext.SaveChangesAsync();
            return exist;
        }

        public async Task<List<LopHocPhan>> GetAllLHPAsync()
        {
            return await dbContext.LopHocPhans.Include("HocPhan").ToListAsync();
        }

        public async Task<LopHocPhan> GetLHPByIdAsync(string MaLHP)
        {
            var exist = await dbContext.LopHocPhans.FirstOrDefaultAsync(x => x.MaLopHocPhan == MaLHP);
            if (exist == null) { return null; }
            return exist;
        }

        public async Task<LopHocPhan> UpdateLHPAsync(UpdateLopHocPhanDTO updateLopHocPhanDTO, string MaLHP)
        {
            var exist = await dbContext.LopHocPhans.FirstOrDefaultAsync(x => x.MaLopHocPhan == MaLHP);
            if (exist == null) { return null; }
            exist.DiaDiem=updateLopHocPhanDTO.DiaDiem;
            exist.SoHV=updateLopHocPhanDTO.SoHV;
            exist.HocPhanId = updateLopHocPhanDTO.HocPhanId;
            await dbContext.SaveChangesAsync();
            return exist;
        }
    }
}
