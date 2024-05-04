using Infrastructure.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RoleRepository : GenericRepository<RoleRepository>, IRoleRepository
    {
        public RoleRepository(ConpanyDbContext conpanyDbContext) : base(conpanyDbContext)
        {
        }
    }
}
