using Microsoft.AspNetCore.Mvc;
using ScoreYourPoint.Dto;
using ScoreYourPoint.Services.Users;

namespace ScoreYourPoint.Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(IUserService userService)
        {       
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetByID(int id)
        {
            return await _userService.GetUserByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> Store([FromBody] UserRequestDto user)
        {
            await _userService.CreateUserAsync(user);

            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UserRequestDto user)
        {
            await _userService.UpdateUserAsync(id, user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
