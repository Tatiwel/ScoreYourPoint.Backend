using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScoreYourPoint.Dto;
using ScoreYourPointApi.Domain;
using ScoreYourPointApi.Infra.Data;

namespace ScoreYourPoint.Api.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class ProfileRatingController : Controller
    {
        public ProfileRatingController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        private readonly DataContext _dataContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        [HttpGet]
        public async Task<ActionResult<ProfileRatingDto>> GetAll()
        {
            var ProfileRating = await _dataContext.ProfileRatings.ToListAsync();
            return Ok(ProfileRating);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProfileRatingDto>> GetByID(int id)
        {
            var ProfileRating = await _dataContext.ProfileRatings.FirstOrDefaultAsync(pr => pr.Id == id);
            if (ProfileRating == null)
            {
                return NotFound();
            }
            return new ProfileRatingDto(ProfileRating);
        }
        [HttpPost]
        public async Task<ActionResult> Store([FromBody] ProfileRatingRequestDto profileRating)
        {
            await _dataContext.ProfileRatings.AddAsync(new ProfileRating
            {
                //User user = profileRating.User,
                //Profile profile = profileRating.Profile,
                Rating = profileRating.Rating,
                Description = profileRating.Description,
            });
            await _dataContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] ProfileRatingDto profileRating)
        {
            var pR = await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (pR == null)
            {
                return NotFound();
            }

            Rating = profileRating.Rating;
            Description = profileRating.Description;

            _dataContext.Entry(pR).CurrentValues.SetValues(profileRating);
            await _dataContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
