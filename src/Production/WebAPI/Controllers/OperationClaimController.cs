using Application.Features.OperationClaim.Commands.DeleteOperationClaim;
using Application.Features.OperationClaim.Commands.UpdateOperationClaim;
using Application.Features.OperationClaim.Queries.GetAllOperationClaims;
using Application.Features.OperationClaim.Queries.GetOperationClaimById;
using Application.Features.OperationClaimFeature.Commands.CreateOperationClaim;
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
    public class OperationClaimController(IHttpContextAccessor httpContextAccessor) : BaseController(httpContextAccessor)
    {
        /// <summary>
        /// Tüm operasyon yetkilerini getirir.
        /// </summary>
        /// <returns>Tüm operasyon yetkilerinin listesi.</returns>
        [HttpGet("GetAllOperationClaims")]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllOperationClaimQuery();

            var operationClaims = await Mediator.Send(query);

            return Ok(operationClaims);
        }

        /// <summary>
        /// Belirtilen ID'ye sahip operasyon yetkisini getirir.
        /// </summary>
        /// <param name="Id">Operasyon yetkisi ID'si.</param>
        /// <returns>Belirtilen ID'ye sahip operasyon yetkisi.</returns>
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] int Id)
        {
            var query = new GetOperationClaimByIdQuery { Id = Id };

            var operationClaim = await Mediator.Send(query);

            return Ok(operationClaim);
        }

        /// <summary>
        /// Yeni bir operasyon yetkisi ekler.
        /// </summary>
        /// <param name="command">Operasyon yetkisi oluşturma komutu.</param>
        /// <returns>Oluşturulan operasyon yetkisi bilgileri.</returns>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand command)
        {
            var updatedOperationClaim = await Mediator.Send(command);

            return Created("", updatedOperationClaim);
        }

        /// <summary>
        /// Belirtilen ID'ye sahip operasyon yetkisini siler.
        /// </summary>
        /// <param name="Id">Operasyon yetkisi ID'si.</param>
        /// <returns>Silme işleminin sonucu.</returns>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] int Id)
        {
            var command = new DeleteOperationClaimCommand { Id = Id };

            var deletedOperationClaimCommand = await Mediator.Send(command);

            return Ok(deletedOperationClaimCommand);
        }

        /// <summary>
        /// Mevcut bir operasyon yetkisini günceller.
        /// </summary>
        /// <param name="command">Operasyon yetkisi güncelleme komutu.</param>
        /// <returns>Güncellenen operasyon yetkisi bilgileri.</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand command)
        {
            var updatedOperaionClaimCommand = await Mediator.Send(command);

            return Ok(updatedOperaionClaimCommand);
        }
    }
}
