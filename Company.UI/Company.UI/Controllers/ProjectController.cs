using Aplication.Services.ProjectServices;
using Domen.EmtityDTO.ProjectDto;
using Microsoft.AspNetCore.Mvc;

namespace Company.UI.Controllers
{
    [Route("api/[controller]/[action]")]
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
            if (id <= 0)
            {
                return BadRequest("Invalid project ID.");
            }
            try
            {
                var project = await _projectService.GetByIdProjectAsync(id);

                if (project == null)
                {
                    return NotFound($"Project with ID {id} not found.");
                }
                return Ok(project);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
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



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid project ID.");
            }

            try
            {
                var projectExists = await _projectService.GetByIdProjectAsync(id);
                if (projectExists == null)
                {
                    return NotFound($"Project with ID {id} not found.");
                }

                var result = await _projectService.DeleteProjectAsync(id);
                if (result)
                {
                    return NoContent();    // Successful deletion, 204 No Content
                }
                else
                {
                    return StatusCode(500, "An error occurred while deleting the project.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("export")]
        public async Task<IActionResult> AllProjectExportToExcel()
        {
            var persons = await _projectService.GetAllProjectAsync();
            await _projectService.ProjectCreateExcelFileAsync(persons);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "D:\\hp.xlsx");

            byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "D:\\hp.xlsx");
        }
    }
}
