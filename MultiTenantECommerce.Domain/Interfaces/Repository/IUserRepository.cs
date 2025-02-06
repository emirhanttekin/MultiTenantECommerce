using MultiTenantECommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantECommerce.Domain.Interfaces.Repository
{
    public interface IUserRepository  : IGenericRepository<User>
    {
        Task<User> GetUserByEmailAsync(string email);
    }
}
