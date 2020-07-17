using System.IO;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace FileServer.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {
        protected IWebHostEnvironment WebHostEnvironment => (IWebHostEnvironment)HttpContext.RequestServices.GetService(typeof(IWebHostEnvironment));

        protected string RootFolder
        {
            get
            {
                string rootFolder = User.FindFirst(ClaimTypes.Name).Value;
                return Path.Combine(WebHostEnvironment.WebRootPath, "App_Data", rootFolder);
            }
        }
    }
}
