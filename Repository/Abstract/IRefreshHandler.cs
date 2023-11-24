namespace BE_QuanLiDiem.Repository.Abstract
{
    public interface IRefreshHandler
    {
        Task<string> GenerateToken(string username);
    }
}
