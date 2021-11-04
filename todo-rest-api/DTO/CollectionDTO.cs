using System;
using System.Collections.Generic;

namespace todo_rest_api
{
    public class TaskCollectionDTO
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Duedate { get; set; }
        public bool Done { get; set; }
        public string titleTodo { get; set; }
    }
}