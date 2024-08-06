using Aplication.Services.TaskServices;
using AutoMapper;
using Domen.EmtityDTO.TaskDto;
using Microsoft.AspNetCore.Mvc;

namespace Company.UI.Controllers
{
    [Route("api/[controller] /[action]")]
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
            if (id <= 0)
            {
                return BadRequest("Invalid task ID.");
            }
            try
            {
                var task = await _taskService.GetByIdTaskAynce(id);

                if (task == null)
                {
                    return NotFound($"Task with ID {id} not found.");
                }

                return Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskCreateDto taskCreateDto)
        {
            if (taskCreateDto == null)
            {
                return BadRequest("Task data must be provided.");
            }
            try
            {
                var task = await _taskService.CreateTaskAynce(taskCreateDto);
                if (task == null)
                {
                    return StatusCode(500, "An error occurred while creating the task.");
                }
                return CreatedAtAction(nameof(GetByIdTask), new { id = task.Id }, task);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPut]
        public async Task<ActionResult<TaskGetDto>> UpdateTask([FromBody] TaskCreateDto taskCreateDto)
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid user ID.");
            }

            try
            {
                var userExists = await _taskService.GetByIdTaskAynce(id);
                if (userExists == null)
                {
                    return NotFound($"User with ID {id} not found.");
                }

                var result = await _taskService.DeleteTaskAynce(id);
                if (result)
                {
                    return NoContent(); 
                }
                else
                {
                    return StatusCode(500, "An error occurred while deleting the user.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


    }
}
