using FCG.Domain.Profile;

namespace FCG.Application.Profile;

public class UserService : IUserService
{
    public Task<int> CreateUserAsync(UserDto userDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteUserAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<List<UserDto>> GetAllUsersAsync()
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> GetUserByIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> UpdateUserAsync(int userId, UserDto user)
    {
        throw new NotImplementedException();
    }
}
