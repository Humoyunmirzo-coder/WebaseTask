using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.EmtityDTO.RoleDto
{
    public  class RoleGetDto : RoleBaseDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
 

    }
}
