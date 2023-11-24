namespace BE_QuanLiDiem.Constans
{
    public class UserRole
    {
        public const string ADMIN = "admin";
        public const string USER1 = "user1";
        public const string USER2 = "user2";
        public static bool IsUserRole(string role)
        {
            return role == USER2 || role == USER1 || role == ADMIN;
        }
    }
}
