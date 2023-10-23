using ScoreYourPoint.Dto;

namespace ScoreYourPoint.Services.Positions
{
    public interface IPositionService
    {
        Task<IEnumerable<PositionDto>> GetPositionsAsync();
        Task<PositionDto> GetPositionByIdAsync(int id);
        Task CreatePositionAsync(PositionRequestDto position);
        Task UpdatePositionAsync(int id, PositionRequestDto position);
        Task DeletePositionAsync(int id);
    }
}
