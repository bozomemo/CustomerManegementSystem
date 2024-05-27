using Application.Features.Customer.Commands.AddCustomer;
using Application.Features.Customer.Commands.DeleteCustomer;
using Application.Features.Customer.Commands.UpdateCustomer;
using Application.Features.Customer.Queries.GetAllCustomers;
using Application.Features.Customer.Queries.GetCustomerById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(IHttpContextAccessor httpContextAccessor) : BaseController(httpContextAccessor)
    {
        /// <summary>
        /// Tüm müşterileri getirir.
        /// </summary>
        /// <returns>Tüm müşterilerin listesi.</returns>
        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var result = await Mediator.Send(new GetAllCustomerQuery());

            return Ok(result);
        }

        /// <summary>
        /// Belirtilen ID'ye sahip müşteriyi getirir.
        /// </summary>
        /// <param name="id">Müşteri ID'si.</param>
        /// <returns>Belirtilen ID'ye sahip müşteri.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] int id)
        {
            var result = await Mediator.Send(new GetCustomerByIdQuery { Id = id });

            return Ok(result);
        }

        /// <summary>
        /// Yeni bir müşteri oluşturur.
        /// </summary>
        /// <param name="command">Müşteri ekleme komutu.</param>
        /// <returns>Oluşturulan müşteri bilgileri.</returns>
        [HttpPost("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer([FromBody] AddCustomerCommand command)
        {
            var result = await Mediator.Send(command);

            return Ok(result);
        }

        /// <summary>
        /// Belirtilen ID'ye sahip müşteriyi siler.
        /// </summary>
        /// <param name="id">Müşteri ID'si.</param>
        /// <returns>Silme işleminin sonucu.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            var result = await Mediator.Send(new DeleteCustomerCommand { Id = id });

            return Ok(result);
        }

        /// <summary>
        /// Mevcut bir müşteriyi günceller.
        /// </summary>
        /// <param name="updateCustomerCommand">Müşteri güncelleme komutu.</param>
        /// <returns>Güncellenen müşteri bilgileri.</returns>
        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand updateCustomerCommand)
        {
            var result = await Mediator.Send(updateCustomerCommand);

            return Ok(result);
        }
    }
}
