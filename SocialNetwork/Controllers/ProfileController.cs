using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Core.Exceptions;
using SocialNetwork.Models.Output;
using SocialNetwork.Services.Services;

namespace SocialNetwork.Controllers
{
    /// <summary>
    /// Контроллер для профилей.
    /// </summary>
    [ApiController]
    [Route("profile")]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly ProfileService _profileService;

        public ProfileController(ProfileService profileService)
        {
            _profileService = profileService;
        }

        /// <summary>
        /// Вернет пользователю его профиль.
        /// </summary>
        /// <returns>Модель профиля.</returns>
        /// <response code="200">Ok or usernotfound.</response>
        /// <response code="401">Unauthorized.</response>
        /// <response code="500">Something went wrong.</response>
        [HttpGet]
        [Route("my")]
        [ProducesResponseType(typeof(ProfileOutput), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetMyProfileAsync()
        {
            try
            {
                string rawUserId = HttpContext.User.FindFirst("userId").Value;

                if (string.IsNullOrWhiteSpace(rawUserId))
                {
                    return Unauthorized();
                }

                if (!Guid.TryParse(rawUserId, out Guid userId))
                {
                    return Unauthorized();
                }

                var profile = await _profileService.GetProfileByIdAsync(userId);

                return Ok(profile);
            }
            catch (UserNotFoundException ex)
            {
                return Ok(new { message = ex.Message });
            }
            catch (Exception)
            {
                //TODO: log 
                return StatusCode(500, new { message = "Something went wrong." });
            }
        }
    }
}
