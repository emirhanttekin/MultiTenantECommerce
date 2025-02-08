using MultiTenantECommerce.Application.DTOs;
using MultiTenantECommerce.Application.Interfaces.Services;
using MultiTenantECommerce.Domain.Entities;
using MultiTenantECommerce.Domain.Interfaces.Repository;
using System.Security.Cryptography;
using System.Text;

namespace MultiTenantECommerce.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserResponseDto> CreateUserAsync(Guid tenantId, UserDto userDto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(userDto.Email);
            if (existingUser != null)
            {
                throw new Exception("Bu e-posta zaten kullanılıyor");
            }
            var hashedPassword = HashPassword(userDto.Password);

            var user = new User
            {
                Id = Guid.NewGuid(),
                TenantID = tenantId,
                FullName = userDto.FullName,
                Email = userDto.Email,
                PasswordHash = hashedPassword,
                Role = userDto.Role,
            };
            await _userRepository.AddAsync(user);

            return new UserResponseDto
            {
                Id = user.Id,
                TenantID = user.TenantID,
                FullName = userDto.FullName,
                Email = userDto.Email,
                Role = userDto.Role,
            };
        }

        public async Task<UserResponseDto> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            if (user == null) return null;
            return new UserResponseDto
            {
                Id = user.Id,
                TenantID = user.TenantID,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role,

            };

        }

        public async Task<UserResponseDto> GetUserByIdASync(Guid userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null) return null;
            return new UserResponseDto
            {
                Id = user.Id,
                TenantID = user.TenantID,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role,
            };
        }

        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();

            }
        }
    }
}
