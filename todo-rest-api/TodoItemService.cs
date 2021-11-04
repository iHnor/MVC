using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
            var count = _context.TodoTasks
                .Where(d => (DateTime.Today <= d.Duedate) && (d.Duedate < DateTime.Today.AddDays(1)))
                .Count();

            var listResult = _context.TodoLists
                .Include(l => l.TodoTasks)
                .Select(l => new TaskDashboardDTO(){
                    id = l.Id,
                    title = l.Title,
                    countUndoneTasks = l.TodoTasks
                        .Where(t => t.Done.Equals(false)).Count()

                })
                .OrderBy(l => l.id)
                .ToList();
                
            // var listResult = _context.TodoLists.FromSqlRaw("select todo_lists.id, todo_lists.title, count(todo_tasks.done) from todo_tasks right join todo_lists on todo_tasks.todo_list_id=todo_lists.id where done=false or todo_tasks is Null group by todo_lists.id").OrderBy(l => l.Id).ToList();    
            // List<TaskDTO> taskDTO = new List<TaskDTO>(); 
            // foreach(var l in listResult)
            // {
            //     taskDTO.Add(new TaskDTO(){
            //         id = l.Id,
            //         title = l.Title,
            //         countUndoneTasks = l.
            //     });
            // }
            return new DashboardDTO(listResult, count);
        }
        public List<TaskCollectionDTO> TodayTask()
        {
            var collectionList = _context.TodoTasks
                .Include(l => l.TodoList)
                .Select(l => new TaskCollectionDTO(){
                    id = l.Id,
                    Title = l.Title,
                    Description = l.Description,
                    Duedate = l.Duedate,
                    Done = l.Done,
                    titleTodo = l.TodoList.Title
                })
                .Where(d => (DateTime.Today <= d.Duedate) && (d.Duedate < DateTime.Today.AddDays(1)))
                .ToList();
            return collectionList;
        }
    }
}