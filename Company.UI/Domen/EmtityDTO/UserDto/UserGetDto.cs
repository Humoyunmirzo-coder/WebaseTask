using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.EmtityDTO.UserDto
{
    public  class UserGetDto : UserBaseDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;

      
 

    }
}
