using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Model
{
    public  class ProjectReport
    {
        public int  ProjectLevel { get; set; }
        public string EmployeName { get; set; }
        public DateOnly CompletedDate { get; set; }
    }
}
