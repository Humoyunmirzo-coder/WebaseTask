using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public  interface ITaskService
    {

        Task<Task> CreateTaskAynce(Task task);
        Task<Task> UpdateTaskAynce(Task task);
        Task<bool> DeleteTaskAynce(int Id);
        Task<Task> GetByIdTaskAynce(int Id);
        Task<List<Task>> GetAllTaskAynce();
    }
}
