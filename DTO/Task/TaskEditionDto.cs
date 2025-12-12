using TaskManager.DTO.Bind;
using TaskManager.Models;

namespace TaskManager.DTO.Task
{
    public class TaskEditionDto
    {
        public int Id { get; set; }
        public string Summary { get; set; }
        public EmployeeBindDto Employee { get; set; }
    }
}
