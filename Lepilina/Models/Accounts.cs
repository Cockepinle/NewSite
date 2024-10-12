namespace Lepilina.Models
{
    public class Accounts
    {
        public int accounts_id { get; set; }
        public string logins { get; set; }
        public string passwords { get; set; }
        public int? users_id { get; set; }

        public Users Users { get; set; }
    }
}
