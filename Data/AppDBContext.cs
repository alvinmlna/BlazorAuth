namespace BlazorAuth.Data
{
    public class AppDBContext
    {
        private static List<User> _users = new List<User>();

        public static bool SaveUser(User user)
        {
            bool isExist = _users.Any(x => x.Email == user.Email);
            if (!isExist)
            {
                _users.Add(user);
                return true;
            }
            return false;
        }

        public static User? Verify(string email, string password)
        {
            return _users.FirstOrDefault(x => x.Email.Equals(email, StringComparison.InvariantCultureIgnoreCase) && x.Password == password);
        }
    }

    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
