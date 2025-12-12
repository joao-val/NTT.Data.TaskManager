using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Task_Manager.Data;
using TaskManager.Models;

namespace TaskManager.Services.Employee
{
    public class EmployeeService : IEmployeeInterface
    {
        private readonly AppDbContext _context;
        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<EmployeeModel>>> GetAllEmployees()
        {
            ResponseModel <List<EmployeeModel>> response = new ResponseModel<List<EmployeeModel>>();
            try
            {

                var employees = await _context.Employees.ToListAsync();
                response.Data = employees;
                response.Message = "All employees were collected.";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public Task<ResponseModel<EmployeeModel>> GetEmployeeById(int idEmployee)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<EmployeeModel>> GetEmployeeByTaskId(int idTask)
        {
            throw new NotImplementedException();
        }
    }
}
