namespace WebApp.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual Account Account { get; set; }
    }
} 
