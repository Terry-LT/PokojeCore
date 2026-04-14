using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokojeCore.Dtos;
using PokojeCore.Services;

namespace PokojeCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController(IReservationService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetReservations()
        {
            return Ok(await service.GetReservationsAsync());
        }
        [HttpPost]
        public async Task<ActionResult<ReservationResponse>> AddReservation([FromBody] ReservationRequest reservation)
        {
            var createdReservation = await service.AddReservationAsync(reservation);
            return CreatedAtAction(nameof(AddReservation), createdReservation);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReservation(int id)
        {
            var isDeleted = await service.DeleteReservationAsync(id);
            if (!isDeleted)
            {
                return NotFound("Reserervation with such id does not exist.");
            }
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationResponse>> GetReservationById(int id)
        {
            var reservation = await service.GetReservationByIdAsync(id);
            if (reservation == null)
            {
                return NotFound("Reservation with such id does not exist.");
            }
            return Ok(reservation);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ReservationResponse>> UpdateReservation(int id, [FromBody] ReservationRequest reservation)
        {
            var updatedReservation = await service.UpdateReservationAsync(id, reservation);
            if (updatedReservation == null)
            {
                return NotFound("Reservation with such id does not exist.");
            }
            return NoContent();
        }
    }   
}
