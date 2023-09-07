using Domain.Entity;
using Infra.Context;
using Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ManagerContext _context;

        public UserRepository(ManagerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByName(string name)
        {
            var user = await _context.Users
                                     .Where(
                                        x => x.Name.ToLower() == name.ToLower()
                                     )
                                     .AsNoTracking()
                                     .ToListAsync();

            return user.FirstOrDefault();
        }


        public async Task<List<User>> SearchByName(string name)
        {
            var allUsers = await _context.Users
                                     .Where(
                                        x => x.Name.ToLower().Contains(name.ToLower())
                                        )
                                     .AsNoTracking()
                                     .ToListAsync();

            return allUsers;
        }
    }
}
