namespace Villa_API.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Rol { get; set; }

        public virtual IEnumerable<User> Users { get; set;}
    }
}
