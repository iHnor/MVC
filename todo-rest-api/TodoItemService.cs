using System.Linq;
using System.Collections.Generic;
using System.Linq;
using System;
namespace todo_rest_api
{
    public class TodoItemService
    {
        private TodoListContext _context;
        public TodoItemService(TodoListContext context)
        {
            this._context = context;
        }

        public List<TodoTask> GetTasksInList(int listId)
        {
            List<TodoTask> tasks = new List<TodoTask>();
            foreach (var task in _context.TodoTasks)
            {
                if (task.TodoListId == listId)
                {
                    tasks.Add(task);
                }
            }
            return tasks;
        }
        public void CreateList(TodoList list)
        {
            _context.TodoLists.Add(list);
            _context.SaveChanges();
        }

        public void DeleteList(int id)
        {
            var searchElem = _context.TodoLists.SingleOrDefault(i => i.Id == id);
            if (searchElem != null)
            {
                _context.TodoLists.Remove(searchElem);
                _context.SaveChanges();
            }
        }

        public void CreateTask(TodoTask task)
        {
            _context.TodoTasks.Add(task);
            _context.SaveChanges();
        }
        public void DeleteTask(int id)
        {
            var searchElem = _context.TodoTasks.SingleOrDefault(i => i.Id == id);
            if (searchElem != null)
            {
                _context.TodoTasks.Remove(searchElem);
                _context.SaveChanges();
            }
        }
        public TodoTask GetTask(int id)
        {
            return _context.TodoTasks.Single(i => i.Id == id);
        }

        public DashboardDTO Dashboard()
        {
            DashboardDTO dashboard = new DashboardDTO();
            dashboard.todayTasks = _context.TodoTasks
                .Where(d => (DateTime.Today <= d.Duedate) && (d.Duedate < DateTime.Today.AddDays(1)))
                .Count();
            return  dashboard;
        }
        // private List<TodoList> todoLists = new List<TodoList> {
        //     new TodoList() {Id = 1, Title = "First list"},
        //     new TodoList() {Id = 2, Title = "Second list"}
        // };
        // private int lastIdTask = 0;
        // private int lastIdList = 2;


        // public List<TodoList> GetAllLists()
        // {
        //     return todoLists;
        // }


        // public TodoList GetListById(int id)
        // {
        //     return todoLists[id];
        // }

        // public List<TodoItem> GetAllTask(int listId)
        // {
        //     return todoLists[listId].List;
        // }

        // public TodoList CreateList(TodoList list)
        // {
        //     list.Id = ++lastIdList;
        //     todoLists.Add(list);
        //     return list;
        // }

        // public bool PutList(int id, TodoList list)
        // {
        //     foreach (var t in todoLists)
        //     {
        //         if (t.Id == id)
        //         {
        //             t.Title = list.Title;
        //             t.List = list.List;
        //             return true;
        //         }
        //     }
        //     return false;
        // }
        // public bool PatchList(int id, TodoList list)
        // {
        //     foreach (var t in todoLists)
        //     {
        //         if (t.Id == id)
        //         {
        //             t.Title = list?.Title;
        //             t.List = list?.List;
        //             return true;
        //         }
        //     }
        //     return false;
        // }
        // public bool DeleteTodoList(int id)
        // {
        //     try
        //     {
        //         todoLists.RemoveAt(id);
        //         return true;
        //     }
        //     catch
        //     {
        //         return false;
        //     }
        // }

        // public List<TodoItem> GetAllTaskInList(int listId)
        // {
        //     return todoLists[listId].List;
        // }
        // public TodoItem GetListById(int listId, int id)
        // {
        //     return todoLists[listId].List[id];
        // }
        // public TodoItem CreateTaskInList(int listId, TodoItem list)
        // {
        //     list.Id = ++lastIdTask;
        //     todoLists[listId].List.Add(list);
        //     return list;
        // }
        // public bool PutTaskInList(int listId, int id, TodoItem task)
        // {
        //     foreach (var t in todoLists[listId].List)
        //     {
        //         if (t.Id == id)
        //         {
        //             t.Title = task.Title;
        //             t.Description = task.Description;
        //             t.DueDate = task.DueDate;
        //             t.Done = task.Done;
        //             return true;
        //         }
        //     }
        //     return false;

        // }

        // public bool PatchTaskInList(int listId, int id, TodoItem task)
        // {
        //     foreach (var t in todoLists[listId].List)
        //     {
        //         if (t.Id == id)
        //         {
        //             t.Title = task?.Title;
        //             t.Description = task?.Description;
        //             t.DueDate = task?.DueDate;
        //             t.Done = task?.Done;
        //             return true;
        //         }
        //     }
        //     return false;
        // }
        // public bool DeleteTask(int listId, int id)
        // {
        //     try
        //     {
        //         todoLists[listId].List.RemoveAt(id);
        //         return true;
        //     }
        //     catch
        //     {
        //         return false;
        //     }
        // }
    }
}