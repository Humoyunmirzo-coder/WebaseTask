using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.EmtityDTO.TaskDto
{
    public  class TaskGetDto : TaskBaseDto
    {
        public int Id { get; set; }
        public int? ProjectId { get; set; }
        public int? EmployeeId { get; set; }
        public int? Taskstatus { get; set; }
        public DateTime? Starttime { get; set; }
        public DateTime? Endtime { get; set; }
        public int? Tasklevel { get; set; }
        public int? Importantlevel { get; set; }
    }
}
