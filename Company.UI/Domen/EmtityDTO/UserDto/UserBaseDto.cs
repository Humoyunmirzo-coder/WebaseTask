namespace Domen.EmtityDTO.UserDto
{
    public class UserBaseDto
    {


        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool Isactive { get; set; }
        public string? Phone { get; set; }



    }
}
