using _3_DM2.Learning.Application.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _2_DM2.Learning.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userAppService;
        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUserByName(string name)
        {
            var user = await _userAppService.GetUserByName(name);

            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
