using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]")]
    [Authorize]
    [ApiController]
    public class IdentityController : ControllerBase
    {

        [HttpGet]
        [Authorize("Write")]
        public IActionResult Get()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
        [HttpPost]
        [Authorize("write")]
        public IActionResult AddClaim(string claim) { 
            User.AddIdentity(new System.Security.Claims.ClaimsIdentity(claim));
            return Ok("claim added");
        }
    }
}
