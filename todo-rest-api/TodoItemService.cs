using System;
using System.Collections.Generic;

namespace todo_rest_api
{
    public class TodoItemService
    {
        private List<TodoItem> todoItems = new List<TodoItem> {
            new TodoItem() { Id = 1, Title = "Implement read", Description = "Some description", DueDate = DateTime.Now, Done = false},
            new TodoItem() { Id = 2, Title = "Implement create" }
        };
        private int lastId = 2;
        public List<TodoItem> GetAll()
        {
            return todoItems;
        }
        public TodoItem GetById(int todoItem)
        {
            return todoItems[todoItem];
        }
        public TodoItem Create(TodoItem item)
        {
            item.Id = ++lastId;
            todoItems.Add(item);
            return item;
        }
        public bool Delete(int index)
        {
            try
            {
                todoItems.RemoveAt(index);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<TodoItem> PutTask(int index,TodoItem task)
        {
            todoItems.Insert(index, task);
            return GetAll();
        }
    }
}