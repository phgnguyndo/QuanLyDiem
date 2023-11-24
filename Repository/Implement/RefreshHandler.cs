using BE_QuanLiDiem.Data;
using BE_QuanLiDiem.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using BE_QuanLiDiem.Models.Domain;

namespace BE_QuanLiDiem.Repository.Implement
{
    public class RefreshHandler : IRefreshHandler
    {
        private QL_DiemDbContext context;

        public RefreshHandler(QL_DiemDbContext context)
        {
            this.context = context;
        }
        public async Task<string> GenerateToken(string username)
        {
            var randomnumber= new byte[32];
            using(var randomnumbergenerater=RandomNumberGenerator.Create())
            {
                randomnumbergenerater.GetBytes(randomnumber);
                string refreshToken=Convert.ToBase64String(randomnumber);
                var ExistToken= await this.context.tbl_RefreshToken.FirstOrDefaultAsync(x=>x.UserId==username);
                if(ExistToken != null)
                {
                    ExistToken.RefreshToken=refreshToken;   
                }
                else
                {
                    await this.context.tbl_RefreshToken.AddAsync(new tbl_RefreshToken
                    {
                        UserId = username,
                        TokenId = new Random().Next().ToString(),
                        RefreshToken=refreshToken 
                    }) ;

                }
                await this.context.SaveChangesAsync();
                return refreshToken;
            }
        }
    }
}
