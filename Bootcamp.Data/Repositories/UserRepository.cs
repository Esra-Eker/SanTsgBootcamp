using Bootcamp.Data.Repositories.Interfaces;
using Bootcamp.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(BootcampDbContext context) : base(context)
        {

        }
        
    }
}
