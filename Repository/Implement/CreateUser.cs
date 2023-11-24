using BE_QuanLiDiem.Constans;
using BE_QuanLiDiem.Data;
using BE_QuanLiDiem.Models.Domain;
using BE_QuanLiDiem.Models.DTO.User;
using BE_QuanLiDiem.Repository.Abstract;

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
                Name=userDTO.Name?? userDTO.Code,
                //Email=userDTO.Email??null,
                //Phone=userDTO.Phone ?? null,
                IsActive=userDTO.IsActive ?? true,
                Password=userDTO.Password,
                Role=userDTO.Role
            };
            context.tbl_user.Add(user);
            await context.SaveChangesAsync();
            return user;

        }
    }
}
