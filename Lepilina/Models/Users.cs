namespace Lepilina.Models
{
    public class Users
    {
        public int users_id { get; set; }
        public string sername { get; set; }
        public string names { get; set; }
        public string patronymic { get; set; }
        public int? position_id { get; set; }

        public Position Position { get; set; }
    }
}
