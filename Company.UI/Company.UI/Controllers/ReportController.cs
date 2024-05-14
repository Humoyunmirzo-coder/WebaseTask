using Aplication.Services.ReportServices;
using Domen.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.UI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;


        public ReportController(IReportService reportService)
        {
            _reportService = reportService;

        }

        [HttpGet("AllEmployeeReports")]
        public ActionResult<List<TaskReport>> GetAllEmployeeReports()
        {
            try
            {
                var reports = _reportService.GetAllEmployeeReportAsync();
                return Ok(reports);
            }
            catch (Exception ex)
            {
                // Log the exception details here as needed
                return StatusCode(500, "An error occurred while retrieving the reports. " + ex.Message);
            }
        }
        
        
        [HttpGet("AllProjectReports")]
        public ActionResult<List<ProjectReport>> GetAllProjectReports()
        {
            try
            {
                var reports = _reportService.GetAllProjectReportAsync();
                return Ok(reports);
            }
            catch (Exception ex)
            {
                // Log the exception details here as needed
                return StatusCode(500, "An error occurred while retrieving the reports. " + ex.Message);
            }
        }

    }
}
