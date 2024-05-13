using TaskManager.Domain.Entities;

namespace TaskManager.Application.Interfaces;
public interface ITaskService
{
    Task<IEnumerable<TaskItem>> GetAllTasksAsync();
    Task<TaskItem> GetTaskByIdAsync(int id);
    Task<TaskItem> AddTaskAsync(TaskItem task);
    Task<bool> UpdateTaskAsync(int id, TaskItem task);
    Task<bool> DeleteTaskAsync(int id);
}
