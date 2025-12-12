using TaskManager.DTO.Employee;
using TaskManager.Models;

namespace TaskManager.Services.Employee
{
    public interface IEmployeeInterface
    {
        Task<ResponseModel<List<EmployeeModel>>> GetAllEmployees();
        Task<ResponseModel<EmployeeModel>> GetEmployeeById(int idEmployee);
        Task<ResponseModel<EmployeeModel>> GetEmployeeByTaskId(int idTask);
        Task<ResponseModel<List<EmployeeModel>>> CreateEmployee(EmployeeCreationDto employeeCreationDto);
        Task<ResponseModel<List<EmployeeModel>>> EditEmployee(EmployeeEditionDto employeeEditionDto);
        Task<ResponseModel<List<EmployeeModel>>> DeleteEmployee(int employeeId);
    }
}
