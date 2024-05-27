using Application.Features.UserOperationClaim.Commands.CreateUserOperationClaim;
using Application.Features.UserOperationClaim.Commands.DeleteUserOperationClaim;
using Application.Features.UserOperationClaim.Queries.GetAllUserOperationClaims;
using Application.Features.UserOperationClaim.Queries.GetUserOperationClaim;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimController(IHttpContextAccessor httpContextAccessor) : BaseController(httpContextAccessor)
    {
        /// <summary>
        /// Tüm kullanıcı operasyon yetkilerini getirir.
        /// </summary>
        /// <returns>Tüm kullanıcı operasyon yetkilerinin listesi.</returns>
        [HttpGet("GetAllUserOperationClaims")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllUserOperationClaimsCommand();

            var userOperationClaims = await Mediator.Send(query);

            return Ok(userOperationClaims);
        }

        /// <summary>
        /// Belirtilen ID'ye sahip kullanıcı operasyon yetkisini getirir.
        /// </summary>
        /// <param name="id">Kullanıcı operasyon yetkisi ID'si.</param>
        /// <returns>Belirtilen ID'ye sahip kullanıcı operasyon yetkisi.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var query = new GetUserOperationClaimByIdCommand { Id = id };

            var userOperationClaim = await Mediator.Send(query);

            return Ok(userOperationClaim);
        }

        /// <summary>
        /// Yeni bir kullanıcı operasyon yetkisi oluşturur.
        /// </summary>
        /// <param name="command">Kullanıcı operasyon yetkisi oluşturma komutu.</param>
        /// <returns>Oluşturulan kullanıcı operasyon yetkisi bilgileri.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserOperationClaimCommand command)
        {
            var createdUserOperationClaim = await Mediator.Send(command);

            return Ok(createdUserOperationClaim);
        }

        /// <summary>
        /// Belirtilen ID'ye sahip kullanıcı operasyon yetkisini siler.
        /// </summary>
        /// <param name="id">Kullanıcı operasyon yetkisi ID'si.</param>
        /// <returns>Silme işleminin sonucu.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var command = new DeleteUserOperationClaimCommand { Id = id };

            var deletedUserOperationCommand = await Mediator.Send(command);

            return Ok(deletedUserOperationCommand);
        }
    }
}
