﻿using Infrastructure.Repositories;
using Task = Domen.AutoGenerated.Task;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen.Model;
using Microsoft.EntityFrameworkCore;
using Domen.AutoGenerated;
using Aplication.Services.EmployeeServices;
using Aplication.Services.ReportServices;

namespace Infrastructure.Servises
{
    public class ReportService : IReportService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeService _employeeService;
        private readonly ConpanyDbContext _conpanyDbContext;

        public ReportService(IEmployeeRepository employeeRepository, IEmployeeService employeeService, ConpanyDbContext conpanyDbContext)
        {
            _employeeRepository = employeeRepository;
            _employeeService = employeeService;
            _conpanyDbContext = conpanyDbContext;
        }

        public List<TaskReport> GetAllEmployeeReportAsync()
        {
            List<TaskReport> result = new List<TaskReport>();
            var reportEmployee = _conpanyDbContext.Set<Task>().Include(x=>x.Employee);
            foreach(var report  in reportEmployee)
            {
                    result.Add(new TaskReport
                    {
                        Task = report.Name,
                        EmployeName = report.Employee.EmployeeName,
                        CompletedDate = DateOnly.FromDateTime(report.Starttime??DateTime.Today)
                    });
            }
         return result;
        }
        public  List<ProjectReport> GetAllProjectReportAsync()
        {
            List<ProjectReport> result = new List<ProjectReport>();
            var projects = _conpanyDbContext.Set<Project>().Include(x => x.Tasks);
            foreach (var report  in projects)
            {
                result.Add(new ProjectReport
                {
                    Name = report.Name,
                    TaskIds = report.Tasks.Select(s => s.Id).ToList(),
                    Appointedday = DateOnly.FromDateTime(report.Appointedday??DateTime.Today)
                }); 
            }
            return result;
      
        }

    
    }

    
}
