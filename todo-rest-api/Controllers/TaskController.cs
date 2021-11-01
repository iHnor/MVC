using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace todo_rest_api.Controllers.Tasks
{
    [Route("task")]

    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private TodoItemService todoItemsService;
        public TodoItemController(TodoItemService service)
        {
            this.todoItemsService = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> GetTodoItems(int listId)
        {
            return todoItemsService.GetAllTaskInList(listId);
        }

        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetTodoItem(int listId, int id)
        {
            return todoItemsService.GetListById(listId, id);
        }

        [HttpPost]
        public ActionResult<TodoItem> CreateTodoItem(int listId, TodoItem task)
        {
            TodoItem createdItem = todoItemsService.CreateTaskInList(listId, task);
            return Created($"task{createdItem.Id}", createdItem);
        }

        [HttpPut("{id}")]
        public ActionResult PutTodoTask(int listId, int id, TodoItem task)
        {
            return todoItemsService.PutTaskInList(listId, id, task) ? StatusCode(204) : StatusCode(404);
        }

        [HttpPatch("{id}")]
        public ActionResult PatchTodoTask(int listId, int id, TodoItem task)
        {
            return todoItemsService.PatchTaskInList(listId, id, task) ? StatusCode(204) : StatusCode(404);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTodoTask(int listId, int id)
        {
            return todoItemsService.DeleteTask(listId, id) ? StatusCode(204) : StatusCode(404);
        }
    }
}
