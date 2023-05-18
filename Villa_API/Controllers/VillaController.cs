using Microsoft.AspNetCore.Mvc;
using Villa_API.Controllers.Dto;
using Villa_API.Data;

namespace Villa_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {

        public VillaController() { }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {
            return Ok(VillaStore.GetVillas());
        }
    

        [HttpGet("{id:int}",Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDto> GetVilla(int id)
        {
            if(id==0) return BadRequest();
            var villa = VillaStore.GetVillas().FirstOrDefault(x=>x.Id==id);
            if(villa == null) return NotFound();
            else return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDto> CreateVilla([FromBody]VillaDto villa) {
            if(VillaStore.GetVillas().Any(x=>x.Name.ToLower() == villa.Name.ToLower())) {
                ModelState.AddModelError("Name","Esta Villa ya existe");
                return BadRequest(ModelState);
            }
            if(villa == null) return BadRequest();
            if (villa.Id > 0) return StatusCode(StatusCodes.Status500InternalServerError);
            villa.Id = VillaStore.GetVillas().OrderByDescending(x => x.Id).FirstOrDefault().Id + 1;
            VillaStore.GetVillas().Add(villa);
            return CreatedAtRoute("GetVilla", new {id=villa.Id}, villa);
        }

        [HttpDelete("{id:int}",Name = "DeleteVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteVilla(int id)
        {
            if (id <= 0) return BadRequest();
            var villa = VillaStore.GetVillas().FirstOrDefault(x=>x.Id==id);
            if(villa == null) return NotFound();
            VillaStore.GetVillas().Remove(villa);
            return NoContent();
        }

        [HttpPut("{id:int}", Name = "UpdateVilla")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult UpdateVilla(int id, [FromBody] VillaDto villaDto)
        {
            if (villaDto.Id != 0)
            {
                ModelState.AddModelError("Id", "El Id no puede ser distinto de 0");
                return BadRequest(ModelState);
            }
            var villa = VillaStore.GetVillas().FirstOrDefault(x => x.Id == id);
            if (villa == null) return NotFound();
            villa = villaDto;
            villa.Id = id;
            return NoContent();
        }
    }
}
