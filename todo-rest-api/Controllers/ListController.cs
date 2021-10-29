using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace todo_rest_api.Controllers.List
{
    [Route("list")]
    [ApiController]
    public class TodoItemController : ControllerBase
    {
        private TodoItemService todoItemsService;
        public TodoItemController(TodoItemService service)
        {
            this.todoItemsService = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TodoList>> GetTodoList()
        {
            return todoItemsService.GetAllLists();
        }

        [HttpGet("{id}")]
        public ActionResult<TodoList> GetTodoList(int id)
        {
            return todoItemsService.GetListById(id);
        }

        [HttpPost]
        public ActionResult<TodoList> CreateTodoList(TodoList list)
        {
            TodoList createdItem = todoItemsService.CreateList(list);
            return Created($"task{createdItem.Id}", createdItem);
        }

        [HttpPut("{id}")]
        public ActionResult PutTodoList(int id, TodoList list)
        {
            return todoItemsService.PutList(id, list) ? StatusCode(204) : StatusCode(404);
        }

        [HttpPatch("{id}")]
        public ActionResult PatchTodoList(int id, TodoList list)
        {
            return todoItemsService.PatchList(id, list) ? StatusCode(204) : StatusCode(404);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTodoList(int id)
        {
            return todoItemsService.DeleteTodoList(id) ? StatusCode(204) : StatusCode(404);
        }
    }
}
