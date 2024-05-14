using Domen.EmtityDTO.TaskDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.TaskServices
{
    public interface ITaskService
    {

        Task<TaskGetDto> CreateTaskAynce(TaskCreateDto task);
        Task<TaskGetDto> UpdateTaskAynce(TaskUpdateDto task);
        Task<bool> DeleteTaskAynce(int Id);
        Task<TaskGetDto> GetByIdTaskAynce(int Id);
        Task<List<TaskGetDto>> GetAllTaskAynce();
    }
}
