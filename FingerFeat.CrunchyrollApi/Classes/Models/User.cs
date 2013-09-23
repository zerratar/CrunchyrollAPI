namespace FingerFeat.CrunchyrollApi.Classes.Models
{
    public class User
    {
        public User(string username, string email, string premium)
        {
            Username = username;
            Email = email;
            Premium = premium;
        }

        public string Username { get; set; }

        public string Premium { get; set; }

        public string Email
        {
            get;
            set;
        }
    }
}
