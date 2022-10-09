namespace DataAccess.Entity
{
    public class User : BaseEntity
    {

       
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string Email{ get; set; }

    }
}
