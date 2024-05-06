﻿using Aplication.Services;
using AutoMapper;
using Domen.AutoGenerated;
using Task = Domen.AutoGenerated.Task;
using Domen.EmtityDTO.RoleDto;
using Domen.EmtityDTO.TaskDto;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Servises
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;
        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<TaskGetDto> CreateTaskAynce(TaskCreateDto taskCreate)
        {
            var task = _mapper.Map<Task>(taskCreate);
            var taskEntity = await _taskRepository.CreateAsync(task);
            return _mapper.Map<TaskGetDto>(taskEntity);
        }

        public async Task<bool> DeleteTaskAynce(int Id)
        {
           return await _taskRepository.DeleteAsync(Id);
        }

        public async Task<List<TaskGetDto>> GetAllTaskAynce()
        {
           var task =await  _taskRepository.GetAllAsync();
            return _mapper.Map<List<TaskGetDto>>(task);
        }

        public async Task<TaskGetDto> GetByIdTaskAynce(int Id)
        {
            var  task = await _taskRepository.GetByIdAsync(Id);
            return task != null ? _mapper.Map<TaskGetDto>(task) : null;
        }

        public async Task<TaskGetDto> UpdateTaskAynce(TaskUpdateDto  taskUpdate)
        {
            var task = _mapper.Map<Task>(taskUpdate);
            await _taskRepository.UpdateAsync(task);
            return _mapper.Map<TaskGetDto> (task);
        }
    }
}
