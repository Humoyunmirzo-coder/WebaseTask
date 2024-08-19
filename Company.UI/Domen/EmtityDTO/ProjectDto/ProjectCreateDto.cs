namespace Domen.EmtityDTO.ProjectDto
{
    public class ProjectCreateDto : ProjectBaseDto
    {
        public int? Ownerid { get; set; }
        public int? ProjectTypeId { get; set; }
        public int? ProjectLevelId { get; set; }
        public int? ImportanceLevelId { get; set; }
        public int? Organizationid { get; set; }
        public int? AssigneeId { get; set; }

    }
}
