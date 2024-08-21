namespace Domen.EmtityDTO.TaskDto
{
    public class TaskCreateDto : TaskBaseDto
    {
        public int? ProjectId { get; set; }
        public int? EmployeeId { get; set; }
        public int? Taskstatus { get; set; }
        public int? Tasklevel { get; set; }
        public int? Importantlevel { get; set; }
    }
}
