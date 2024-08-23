namespace Domen.EmtityDTO.TaskDto
{
    public class TaskGetDto : TaskBaseDto
    {
        public int Id { get; set; }
        public int? ProjectId { get; set; }
        public int? EmployeeId { get; set; }
        public int? Taskstatus { get; set; }

    }
}
