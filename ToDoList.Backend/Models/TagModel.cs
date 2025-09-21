using System;

namespace ToDoList.Backend
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //Navigation
        public List<TaskTag> TaskTags { get; set; }
        public List<Task> Task { get; set; }
    }
} 
