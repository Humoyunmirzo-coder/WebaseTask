using Aplication.Services.ProjectServices;
using Domen.EmtityDTO.ProjectDto;
using Microsoft.AspNetCore.Mvc;

namespace Company.UI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProject()
        {
            List<ProjectGetDto> project = await _projectService.GetAllProjectAsync();
            return Ok(project);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdProject(int id)
        {
            var project = await _projectService.GetByIdProjectAsync(id);
            return Ok(project);
        }

        [HttpPost]
        public async Task<ProjectGetDto> CreateProject(ProjectCreateDto projectGetDto)
        {
            var project = await _projectService.CreateProjectAsync(projectGetDto);
            return project;
        }

        [HttpPut]

        public async Task<ActionResult<ProjectGetDto>> UpdateProject([FromBody] ProjectUpdateDto projectUpdateDto)
        {
            try
            {
                if (projectUpdateDto == null)
                {
                    return BadRequest("project data must be provided.");
                }
                var updatedUser = await _projectService.UpdateProjectAsync(projectUpdateDto);
                if (updatedUser == null)
                {
                    return NotFound($"project with ID {projectUpdateDto.Id} not found.");
                }
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [HttpDelete]
        public async Task<bool> DeleteProject(int Id)
        {
            if (Id != 0)
            {
                return await _projectService.DeleteProjectAsync(Id);
            }
            return false;

        }
    }
}
