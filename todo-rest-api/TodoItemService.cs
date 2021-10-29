using System;
using System.Collections.Generic;

namespace todo_rest_api
{
    public class TodoItemService
    {
        //     private List<TodoItem> todoItems = new List<TodoItem> {
        //         new TodoItem() { Id = 1, Title = "Implement read", Description = "Some description", DueDate = DateTime.Now, Done = false},
        //         new TodoItem() { Id = 2, Title = "Implement create" }
        //     };
        private List<TodoList> todoLists = new List<TodoList> {
            new TodoList() {Id = 1, Title = "First list"},
            new TodoList() {Id = 2, Title = "Second list"}
        };
        private int lastIdTask = 0;
        private int lastIdList = 2;


        public List<TodoList> GetAllLists()
        {
            return todoLists;
        }


        public TodoList GetListById(int id)
        {
            return todoLists[id];
        }

        public List<TodoItem> GetAllTask(int listId)
        {
            return todoLists[listId].List;
        }

        public TodoList CreateList(TodoList list)
        {
            list.Id = ++lastIdList;
            todoLists.Add(list);
            return list;
        }

        public bool PutList(int id, TodoList list)
        {
            foreach (var t in todoLists)
            {
                if (t.Id == id)
                {
                    t.Title = list.Title;
                    t.List = list.List;
                    return true;
                }
            }
            return false;
        }
        public bool PatchList(int id, TodoList list)
        {
            foreach (var t in todoLists)
            {
                if (t.Id == id)
                {
                    t.Title = list?.Title;
                    t.List = list?.List;
                    return true;
                }
            }
            return false;
        }
        public bool DeleteTodoList(int id)
        {
            try
            {
                todoLists.RemoveAt(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public List<TodoItem> GetAllTaskInList(int listId)
        {
            return todoLists[listId].List;
        }
        public TodoItem GetListById(int listId, int id)
        {
            return todoLists[listId].List[id];
        }
        public TodoItem CreateTaskInList(int listId, TodoItem list)
        {
            list.Id = ++lastIdTask;
            todoLists[listId].List.Add(list);
            return list;
        }
        public bool PutTaskInList(int listId, int id, TodoItem task)
        {
            foreach (var t in todoLists[listId].List)
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

        public bool PatchTaskInList(int listId, int id, TodoItem task)
        {
            foreach (var t in todoLists[listId].List)
            {
                if (t.Id == id)
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
        public bool DeleteTask(int listId, int id)
        {
            try
            {
                todoLists[listId].List.RemoveAt(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }


    // public TodoItem GetTaskById(int listId, int id)
    // {
    //     return todoLists[listId].List[id];
    // }
    //     public TodoItem Create(TodoItem item)
    //     {
    //         item.Id = ++lastId;
    //         todoItems.Add(item);
    //         return item;
    //     }
    //     
    //     public bool PutTask(int id, TodoItem task)
    //     {
    //         foreach (var t in todoItems)
    //         {
    //             if (t.Id == id)
    //             {
    //                 t.Title = task.Title;
    //                 t.Description = task.Description;
    //                 t.DueDate = task.DueDate;
    //                 t.Done = task.Done;
    //                 return true;
    //             }
    //         }
    //         return false;

    //     }
    //

}