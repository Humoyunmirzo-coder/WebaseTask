﻿using Domen.AutoGenerated;
using Task = Domen.AutoGenerated.Task;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.EmtityDTO.ProjectDto
{
    public   class ProjectBaseDto
    {

        public int? Ownerid { get; set; }
        public int? ProjectTypeId { get; set; }
        public int? ProjectLevelId { get; set; }
        public int? ImportanceLevelId { get; set; }
        public int? Organizationid { get; set; }

     

    }
}
