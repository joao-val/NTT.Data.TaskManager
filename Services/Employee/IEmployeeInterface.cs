using TaskManager.Models;

namespace TaskManager.Services.Employee
{
    public interface IEmployeeInterface
    {
        Task<ResponseModel<List<EmployeeModel>>> GetAllEmployees();
        Task<ResponseModel<EmployeeModel>> GetEmployeeById(int idEmployee);
        Task<ResponseModel<EmployeeModel>> GetEmployeeByTaskId(int idTask);
    }
}
