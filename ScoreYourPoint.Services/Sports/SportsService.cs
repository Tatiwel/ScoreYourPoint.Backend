using Microsoft.EntityFrameworkCore;
using ScoreYourPoint.Dto;
using ScoreYourPointApi.Infra.Data;
using ScoreYourPointAPI.Domain;

namespace ScoreYourPoint.Services.Sports
{
    public class SportsService: ISportsService
    {
        private readonly DataContext _dataContext;

        public SportsService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<SportDto>> GetSportsAsync()
        {
            var sports = await _dataContext.Sports.ToListAsync();

            return sports.Select(sport => new SportDto(sport));
        }

        public async Task<SportDto> GetSportByIdAsync(int id)
        {
            var sport = await _dataContext.Sports.FirstOrDefaultAsync(sp => sp.Id == id);

            return new SportDto(sport);
        }

        public async Task CreateSportAsync(SportRequestDto sport)
        {
            var sportEntity = new Sport
            {
                Name = sport.Name,       
            };

            await _dataContext.Sports.AddAsync(sportEntity);
            await _dataContext.SaveChangesAsync();

        }

        public async Task UpdateSportAsync(int id, SportRequestDto sport)
        {
            var sportEntity = await _dataContext.Sports.FirstOrDefaultAsync(sp => sp.Id == id);

            sportEntity.Name = sport.Name;      
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteSportAsync(int id)
        {
            var sport = await _dataContext.Sports.FirstOrDefaultAsync(sp => sp.Id == id);

            _dataContext.Sports.Remove(sport);
            await _dataContext.SaveChangesAsync();
        }
    }
}
