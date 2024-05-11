using Domen.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services.Token
{
    public  interface IProjectReportSevice
    {
        List<ProjectReport> GetAllEmployeeReportAsync();
        Task<string> GetAllProjectReportAsync();
        Task<string> GetAllUserReportAsync();
    }
}
