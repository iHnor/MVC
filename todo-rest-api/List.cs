using System;
using System.Collections.Generic;

namespace todo_rest_api
{
    public class TodoList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<TodoItem> List { get; set; }
    
        public TodoList()
        {
            List = new List<TodoItem>();
        }
    }


}