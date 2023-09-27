using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScoreYourPoint.Dto;
using ScoreYourPointApi.Domain;
using ScoreYourPointApi.Infra.Data;

namespace ScoreYourPoint.Api.Controllers
{
    public class UserController : Controller
    {

        private readonly DataContext _dataContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetByID(int id)
        {
            var User = await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (User == null)
            {
                return NotFound();
            }

            return new UserDto(User);
        }

        [HttpPost]
        public async Task<ActionResult> Store([FromBody] UserDto User)
        {
            await _dataContext.Users.AddAsync(new User
            {
                Email = User.Email,
                Password = User.Password,
                IsActive = true
            });

            await _dataContext.SaveChangesAsync();

            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UserDto user)
        {
            var Usr = await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (Usr == null)
            {
                return NotFound();
            }

            Usr.Email = user.Email;
            Usr.Password = user.Password;
            Usr.IsActive = user.IsActive;

            _dataContext.Entry(Usr).CurrentValues.SetValues(user);
            await _dataContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Usr = await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (Usr == null)
            {
                return NotFound();
            }

            _dataContext.Remove(Usr);
            await _dataContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
