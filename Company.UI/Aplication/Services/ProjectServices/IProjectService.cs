﻿using Domen.AutoGenerated;
using Domen.EmtityDTO.ProjectDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.ProjectServices
{
    public interface IProjectService
    {
        Task<ProjectGetDto> CreateProjectAsync(ProjectCreateDto project);
        Task<ProjectGetDto> UpdateProjectAsync(ProjectUpdateDto project);
        Task<bool> DeleteProjectAsync(int Id);
        Task<ProjectGetDto> GetByIdProjectAsync(int Id);
        Task<List<ProjectGetDto>> GetAllProjectAsync();
    }
}