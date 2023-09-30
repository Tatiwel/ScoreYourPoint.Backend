using Microsoft.AspNetCore.Mvc;
using ScoreYourPoint.Dto;
using ScoreYourPointAPI.Domain;
using ScoreYourPointApi.Infra.Data;
using Microsoft.EntityFrameworkCore;
using ScoreYourPointApi.Domain;

namespace ScoreYourPoint.Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class ProfileController : Controller
    {
        public ProfileController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        private readonly DataContext _dataContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        // GET: ProfileController
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfileDto>> GetByID(int id)
        {
            var Profile = await _dataContext.Profiles.FirstOrDefaultAsync(pro => pro.Id == id);

            if (Profile == null)
            {
                return NotFound();
            }

            return new ProfileDto(Profile);
        }

        // POST: ProfileController
        [HttpPost]
        public async Task<ActionResult> Store([FromBody] ProfileRequestDto profile)
        {
            await _dataContext.Profiles.AddAsync(new Profile
            {
                Name = profile.Name,
                User = _dataContext.Users.Where(w => w.Id == profile.UserId).FirstOrDefault(),
                Gender = profile.Gender,
                Age = profile.Age,
                LeftOrRight = profile.LeftOrRight,
                Height = profile.Height,
                Weight = profile.Weight,
            });

            await _dataContext.SaveChangesAsync();

            return NoContent();
        }

        // PUT: ProfileController
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ProfileDto profile)
        {
            var Prof = await _dataContext.Profiles.FirstOrDefaultAsync(prof => prof.Id == id);

            if (Prof == null)
            {
                return NotFound();
            }

            Prof.Id = profile.Id;
            Prof.Name = profile.Name;
            Prof.Gender = profile.Gender;
            Prof.Age = profile.Age;
            Prof.LeftOrRight = profile.LeftOrRight;
            Prof.Height = profile.Height;
            Prof.Weight = profile.Weight;

            _dataContext.Entry(Prof).CurrentValues.SetValues(profile);
            await _dataContext.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: ProfileController
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Prof = await _dataContext.Profiles.FirstOrDefaultAsync(prof => prof.Id == id);

            if (Prof == null)
            {
                return NotFound();
            }

            _dataContext.Remove(Prof);
            await _dataContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
