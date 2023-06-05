namespace Villa_API.Models
{
    public class TypeWord
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<Word> Words { get; set; }
    }
}
