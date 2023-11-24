using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.User;

namespace BE_QuanLiDiem.Repository.Abstract
{
    public interface ICreateUser
    {
        Task<tbl_user> Register1(tblUserDTO userDTO);
    }
}
