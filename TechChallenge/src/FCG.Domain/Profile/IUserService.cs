namespace FCG.Domain.Profile;

public interface IUserService
{
    Task<UserDto> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken);
    Task<IEnumerable<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken);
    Task<Guid> CreateUserAsync(UserDto userDto, CancellationToken cancellationToken);
    Task<bool> DeleteUserAsync(Guid userId, CancellationToken cancellationToken);
    Task<UserDto> UpdateUserAsync(Guid userId, UserDto userDto, CancellationToken cancellationToken);
}
