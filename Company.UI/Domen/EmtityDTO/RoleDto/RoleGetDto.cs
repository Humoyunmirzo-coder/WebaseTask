namespace Domen.EmtityDTO.RoleDto
{
    public class RoleGetDto : RoleBaseDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string? Description { get; set; }

    }
}
