using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.EmtityDTO.ProjectDto
{
    public  class ProjectGetDto : ProjectBaseDto
    {

        public int Id { get; set; }
        public int? ProjectTypeId { get; set; }
        public int? Organizationid { get; set; }

        
    }
}
