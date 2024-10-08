﻿namespace Domen.EmtityDTO.UserDto
{
    public class UserCreateDto : UserBaseDto
    {
        public string Fullname { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        public bool Isactive { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }

    }
}
