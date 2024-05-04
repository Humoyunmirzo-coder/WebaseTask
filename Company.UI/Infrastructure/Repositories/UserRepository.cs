using Infrastructure.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<UserRepository>, IUserRepository
    {
        public UserRepository(ConpanyDbContext conpanyDbContext) : base(conpanyDbContext)
        {
        }
    }
}
