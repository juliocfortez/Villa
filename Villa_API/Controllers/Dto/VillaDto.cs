using System.ComponentModel.DataAnnotations;

namespace Villa_API.Controllers.Dto
{
    
    public class VillaDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Details { get; set; }
        public double Rate { get; set; }

        public int Sqtf { get; set; }

        public int Occupancy { get; set; }
        public string ImageUrl { get; set; }
        public string Amenity { get; set; }
    }
}
