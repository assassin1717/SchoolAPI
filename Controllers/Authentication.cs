using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolAPI.Helpers;
using SchoolAPI.Models;
using SchoolAPI.Services;

namespace SchoolAPI.Controllers
{
    [Route("api/v1/account")]
    [ApiController]
    public class Authentication : Controller
    {
        [HttpPost]
        [Route("auth")]
        [AllowAnonymous]
        public ActionResult Authenticate(User user)
        {
            var data = Utils.GetUser(user);

            if (data == null)
                return NotFound(new { message = "Invalid user or password." });

            var token = TokenService.GenerateToken(data);
            user.Password = "";
            return Ok(new TokenAuth()
            {
                User = data,
                Token = token
            });
        }
    }
}
