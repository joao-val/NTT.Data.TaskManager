using System.Text.Json.Serialization;
using TaskManager.DTO.Bind;

namespace TaskManager.DTO.Task
{
    public class TaskCreationDto
    {
        public string Summary { get; set; }

        public EmployeeBindDto Employee { get; set; }
    }
}
