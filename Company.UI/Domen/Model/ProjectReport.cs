using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.Model
{
    public  class ProjectReport
    {
        public string   Name { get; set; }
        public List<int>  TaskIds { get; set; }
        public DateOnly? Appointedday { get; set; }
    }
}
