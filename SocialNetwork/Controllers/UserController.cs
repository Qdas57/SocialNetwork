using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SocialNetwork.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private List<User> _users = new List<User>()
        {
            new User()
            {
                Id = 1,
                Name = "Mike"
            },
            new User()
            {
                Id = 2,
                Name = "Alice"
            },
            new User()
            {
                Id = 3,
                Name = "Alex"
            }
        };

        [HttpGet]
        [Route("count")]
        public async Task<ActionResult<int>> GetUserCountAsync()
        {
            await Task.Delay(3000);

            return Ok(_users.Count);
        }
    }
}
