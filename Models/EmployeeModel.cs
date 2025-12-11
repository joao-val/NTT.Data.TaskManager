using System.Text.Json.Serialization;

namespace TaskManager.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        [JsonIgnore]
        public ICollection<TaskModel> Tasks { get; set; }
    }
}
