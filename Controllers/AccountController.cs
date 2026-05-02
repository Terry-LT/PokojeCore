using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokojeCore.Dtos;
using PokojeCore.Models;
using PokojeCore.Services;

namespace PokojeCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IAccountService service) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<AccountResponse>> AddAccount([FromBody] AccountRequest request)
        {
            try
            {
                var createdAccount = await service.AddAccountAsync(request);
                return CreatedAtAction(nameof(AddAccount), createdAccount);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message); //for demo, improve in future
            }

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAccount(int id)
        {
            var isDeleted = await service.DeleteAccountAsync(id);
            if (!isDeleted)
            {
                return NotFound("Account with such id does not exist!");
            }
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> GetAccounts()
        {
            return Ok(await service.GetAccountsAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAccountById(int id)
        {

            var account = await service.GetAccountByIdAsync(id);
            if (account == null)
            {
                return NotFound("Account with such id does not exist!");
            }
            return Ok(account);
        }
        [HttpPatch("{id}")]
        public async Task<ActionResult<AccountResponse>> UpdateAccount(int id, [FromBody] AccountFirstLastNameRequest request)
        {
            var isUpdated = await service.UpdateAccountAsync(id, request);
            if (!isUpdated)
            {
                return NotFound("Account with such id does not exist!");
            }
            return NoContent();
        }
    }
}
