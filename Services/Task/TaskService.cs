using Microsoft.EntityFrameworkCore;
using Task_Manager.Data;
using TaskManager.DTO.Employee;
using TaskManager.DTO.Task;
using TaskManager.Models;

namespace TaskManager.Services.Task
{
    public class TaskService : ITaskInterface
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<TaskModel>>> CreateTask(TaskCreationDto taskCreationDto)
        {
            ResponseModel<List<TaskModel>> response = new ResponseModel<List<TaskModel>>();
            try
            {
                var employee = await _context.Employees
                    .FirstOrDefaultAsync(employeeDatabase => employeeDatabase.Id == taskCreationDto.Employee.Id);

                if (employee == null)
                {
                    response.Message = "No employees found.";
                    return response;
                }

                var task = new TaskModel()
                {
                    Summary = taskCreationDto.Summary,
                    Employee = employee
                };

                _context.Add(task);
                await _context.SaveChangesAsync();
                response.Data = await _context.Tasks.Include(e => e.Employee).ToListAsync();

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<TaskModel>>> DeleteTask(int taskId)
        {
            ResponseModel<List<TaskModel>> response = new ResponseModel<List<TaskModel>>();

            try
            {
                var task = await _context.Tasks
                    .Include(e => e.Employee)
                    .FirstOrDefaultAsync(taskDatabase => taskDatabase.Id == taskId);

                if (task == null)
                {
                    response.Message = "No tasks were found.";
                    return response;
                }

                _context.Remove(task);
                await _context.SaveChangesAsync();
                response.Data = await _context.Tasks.ToListAsync();
                response.Message = "Task successfully deleted.";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<TaskModel>>> EditTask(TaskEditionDto taskEditionDto)
        {
            ResponseModel<List<TaskModel>> response = new ResponseModel<List<TaskModel>>();
            try
            {
                var task = await _context.Tasks
                    .Include(e => e.Employee)
                    .FirstOrDefaultAsync(taskDatabase => taskDatabase.Id == taskEditionDto.Id);

                var employee = await _context.Employees
                    .FirstOrDefaultAsync(employeeDatabase => employeeDatabase.Id == taskEditionDto.Employee.Id);

                if (employee == null)
                {
                    response.Message = "No employees were found.";
                    return response;
                }

                if (task == null)
                {
                    response.Message = "No tasks were found.";
                    return response;
                }

                task.Summary = taskEditionDto.Summary;
                task.Employee = employee;

                _context.Update(task);
                await _context.SaveChangesAsync();

                response.Data = await _context.Tasks.ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<TaskModel>>> GetAllTasks()
        {
            ResponseModel<List<TaskModel>> response = new ResponseModel<List<TaskModel>>();
            try
            {

                var tasks = await _context.Tasks.Include(e => e.Employee).ToListAsync();
                response.Data = tasks;
                response.Message = "All tasks were collected.";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<TaskModel>>> GetTaskByEmployeeId(int employeeId)
        {
            ResponseModel<List<TaskModel>> response = new ResponseModel<List<TaskModel>>();
            try
            {
                var task = await _context.Tasks
                    .Include(t => t.Employee)
                    .Where(taskDatabase => taskDatabase.Employee.Id == employeeId)
                    .ToListAsync();

                if (task.Where(e => e.Employee.Id == employeeId) == null)
                {
                    response.Message = "No employees found.";
                    response.Status = false;
                    return response;

                }

                if (task == null)
                {
                    response.Message = "No task found.";
                    response.Status = false;
                    return response;

                }

                response.Data = task;
                response.Message = "Tasks located.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<TaskModel>> GetTaskById(int taskId)
        {
            ResponseModel<TaskModel> response = new ResponseModel<TaskModel>();
            try
            {
                var task = await _context.Tasks
                    .Include(e => e.Employee)
                    .FirstOrDefaultAsync(taskDatabase => taskDatabase.Id == taskId);

                if (task == null)
                {
                    response.Message = "No tasks found.";
                    response.Status = false;
                    return response;
                }

                response.Data = task;
                response.Message = "Task successfully located.";

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
