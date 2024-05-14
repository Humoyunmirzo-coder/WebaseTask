using Domen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.ReportServices
{
    public interface IReportService
    {
        List<TaskReport> GetAllEmployeeReportAsync();
        List<ProjectReport> GetAllProjectReportAsync();

    }
}
