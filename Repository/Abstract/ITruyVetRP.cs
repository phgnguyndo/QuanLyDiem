using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.BoMon;
using BE_QuanLiDiem.Models.DTO.TruyVet;

namespace BE_QuanLiDiem.Repository.Abstract
{
    public interface ITruyVetRP
    {
        Task<List<TruyVet>> GetAllTruyVetAsync();
        Task<TruyVet> CreateTruyVetAsync(AddTruyVetDTO addTruyVetDTO);
        Task<TruyVet> UpdateTruyVetAsync(UpdateTruyVetDTO updateTruyVetDTO);
    }
}
