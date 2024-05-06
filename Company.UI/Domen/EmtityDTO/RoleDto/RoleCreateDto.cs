using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.EmtityDTO.RoleDto
{
    public  class RoleCreateDto : RoleBaseDto
    {
        public string FullName { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsActive { get; set; }

    }
}
