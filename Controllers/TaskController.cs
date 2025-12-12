using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManager.DTO.Task;
using TaskManager.Models;
using TaskManager.Services.Task;

namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskInterface _taskInterface;
        public TaskController(ITaskInterface taskInterface)
        {
            _taskInterface = taskInterface;
        }

        [HttpGet("GetAllTasks")]
        public async Task<ActionResult<ResponseModel<List<TaskModel>>>> GetAllEmployess()
        {
            var tasks = await _taskInterface.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("GetTaskById/{taskId}")]
        public async Task<ActionResult<ResponseModel<TaskModel>>> GetTaskById(int taskId)
        {
            var task = await _taskInterface.GetTaskById(taskId);
            return Ok(task);
        }

        [HttpGet("GetTaskByEmployeeId/{employeeId}")]
        public async Task<ActionResult<ResponseModel<TaskModel>>> GetTaskByEmployeeId(int employeeId)
        {
            var task = await _taskInterface.GetTaskByEmployeeId(employeeId);
            return Ok(task);
        }

        [HttpPost("CreateTask")]
        public async Task<ActionResult<ResponseModel<List<TaskModel>>>> CreateTask(TaskCreationDto taskCreationDto)
        {
            var task = await _taskInterface.CreateTask(taskCreationDto);
            return Ok(task);
        }

        [HttpPut("EditTask")]
        public async Task<ActionResult<ResponseModel<List<TaskModel>>>> EditTask(TaskEditionDto taskEditionDto)
        {
            var task = await _taskInterface.EditTask(taskEditionDto);
            return Ok(task);
        }

        [HttpDelete("DeleteTask")]
        public async Task<ActionResult<ResponseModel<List<TaskModel>>>> DeleteTask(int taskId)
        {
            var tasks = await _taskInterface.DeleteTask(taskId);
            return Ok(tasks);
        }
    }
}
