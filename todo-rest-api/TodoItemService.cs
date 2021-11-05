using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Npgsql;

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
            List<TaskDashboardDTO> listResult = new List<TaskDashboardDTO>();
            
            string sql = "SELECT todo_lists.Id, todo_lists.title, COUNT(todo_tasks.done) FROM todo_lists LEFT JOIN todo_tasks ON todo_tasks.todo_list_id = todo_lists.id WHERE todo_tasks IS Null OR todo_tasks.done = 'false' GROUP BY todo_lists.Id ORDER BY todo_lists.Id";
            using var conn = new NpgsqlConnection(_context.Database.GetConnectionString());
            conn.Open();
            using (var cmd = new NpgsqlCommand(sql, conn))
            {
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                    {
                        listResult.Add(new TaskDashboardDTO()
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            CountUndoneTasks = reader.GetInt32(2)
                        });
                    }

            }
            conn.Close();

            var count = _context.TodoTasks
                .Where(d => (DateTime.Today <= d.Duedate) && (d.Duedate < DateTime.Today.AddDays(1)))
                .Count();

            // var listResult = _context.TodoLists
            //     .Include(l => l.TodoTasks)
            //     .Select(l => new TaskDashboardDTO()
            //     {
            //         id = l.Id,
            //         title = l.Title,
            //         countUndoneTasks = l.TodoTasks
            //             .Where(t => t.Done.Equals(false)).Count()

            //     })
            //     .OrderBy(l => l.id)
            //     .ToList();
            // return new DashboardDTO(listResult, count);

            return new DashboardDTO(listResult, count);
        }
        public List<TaskCollectionDTO> TodayTask()
        {
            var collectionList = _context.TodoTasks
                .Include(l => l.TodoList)
                .Select(l => new TaskCollectionDTO()
                {
                    id = l.Id,
                    Title = l.Title,
                    Description = l.Description,
                    Duedate = l.Duedate,
                    Done = l.Done,
                    list = new AboutList()
                    {
                        id = l.TodoList.Id,
                        title = l.TodoList.Title
                    }
                })
                .Where(d => (DateTime.Today <= d.Duedate) && (d.Duedate < DateTime.Today.AddDays(1)))
                .ToList();
            return collectionList;
        }
    }
}