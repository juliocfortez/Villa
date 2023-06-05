namespace Villa_API.Models
{
    public class Verb
    {
        public int Id { get; set; }
        public string Infinitive { get; set; }

        public string? InfinitivePronunciation { get; set; }

        public string Past { get; set; }

        public string? PastPronunciation { get; set; }

        public string PastParticiple { get; set; }

        public string? PastParticiplePronunciation { get; set; }

        public bool IsRegular { get; set; }

        public int IdUsuario { get; set; }

        public virtual User User { get; set;}


    }
}
