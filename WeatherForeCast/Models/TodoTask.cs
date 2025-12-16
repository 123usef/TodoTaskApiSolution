using System.ComponentModel.DataAnnotations.Schema;

namespace TodoTaskApi.Models
{
    public class TodoTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DeadLine { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsCompleted { get; set; }

        //RelationShip
        [ForeignKey(nameof(taskCategory))]
        public int TaskCategoryId { get; set; }
        public TaskCategory taskCategory { get; set; }
    }
}
