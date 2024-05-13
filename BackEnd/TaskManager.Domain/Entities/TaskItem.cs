using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManager.Domain.Entities;
[Table("Tasks")]
public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsCompleted { get; set; }
}
