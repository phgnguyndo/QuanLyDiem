using BE_QuanLiDiem.Data;
using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.DTB;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BE_QuanLiDiem.Repository.Implement
{
    public class DtbRP : IDtbRp
    {
        private QL_DiemDbContext dbContext;

        public DtbRP(QL_DiemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<DiemTrungBinh> CreateDTBAsync(AddDTBdto addDTBdto)
        {
            var newDTB = new DiemTrungBinh
            {
                HocVienId = addDTBdto.HocVienId,
                DTB = addDTBdto.DTB
            };
            dbContext.DiemTrungBinhs.Add(newDTB);
            await dbContext.SaveChangesAsync(); 
            return newDTB;
        }

        public Task<DiemTrungBinh> DeleteDTBAsync(int MaDTB)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DiemTrungBinh>> GetAllDTBAsync()
        {
            return await dbContext.DiemTrungBinhs.Include("HocVien").ToListAsync();
        }

        public Task<List<DiemTrungBinh>> GetDTBByIdHVAsync(string MaHV)
        {
            throw new NotImplementedException();
        }

        public async Task<DiemTrungBinh> UpdateDTBAsync(UpdateDTBdto updateDTBdto, int hocKy, string MaHV)
        {
            var exist = await dbContext.DiemTrungBinhs.FirstOrDefaultAsync(x => x.HocVienId == MaHV & x.HocKy==hocKy);
            if(exist == null) { return null; }
            //exist.HocVienId = updateDTBdto.HocVienId;
            //exist.HocKy=updateDTBdto.HocKy;
            exist.DTB=updateDTBdto.DTB;
            exist.TongTC=updateDTBdto.TongTC;
            await dbContext.SaveChangesAsync();
            return exist;
        }
    }
}
