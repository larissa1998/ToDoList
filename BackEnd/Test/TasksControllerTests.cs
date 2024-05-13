using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Controllers;
using TaskManager.Application.Interfaces;
using TaskManager.Domain.Entities;

public class TasksControllerTests
{
    private readonly Mock<ITaskService> _mockService;
    private readonly TasksController _controller;

    public TasksControllerTests()
    {
        _mockService = new Mock<ITaskService>();
        _controller = new TasksController(_mockService.Object);
    }

    [Fact]
    public async Task GetAllTasks_ReturnsOkObjectResult_WithListOfTasks()
    {
        var mockTasks = new List<TaskItem>
    {
        new TaskItem { Id = 1, Title = "Test Task 1", IsCompleted = false },
        new TaskItem { Id = 2, Title = "Test Task 2", IsCompleted = true }
    };
        _mockService.Setup(x => x.GetAllTasksAsync()).ReturnsAsync(mockTasks);

        var result = await _controller.GetAllTasks();

        var viewResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<TaskItem>>(viewResult.Value);
        Assert.Equal(2, ((List<TaskItem>)model).Count);
    }

    [Fact]
    public async Task GetAllTasks_ReturnsEmptyList_WhenNoTasksExist()
    {
        _mockService.Setup(x => x.GetAllTasksAsync()).ReturnsAsync(new List<TaskItem>());

        var result = await _controller.GetAllTasks();

        var viewResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsAssignableFrom<IEnumerable<TaskItem>>(viewResult.Value);
        Assert.Empty(model);
    }

    [Fact]
    public async Task GetTask_ReturnsOkObjectResult_WithTask()
    {
        var task = new TaskItem { Id = 1, Title = "Existing Task", IsCompleted = false };
        _mockService.Setup(x => x.GetTaskByIdAsync(1)).ReturnsAsync(task);

        var result = await _controller.GetTask(1);

        var viewResult = Assert.IsType<OkObjectResult>(result);
        var model = Assert.IsType<TaskItem>(viewResult.Value);
        Assert.Equal("Existing Task", model.Title);
    }

    [Fact]
    public async Task GetTask_ReturnsNotFound_WhenTaskDoesNotExist()
    {
        _mockService.Setup(x => x.GetTaskByIdAsync(It.IsAny<int>())).ReturnsAsync((TaskItem)null);

        var result = await _controller.GetTask(999);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task CreateTask_ReturnsCreatedAtActionResult_WithTask()
    {
        var newTask = new TaskItem { Title = "New Task", IsCompleted = false };
        _mockService.Setup(x => x.AddTaskAsync(It.IsAny<TaskItem>())).ReturnsAsync(newTask);

        var result = await _controller.CreateTask(newTask);

        var actionResult = Assert.IsType<CreatedAtActionResult>(result);
        var returnValue = Assert.IsType<TaskItem>(actionResult.Value);
        Assert.Equal("New Task", returnValue.Title);
    }


    [Fact]
    public async Task UpdateTaskReturnsNoContentWhenSuccessful()
    {
        var existingTask = new TaskItem { Id = 1, Title = "Existing Task", IsCompleted = false };
        _mockService.Setup(x => x.UpdateTaskAsync(existingTask.Id, It.IsAny<TaskItem>())).ReturnsAsync(true);

        var result = await _controller.UpdateTask(existingTask.Id, existingTask);

        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task UpdateTaskReturnsNotFoundWhenTaskDoesNotExist()
    {
        var nonExistingTask = new TaskItem { Id = 999, Title = "Non Existing", IsCompleted = false };
        _mockService.Setup(x => x.UpdateTaskAsync(nonExistingTask.Id, It.IsAny<TaskItem>())).ReturnsAsync(false);

        var result = await _controller.UpdateTask(nonExistingTask.Id, nonExistingTask);

        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task UpdateTask_ReturnsNoContent_WhenSuccessful()
    {
        var existingTask = new TaskItem { Id = 1, Title = "Existing Task", IsCompleted = false };
        _mockService.Setup(x => x.UpdateTaskAsync(existingTask.Id, It.IsAny<TaskItem>())).ReturnsAsync(true);

        var result = await _controller.UpdateTask(existingTask.Id, existingTask);

        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task UpdateTask_ReturnsNotFound_WhenTaskDoesNotExist()
    {
        var nonExistingTask = new TaskItem { Id = 999, Title = "No Existing", IsCompleted = false };
        _mockService.Setup(x => x.UpdateTaskAsync(nonExistingTask.Id, It.IsAny<TaskItem>())).ReturnsAsync(false);

        var result = await _controller.UpdateTask(nonExistingTask.Id, nonExistingTask);

        Assert.IsType<NotFoundResult>(result);
    }
}