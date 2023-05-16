using System.ComponentModel.DataAnnotations;

namespace Villa_API.Controllers.Dto
{
    
    public class VillaDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTime? Created { get; set; }
    }
}
