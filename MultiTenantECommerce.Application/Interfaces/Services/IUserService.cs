using MultiTenantECommerce.Application.DTOs;

namespace MultiTenantECommerce.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserResponseDto> CreateUserAsync(Guid tenantId, UserDto userDto);
        Task<UserResponseDto> GetUserByIdASync(Guid userId);
        Task<UserResponseDto> GetUserByEmailAsync(string email, string password);
    }
}
