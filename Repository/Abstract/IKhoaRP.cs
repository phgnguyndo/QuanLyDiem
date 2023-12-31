﻿using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.Khoa;

namespace BE_QuanLiDiem.Repository.Abstract
{
    public interface IKhoaRP
    {
        Task<List<Khoa>> GetAllKhoaAsync(int pageNumber = 1, int pageSize = 10);
        Task<Khoa> GetKhoaByIdAsync(Guid MaKhoa);
        Task<Khoa> CreateKhoaAsync(AddKhoaDTO addKhoaDTO);
        Task<Khoa> UpdateKhoaAsync(UpdateKhoaDTO updateKhoaDTO, Guid MaKhoa);
        Task<Khoa> DeleteKhoaAsync(Guid MaKhoa);
    }
}
