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

        public bool PutTask(int id, TodoItem task)
        {
            foreach (var t in todoItems)
            {
                if (t.Id == id)
                {
                    t.Title = task.Title;
                    t.Description = task.Description;
                    t.DueDate = task.DueDate;
                    t.Done = task.Done;
                    return true;
                }
            }
            return false;

        }
        public bool PatchTask(int id, TodoItem task)
        {
            foreach (var t in todoItems)
            {
                if(t.Id == id)
                {
                    t.Title = task?.Title;
                    t.Description = task?.Description;
                    t.DueDate = task?.DueDate;
                    t.Done = task?.Done;
                    return true;
                }
            }
            return false;
        }
    }
}