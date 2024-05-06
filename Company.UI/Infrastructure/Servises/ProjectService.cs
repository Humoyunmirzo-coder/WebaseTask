﻿using Aplication.Services;
using AutoMapper;
using Domen.AutoGenerated;
using Domen.EmtityDTO.ProjectDto;
using Domen.EmtityDTO.UserDto;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Servises
{

    public class ProjectService : IProjectService
    {
         private readonly IProjectRepository _repository;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async  Task<ProjectGetDto> CreateProjectAsync(ProjectCreateDto project)
        {
            var projectEntity = _mapper.Map<Project>(project);
            var createProject = await _repository.CreateAsync(projectEntity);
            return _mapper.Map<ProjectGetDto>(createProject);
              }

        public async Task<bool> DeleteProjectAsync(int Id)
        {
            return await  _repository.DeleteAsync(Id);
        }

        public async Task<List<ProjectGetDto>> GetAllProjectAsync()
        {
           var projectEntity = await _repository.GetAllAsync();
            return  _mapper.Map<List<ProjectGetDto> >(projectEntity);
        }

        public async Task<ProjectGetDto> GetByIdProjectAsync(int Id)
        {
            var project = await _repository.GetByIdAsync(Id);
            return project != null ? _mapper.Map<ProjectGetDto>(project) : null;
        }

        public async Task<ProjectGetDto> UpdateProjectAsync(ProjectUpdateDto project)
        {
            var projects = _mapper.Map<Project>(project);
            await _repository.UpdateAsync(projects);
            return _mapper.Map<ProjectGetDto>(projects);
        }
    }
}