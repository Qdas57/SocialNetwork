using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Models;
using SocialNetwork.Models.Output;
using SocialNetwork.Services.Repositories;

namespace SocialNetwork.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] RegisterUserInput newUser)
        {
            try
            {
                var status = await _userRepository.IsUserExistAsync(newUser.Email);

                if (status)
                {
                    return BadRequest(new { message = $"User with email {newUser.Email} already exists!" });
                }

                var result = await _userRepository.RegisterUserAsync(newUser.FirstName, newUser.LastName, newUser.Email,
                                                    newUser.Password, newUser.Phone, newUser.Avatar, newUser.BirthDate);

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }            
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginInput loginInput)
        {
            try
            {
                var status = await _userRepository.LoginAsync(loginInput.Email, loginInput.Password);

                return Ok(status);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("profile-by-email")]
        public async Task<IActionResult> GetProfileByEmailAsync(string email)
        {
            //1. Аутентифицирован ли пользователь oauth
            //2. Корректный ли емейл
            //3. Поиск пользователя в БД
            //4. Формирование выходной модели

            ProfileOutput profile = new ProfileOutput();

            return Ok(profile);
        }
    }
}
