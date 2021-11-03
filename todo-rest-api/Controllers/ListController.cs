using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace todo_rest_api
{
    [Route("list")]
    [ApiController]
    public class ListController : ControllerBase
    {
        private TodoItemService todoItemsService;
        public ListController(TodoItemService service)
        {
            this.todoItemsService = service;
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteList(int id)
        {   
            todoItemsService.DeleteList(id);
            return Ok();
        }


        [HttpPost]
        public IActionResult CreateList(TodoList list)
        {
            todoItemsService.CreateList(list);
            return Ok();
        }
        
        [HttpGet("{listId}")]
        public ActionResult<List<TodoTask>> GetTasksInList(int listId)
        {
            return todoItemsService.GetTasksInList(listId);
        }
    }
}
