using ScoreYourPoint.Dto;

namespace ScoreYourPoint.Services.Sports
{
    public interface ISportsService
    {
        Task<IEnumerable<SportDto>> GetSportsAsync();
        Task<SportDto> GetSportByIdAsync(int id);
        Task CreateSportAsync(SportRequestDto sport);
        Task UpdateSportAsync(int id, SportRequestDto sport);
        Task DeleteSportAsync(int id);
    }
}
