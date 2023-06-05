namespace Villa_API.Models
{
    public class Password
    {
        public int Id { get; set; }
        public string Pass { get; set; }

        public int IdUsuario { get; set; }

        public virtual User User { get; set; }  
    }
}
