using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Task_Manager.Data;
using TaskManager.DTO.Employee;
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

        public async Task<ResponseModel<List<EmployeeModel>>> CreateEmployee(EmployeeCreationDto employeeCreationDto)
        {
            ResponseModel<List<EmployeeModel>> response = new ResponseModel<List<EmployeeModel>>();
            try
            {
                var employee = new EmployeeModel()
                {
                    Name = employeeCreationDto.Name,
                    Surname = employeeCreationDto.Surname
                };

                _context.Add(employee);
                await _context.SaveChangesAsync();

                response.Data = await _context.Employees.ToListAsync();
                response.Message = "Employee successfully created!";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<EmployeeModel>>> DeleteEmployee(int employeeId)
        {
            ResponseModel<List<EmployeeModel>> response = new ResponseModel<List<EmployeeModel>>();

            try
            {
                var employee = await _context.Employees
                    .FirstOrDefaultAsync(employeeDatabase => employeeDatabase.Id == employeeId);

                if (employee == null)
                {
                    response.Message = "No employees found.";
                    return response;
                }

                _context.Remove(employee);
                await _context.SaveChangesAsync();
                response.Data = await _context.Employees.ToListAsync();
                response.Message = "Employee successfully deleted."; 

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<EmployeeModel>>> EditEmployee(EmployeeEditionDto employeeEditionDto)
        {
            ResponseModel<List<EmployeeModel>> response = new ResponseModel<List<EmployeeModel>>();

            try
            {
                var employee = await _context.Employees
                    .FirstOrDefaultAsync(employeeDatabase => employeeDatabase.Id == employeeEditionDto.Id);

                if (employee == null)
                {
                    response.Message = "No employees found.";
                    return response;
                }

                employee.Name = employeeEditionDto.Name;
                employee.Surname = employeeEditionDto.Surname;

                _context.Update(employee);
                await _context.SaveChangesAsync();

                response.Data = await _context.Employees.ToListAsync();
                response.Message = "Employee suceessfully edited!";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
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

        public async Task<ResponseModel<EmployeeModel>> GetEmployeeById(int employeeId)
        {
            ResponseModel<EmployeeModel> response = new ResponseModel<EmployeeModel>();
            try
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(employeeDatabase => employeeDatabase.Id == employeeId);

                if (employee == null)
                {
                    response.Message = "No employees found.";
                    response.Status = false;
                    return response;
                }

                response.Data = employee;
                response.Message = "Employee located.";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<EmployeeModel>> GetEmployeeByTaskId(int taskId)
        {
            ResponseModel<EmployeeModel> response = new ResponseModel<EmployeeModel>();
            try
            {
                var employee = await _context.Tasks
                    .Include(e => e.Employee)
                    .FirstOrDefaultAsync(taskDatabase => taskDatabase.Id == taskId);

                if (employee == null)
                {
                    response.Message = "No employees found.";
                    response.Status = false;
                    return response;

                }

                response.Data = employee.Employee;
                response.Message = "Employee located.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
