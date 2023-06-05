namespace Villa_API.Models
{
    public class Phrase
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public string Meaning { get; set; }

        public int IdUsuario { get; set; }

        public virtual User User { get; set; }
    }
}
