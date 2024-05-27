using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private readonly IMediator? _mediator;
        protected IMediator Mediator
        {
            get
            {
                return _mediator ?? HttpContext.RequestServices.GetService<IMediator>()!;
            }
        }

        protected BaseController(IHttpContextAccessor httpContextAccessor)
        {
            _mediator = httpContextAccessor.HttpContext?.RequestServices.GetService<IMediator?>();
        }

        protected string? GetIpAddress()
        {
            if (Request.Headers.TryGetValue("X-Forwarded-For", out Microsoft.Extensions.Primitives.StringValues value)) return value;

            return HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString();
        }
    }
}
