using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User> GetByName(string name);

        Task<User> GetByDocument(string document);

        Task<List<User>> SearchByName(string name);
    }
}
