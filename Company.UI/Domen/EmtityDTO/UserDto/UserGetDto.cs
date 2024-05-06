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
        public string Fullname { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime? Lastlogin { get; set; }
        public bool Isactive { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }

    }
}
