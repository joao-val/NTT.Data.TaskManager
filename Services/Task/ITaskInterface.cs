using TaskManager.DTO.Task;
using TaskManager.Models;

namespace TaskManager.Services.Task
{
    public interface ITaskInterface
    {
        Task<ResponseModel<List<TaskModel>>> GetAllTasks();
        Task<ResponseModel<TaskModel>> GetTaskById(int taskId);
        Task<ResponseModel<List<TaskModel>>> GetTaskByEmployeeId(int employeeId);
        Task<ResponseModel<List<TaskModel>>> CreateTask(TaskCreationDto taskCreationDto);
        Task<ResponseModel<List<TaskModel>>> EditTask(TaskEditionDto taskEditionDto);
        Task<ResponseModel<List<TaskModel>>> DeleteTask(int taskId);
    }
}
