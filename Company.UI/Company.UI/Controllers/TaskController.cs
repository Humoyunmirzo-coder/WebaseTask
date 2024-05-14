using Aplication.Services.TaskServices;
using AutoMapper;
using Domen.EmtityDTO.TaskDto;
using Domen.EmtityDTO.UserDto;
using Infrastructure.Servises;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.UI.Controllers
{
    [Route("[controller] /[action]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        private readonly IMapper _mapper;

        public TaskController(ITaskService taskService, IMapper mapper)
        {
            _taskService = taskService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTask()
        {
            List<TaskGetDto> task = await _taskService.GetAllTaskAynce();
            return Ok(task);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdTask(int id)
        {
            var task = await _taskService.GetByIdTaskAynce(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<TaskGetDto> CreateTask(TaskCreateDto  taskCreateDto)
        {
            var task = await  _taskService.CreateTaskAynce(taskCreateDto);
            return task ;
        }

        [HttpPut]
        public async Task<ActionResult<TaskGetDto>> UpdateTask([FromBody] TaskCreateDto  taskCreateDto)
        {
            try
            {
                if (taskCreateDto == null)
                {
                    return BadRequest("taskCreateDto data must be provided.");
                }
                var updatedUser = await _taskService.CreateTaskAynce(taskCreateDto);
                if (updatedUser == null)
                {
                    return NotFound($"Task with ID {updatedUser.Id} not found.");
                }
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<bool> DeleteUser(int Id)
        {
            if (Id != 0)
            {
                return await _taskService.DeleteTaskAynce(Id);
            }
            return false;

        }

    }
}
