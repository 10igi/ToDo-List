using System;

namespace ToDoList.Backend
{
    public class TaskTag
    {
        //ForeignKeys
        public int TaskId { get; set; }
        public int TagId { get; set; }

        //Navigation
        public Tag Tag { get; set; }
        public Task Task { get; set; }
    }
}
