namespace TaskManager.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Summary { get; set; }
        public EmployeeModel Employee { get; set; }
    }
}
