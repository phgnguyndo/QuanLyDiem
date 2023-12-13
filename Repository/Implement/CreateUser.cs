using BE_QuanLiDiem.Constans;
using BE_QuanLiDiem.Data;
using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.User;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

namespace BE_QuanLiDiem.Repository.Implement
{
    public class CreateUser:ICreateUser
    {
        private QL_DiemDbContext context;

        public CreateUser(QL_DiemDbContext context)
        {
            this.context=context;
        }

        public async Task<tbl_user> Register1(tblUserDTO userDTO)
        { 
            if(!UserRole.IsUserRole(userDTO.Role))
            {
                throw new Exception("Invalid Role!");
            }
            var user = new tbl_user
            {
                Code=userDTO.Code,
                //MaDaiDoi=userDTO.MaDaiDoi,
                //MaHV=userDTO.MaHV,
                MaDaiDoi=userDTO.MaDaiDoi,
                MaHV=userDTO.MaHV,
                Password= BCrypt.Net.BCrypt.HashPassword(userDTO.Password),
                Role =userDTO.Role
            };
            var exist=await context.tbl_user.FirstOrDefaultAsync(x=> x.Code==userDTO.Code);
            if(exist!=null) { throw new InvalidOperationException("username existed."); }
            context.tbl_user.Add(user);
            await context.SaveChangesAsync();
            return user;

        }
    }
}
