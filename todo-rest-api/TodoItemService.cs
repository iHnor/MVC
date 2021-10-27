using System;
using System.Collections.Generic;

namespace todo_rest_api
{
    public class TodoItemService
    {
        private List<TodoItem> todoItems = new List<TodoItem> {
            new TodoItem() { Id = 1, Title = "Implement read" },
            new TodoItem() { Id = 2, Title = "Implement create" }
        };
        private int lastId = 2;
        public List<TodoItem> GetAll()
        {
            return todoItems;
        }

        public TodoItem Create(TodoItem item)
        {
            item.Id = ++lastId;
            todoItems.Add(item);
            return item;
        }
    }
}