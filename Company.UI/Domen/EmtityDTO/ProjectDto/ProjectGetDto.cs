using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.EmtityDTO.ProjectDto
{
    public  class ProjectGetDto : ProjectBaseDto
    {

        public int? Ownerid { get; set; }
        public int? ProjectTypeId { get; set; }
        public int? ProjectLevelId { get; set; }
        public int? ImportanceLevelId { get; set; }
        public DateOnly? Appointedday { get; set; }
        public int? Organizationid { get; set; }
        public int? AssigneeId {  get; set; }
        
    }
}
