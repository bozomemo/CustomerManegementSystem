using Application.Features.Auth.Commands.LoginByEmail;
using Application.Features.Auth.Models;
using Core.Security.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IHttpContextAccessor httpContextAccessor) : BaseController(httpContextAccessor)
    {
        /// <summary>
        /// Kullanıcı e-posta ve şifre ile giriş yapar.
        /// </summary>
        /// <param name="model">Kullanıcının giriş bilgilerini içeren model.</param>
        /// <returns>Giriş işlemi başarılı olursa, bir erişim tokeni döner.</returns>
        [HttpPost("LoginByEmail")]
        public async Task<IActionResult> Login([FromBody] LoginByEmailModel model)
        {
            var result = await Mediator.Send(new LoginByEmailCommand { Email = model.Email, Password = model.Password, IpAddress = GetIpAddress()! });

            if (result.RefreshToken is not null) SetRefreshTokenToCookie(result.RefreshToken);

            return Ok(result.AccessToken);
        }

        /// <summary>
        /// Yenileme tokenini çerezlere ekler.
        /// </summary>
        /// <param name="refreshToken">Yenileme tokeni.</param>
        private void SetRefreshTokenToCookie(RefreshToken refreshToken)
        {
            CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.UtcNow.AddDays(7), SameSite = SameSiteMode.None, Secure = true };

            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }
    }
}
