using System;

namespace ToDoList.Backend
{
    public class Task
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsComplete { get; set; }
        public string Description { get; set; }

        //ForeignKey
        public int ListId { get; set; }
        public int TagId { get; set; }

        //Navigation
        public List<TaskTag> TaskTags { get; set; }
        public List<Tag> Tags { get; set; }

        public List List { get; set; }

        public ICollection<Subtask> Subtasks { get; } = new List<Subtask>();
    }
}
