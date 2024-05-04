﻿using Infrastructure.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class TaskRepository : GenericRepository<TaskRepository>, ITaskRepository
    {
        public TaskRepository(ConpanyDbContext conpanyDbContext) : base(conpanyDbContext)
        {
        }
    }
}
