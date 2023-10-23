using ScoreYourPoint.Dto;

namespace ScoreYourPoint.Services.Users
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetUsersAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task CreateUserAsync(UserRequestDto user);
        Task UpdateUserAsync(int id, UserRequestDto user);
        Task DeleteUserAsync(int id);
    }
}
