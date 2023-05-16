using Villa_API.Controllers.Dto;

namespace Villa_API.Data
{
    public class VillaStore
    {
        public static List<VillaDto> GetVillas() { return new List<VillaDto> { new VillaDto { Id = 1, Name = "Villa1" } }; }
    }
}
