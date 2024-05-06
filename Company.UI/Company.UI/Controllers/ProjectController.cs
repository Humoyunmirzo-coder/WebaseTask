using Aplication.Services;
using Domen.EmtityDTO.ProjectDto;
using Domen.EmtityDTO.UserDto;
using Infrastructure.Servises;
using Microsoft.AspNetCore.Http;
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
        public async Task<ProjectGetDto> CreateProject(ProjectCreateDto  projectGetDto)
        {
            var project = await _projectService.CreateProjectAsync(projectGetDto);
            return project;
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
