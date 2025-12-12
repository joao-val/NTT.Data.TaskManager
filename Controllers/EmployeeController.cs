using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<ResponseModel<List<EmployeeModel>>>> GetAllEmployess()
        {
            var employees = await _employeeInterface.GetAllEmployees();
            return Ok(employees);
        }

    }
}
