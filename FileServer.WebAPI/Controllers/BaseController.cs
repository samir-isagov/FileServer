namespace FileServer.WebAPI.Controllers
{
    using Common;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        protected string RootFolder => User.FindFirst(CustomClaimTypes.RootFolder).Value;

        protected IMediator Mediator => (IMediator)HttpContext.RequestServices.GetService(typeof(IMediator));
    }
}