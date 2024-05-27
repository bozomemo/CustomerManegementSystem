using Application.Features.Users.Commands.CreateUserCommand;
using Application.Features.Users.Commands.DeleteUserCommand;
using Application.Features.Users.Commands.UpdateUserCommand;
using Application.Features.Users.Queries.GetAllUsersQuery;
using Application.Features.Users.Queries.GetById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IHttpContextAccessor httpContextAccessor) : BaseController(httpContextAccessor)
    {
        /// <summary>
        /// Tüm kullanıcıları getirir.
        /// </summary>
        /// <returns>Tüm kullanıcıların listesi.</returns>
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAll()
        {
            var users = await Mediator!.Send(new GetAllUsersQuery());
            return Ok(users);
        }

        /// <summary>
        /// Belirtilen ID'ye sahip kullanıcıyı siler.
        /// </summary>
        /// <param name="id">Kullanıcı ID'si.</param>
        /// <returns>Silme işleminin sonucu.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var user = await Mediator!.Send(new DeleteUserCommand { Id = id });
            return Ok(user);
        }

        /// <summary>
        /// Mevcut bir kullanıcıyı günceller.
        /// </summary>
        /// <param name="updateUserCommand">Kullanıcı güncelleme komutu.</param>
        /// <returns>Güncellenen kullanıcı bilgileri.</returns>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserCommand updateUserCommand)
        {
            var user = await Mediator.Send(updateUserCommand);
            return Ok(user);
        }

        /// <summary>
        /// Belirtilen ID'ye sahip kullanıcıyı getirir.
        /// </summary>
        /// <param name="Id">Kullanıcı ID'si.</param>
        /// <returns>Belirtilen ID'ye sahip kullanıcı.</returns>
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromQuery] int Id)
        {
            var user = await Mediator!.Send(new GetUserByIdQuery { Id = Id });
            return Ok(user);
        }

        /// <summary>
        /// Yeni bir kullanıcı oluşturur.
        /// </summary>
        /// <param name="createUserCommand">Kullanıcı oluşturma komutu.</param>
        /// <returns>Oluşturulan kullanıcı bilgileri.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand createUserCommand)
        {
            var newUser = await Mediator!.Send(createUserCommand);
            return Ok(newUser);
        }
    }
}
