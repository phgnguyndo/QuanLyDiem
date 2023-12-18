using BE_QuanLiDiem.Data;
using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.TruyVet;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BE_QuanLiDiem.Repository.Implement
{
    public class TruyVetRP : ITruyVetRP
    {
        private QL_DiemDbContext dbContext;

        public TruyVetRP(QL_DiemDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<TruyVet> CreateTruyVetAsync(AddTruyVetDTO addTruyVetDTO)
        {
            var newTV = new TruyVet
            {
                Username = addTruyVetDTO.Username,
                Role = addTruyVetDTO.Role,
                tgDangNhap = addTruyVetDTO.tgDangNhap,
                tgDangXuat = addTruyVetDTO.tgDangXuat
            };
            dbContext.TruyVets.Add(newTV);  
            await dbContext.SaveChangesAsync();
            return newTV;
        }

        public async Task<List<TruyVet>> GetAllTruyVetAsync()
        {
            return await dbContext.TruyVets.ToListAsync();
        }

        public Task<TruyVet> UpdateTruyVetAsync(UpdateTruyVetDTO updateTruyVetDTO)
        {
            throw new NotImplementedException();
        }
    }
}
