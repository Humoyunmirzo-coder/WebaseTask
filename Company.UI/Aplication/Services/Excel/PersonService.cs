using Aplication.Services.EmployeeServices;
using Domen.EmtityDTO.EmployeeDto;
using Domen.Excel;
using Newtonsoft.Json;
using OfficeOpenXml;
using System.Net.Http.Headers;

namespace Aplication.Services.Excel
{
    public class PersonService : IPersonService
    {
        private readonly IEmployeeService _employeeService;

        public PersonService(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        private readonly HttpClient _httpClient;

        public PersonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }



       /* public async Task EmployeeCreateExcelFileAsync(List<EmployeeGetDto> persons)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Sarlavhalarni yozish
                worksheet.Cells[1, 1].Value = "ID";
                worksheet.Cells[1, 2].Value = "Full Name";
                worksheet.Cells[1, 3].Value = "Description";
                worksheet.Cells[1, 4].Value = "Is Active";

                // Ma'lumotlarni yozish
                for (int i = 0; i < persons.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = persons[i].Id;
                    worksheet.Cells[i + 2, 2].Value = persons[i].EmployeeName;
                    worksheet.Cells[i + 2, 3].Value = persons[i].Isactive;
                    worksheet.Cells[i + 2, 4].Value = persons[i].Salary;
                }

                // Excel faylini saqlash
                var fileInfo = new FileInfo("D:\\hp.xlsx");
                await package.SaveAsAsync(fileInfo);
            }
        }*/
    }
}
