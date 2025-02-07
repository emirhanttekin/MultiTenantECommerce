using MultiTenantECommerce.Domain.Entities;

namespace MultiTenantECommerce.Domain.Interfaces.Repository
{
    public interface IUserRepository  : IGenericRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email);
    }
}
