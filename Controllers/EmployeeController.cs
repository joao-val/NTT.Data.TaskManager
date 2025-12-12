using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.DTO.Employee;
using TaskManager.Models;
using TaskManager.Services.Employee;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeInterface _employeeInterface;
        public EmployeeController(IEmployeeInterface employeeInterface)
        {
            _employeeInterface = employeeInterface;
        }

        [HttpGet("GetAllEmployees")]
        public async Task<ActionResult<ResponseModel<List<EmployeeModel>>>> GetAllEmployees()
        {
            var employees = await _employeeInterface.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("GetEmployeeById/{employeeId}")]
        public async Task<ActionResult<ResponseModel<EmployeeModel>>> GetEmployeeById(int employeeId)
        {
            var employee = await _employeeInterface.GetEmployeeById(employeeId);
            return Ok(employee);
        }

        [HttpGet("GetEmployeeByTaskId/{taskId}")]
        public async Task<ActionResult<ResponseModel<EmployeeModel>>> GetEmployeeByTaskId(int taskId)
        {
            var employee = await _employeeInterface.GetEmployeeByTaskId(taskId);
            return Ok(employee);
        }

        [HttpPost("CreateEmployee")]
        public async Task<ActionResult<ResponseModel<List<EmployeeModel>>>> CreateEmployee(EmployeeCreationDto employeeCreationDto)
        {
            var employee = await _employeeInterface.CreateEmployee(employeeCreationDto);
            return Ok(employee);
        }

        [HttpPut("EditEmployee")]
        public async Task<ActionResult<ResponseModel<List<EmployeeModel>>>> EditEmployee(EmployeeEditionDto employeeEditionDto)
        {
            var employee = await _employeeInterface.EditEmployee(employeeEditionDto);
            return Ok(employee);
        }

        [HttpDelete("DeleteEmployee")]
        public async Task<ActionResult<ResponseModel<List<EmployeeModel>>>> DeleteEmployee(int employeeId)
        {
            var employee = await _employeeInterface.DeleteEmployee(employeeId);
            return Ok(employee);
        }
    }
}
