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

        private ILogger<ProfileController> _logger;

        public ProfileController(ProfileService profileService, ILogger<ProfileController> logger)
        {
            _profileService = profileService;
            _logger = logger;
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
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("all")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(List<ProfileOutput>), 200)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllProfilesAsync()
        {
            try
            {
                var result = await _profileService.GetAllUsersAsync();

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
