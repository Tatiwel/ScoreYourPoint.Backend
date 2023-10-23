using Microsoft.EntityFrameworkCore;
using ScoreYourPoint.Dto;
using ScoreYourPointApi.Infra.Data;
using ScoreYourPointAPI.Domain;

namespace ScoreYourPoint.Services.Positions
{
    public class PositionService: IPositionService
    {
        private readonly DataContext _dataContext;

        public PositionService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<PositionDto>> GetPositionsAsync()
        {
            var positions = await _dataContext.Positions.ToListAsync();

            return positions.Select(position => new PositionDto(position));
        }

        public async Task<PositionDto> GetPositionByIdAsync(int id)
        {
            var position = await _dataContext.Positions.FirstOrDefaultAsync(p => p.Id == id);

            return new PositionDto(position);
        }

        public async Task CreatePositionAsync(PositionRequestDto position)
        {
            var positionEntity = new Position
            {
                Name = position.Name,
            };

            await _dataContext.Positions.AddAsync(positionEntity);
            await _dataContext.SaveChangesAsync();

        }

        public async Task UpdatePositionAsync(int id, PositionRequestDto position)
        {
            var positionEntity = await _dataContext.Positions.FirstOrDefaultAsync(p => p.Id == id);

            positionEntity.Name = position.Name;
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeletePositionAsync(int id)
        {
            var position = await _dataContext.Positions.FirstOrDefaultAsync(p => p.Id == id);

            _dataContext.Positions.Remove(position);
            await _dataContext.SaveChangesAsync();
        }
    }
}
