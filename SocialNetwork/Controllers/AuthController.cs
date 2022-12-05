using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Models.Input;
using SocialNetwork.Models.Output;
using SocialNetwork.Services.Repositories;
using SocialNetwork.Services.Services;

namespace SocialNetwork.Controllers
{
    [ApiController]
    [Route("auth")]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        private readonly UserService _userService;

        private ILogger<AuthController> _logger;

        public AuthController(UserRepository userRepository, UserService userService, ILogger<AuthController> logger)
        {
            _userRepository = userRepository;
            _userService = userService;
            _logger = logger;
        }

        /// <summary>
        /// Ресгиструет новго пользователя.
        /// </summary>
        /// <param name="newUser">Модель пользователя.</param>
        /// <returns>Результат регистрации.</returns>
        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterUserInput newUser)
        {
            try
            {
                var status = await _userRepository.CheckEmailAsync(newUser.Email);

                if (status)
                {
                    _logger.LogInformation($"User with email {newUser.Email} already exists!");

                    return BadRequest(new { message = $"User with email {newUser.Email} already exists!" });
                }

                var result = await _userRepository.RegisterUserAsync(newUser.FirstName, newUser.LastName, newUser.Email,
                                                    newUser.Password, newUser.Phone, newUser.Avatar, newUser.BirthDate);

                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, new { message = e.Message });
            }
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginAsync([FromBody] LoginInput loginInput)
        {
            try
            {
                LoginResult? result = await _userService.AuthenticateUserAsync(loginInput.Email, loginInput.Password);

                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, new { message = e.Message });
            }
        }

        [HttpPost]
        [Route("refresh-tokens")]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshTokensAsync(string refreshToken)
        {
            //TODO: implement
            _logger.LogInformation("test");

            return Ok();
        }
    }
}
