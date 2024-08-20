namespace Domen.EmtityDTO.RoleDto
{
    public class RoleCreateDto : RoleBaseDto
    {
        public string FullName { get; set; } = null!;
        public string? Description { get; set; }

    }
}
