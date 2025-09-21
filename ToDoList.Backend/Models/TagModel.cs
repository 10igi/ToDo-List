using System;

namespace ToDoList.Backend
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation
        public ICollection<TaskTag> TaskTags { get; } = new List<TaskTag>();
    }
} 
