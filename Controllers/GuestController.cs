using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokojeCore.Dtos;
using PokojeCore.Services;

namespace PokojeCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController(IGuestService service) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<GuestResponse>> AddGuest([FromBody] GuestRequest request) {
            var createdGuest = await service.AddGuestAsync(request);
            return CreatedAtAction(nameof(AddGuest),createdGuest);
        }
        [HttpGet]
        public async Task<IActionResult> GetGuests() {
            return Ok(await service.GetGuestsAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGuest(int id) { 
            var isDeleted = await service.DeleteGuestAsync(id);
            if (!isDeleted)
            {
                return NotFound("Guest with such id does not exist!");
            }
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetGuestById(int id)
        {
            var guest = await service.GetGuestByIdAsync(id);
            if (guest == null)
            {
                return NotFound("Guest with such id does not exist!");
            }
            return Ok(guest);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<GuestResponse>> UpdateGuest(int id, [FromBody] GuestRequest request)
        {
            var updatefGuest = await service.UpdateGuestAsync(id, request);
            if (updatefGuest == null)
            {
                return NotFound("Guest with such id does not exist!");
            }
            return NoContent();

        }

    }
}
