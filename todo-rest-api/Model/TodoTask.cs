using System;

namespace todo_rest_api
{
    public class TodoTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Duedate { get; set; }
        public bool Done { get; set; }

        public int ListId { get; set; }
        public TodoList TodoList { get; set; }

    }
}