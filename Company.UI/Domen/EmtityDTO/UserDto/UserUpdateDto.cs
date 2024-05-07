using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.EmtityDTO.UserDto
{
    public  class UserUpdateDto : UserBaseDto
    {
        public int Id { get; set; }
        public string? Username { get; set; } = null!;
        public string? Email { get; set; } = null!;
        public bool? Isactive { get; set; }
        public string? Phone { get; set; }
        public string Password { get; set; } 
        public required string Oldpassword {  get; set; } 

    }
}
