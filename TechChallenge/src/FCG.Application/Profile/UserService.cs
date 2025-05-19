﻿using FCG.Domain.Profile;
using FCG.Infrastructure.Data.Repository;
using FCG.Infrastructure.Log;

namespace FCG.Application.Profile;

public class UserService(IUserRepository _userRepository, ILoginRepository _loginRepository, BaseLogger _logger) : IUserService
{
    public async Task<Guid> CreateUserAsync(UserDto userDto, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Creating user: {userDto}");

        var loginModel = await _loginRepository.GetByEmailAsync(userDto.Email, cancellationToken);
        if (loginModel is not null)
        {
            _logger.LogError($"User with email {userDto.Email} already exists");
            throw new ArgumentException("User with this email already exists");
        }

        var userModel = userDto.ToUserModel();

        if (!userModel.ValidateEmail())
        {
            _logger.LogError($"Invalid email format for user: {userDto}");
            throw new ArgumentException("Invalid email format");
        }
        if (!userModel.ValidatePassword())
        {
            _logger.LogError($"Invalid password format for user: {userDto}");
            throw new ArgumentException("Invalid password format");
        }

        userModel.Login.HashPassword();
        var login = await _loginRepository.AddAsync(userModel.Login, cancellationToken);
        userModel.Login = login;

        var response = await _userRepository.AddAsync(userModel, cancellationToken);
        return response.Id;
    }

    public async Task<bool> DeleteUserAsync(Guid userId, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Deleting user with ID: {userId}");
        return await _userRepository.DeleteAsync(userId, cancellationToken);
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Fetching all users");
        var users = await _userRepository.GetAllAsync(cancellationToken);
        return users.Select(user => user.ToUserDto());
    }

    public async Task<UserDto> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Fetching user with ID: {userId}");
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken);
        return user.ToUserDto();
    }

    public async Task<UserDto> UpdateUserAsync(Guid userId, UserDto userDto, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Updating user with ID: {userId}");
        var userModel = userDto.ToUserModel();
        userModel.Id = userId;

        if (!userModel.ValidateEmail())
        {
            _logger.LogError($"Invalid email format for user: {userDto}");
            throw new ArgumentException("Invalid email format");
        }
        if (!userModel.ValidatePassword())
        {
            _logger.LogError($"Invalid password format for user: {userDto}");
            throw new ArgumentException("Invalid password format");
        }

        var response = await _userRepository.UpdateAsync(userId, userModel, cancellationToken);
        return response.ToUserDto();
    }
}
