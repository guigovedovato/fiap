namespace FCG.Domain.Profile;

public interface IUserService
{
    Task<UserDto> GetUserByIdAsync(int userId);
    Task<List<UserDto>> GetAllUsersAsync();
    Task<int> CreateUserAsync(UserDto userDto);
    Task<bool> DeleteUserAsync(int userId);
    Task<UserDto> UpdateUserAsync(int userId, UserDto user);
}
