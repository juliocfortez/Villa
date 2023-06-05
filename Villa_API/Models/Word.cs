namespace Villa_API.Models
{
    public class Word
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Pronunciation { get; set; }

        public string Meaning { get; set; }

        public int IdTypeWord { get; set; }
        public int IdUsuario { get; set; }

        public virtual User User { get; set; }

        public virtual TypeWord TypeWord { get; set; }
    }
}
