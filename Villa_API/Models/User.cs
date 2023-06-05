namespace Villa_API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int IdPassword { get; set; }

        public int IdRole { get; set; }

        public virtual Role Role { get; set; }

        public virtual Password Password { get; set; }

        public virtual IEnumerable<Verb> Verbs { get; set;}

        public virtual IEnumerable<Phrase> Phrases { get; set; }

        public virtual IEnumerable<Word> Words { get; set; }
    }
}
