using Microsoft.EntityFrameworkCore;
using ScoreYourPoint.Dto;
using ScoreYourPointApi.Domain;
using ScoreYourPointApi.Infra.Data;

namespace ScoreYourPoint.Services.Users
{
    public class UserService: IUserService
    {
        private readonly DataContext _dataContext;

        public UserService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _dataContext.Users.ToListAsync();

            return users.Select(user => new UserDto(user));
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            return new UserDto(user);
        }

        public async Task CreateUserAsync(UserRequestDto user)
        {
            var userEntity = new User
            {
                Email = user.Email,
                Password = user.Password, //lembrar de criptografar senha
                IsActive = true
            };

            await _dataContext.Users.AddAsync(userEntity);
            await _dataContext.SaveChangesAsync();

        }

        public async Task UpdateUserAsync(int id, UserRequestDto user)
        {
            var userEntity = await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            userEntity.Email = user.Email;
            userEntity.Password = user.Password;
            userEntity.IsActive = user.IsActive;
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Id == id);

            _dataContext.Users.Remove(user);
            await _dataContext.SaveChangesAsync();
        }
    }
}
