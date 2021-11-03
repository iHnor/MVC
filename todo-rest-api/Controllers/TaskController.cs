using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace todo_rest_api
{
    [Route("task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private TodoItemService todoItemsService;
        public TaskController(TodoItemService service)
        {
            this.todoItemsService = service;
        }

        [HttpPost]
        public IActionResult CreateTask(int listId, TodoTask task)
        {
            todoItemsService.CreateTask(listId, task);
            return Ok();
        }

        [HttpDelete("{id}")] 
        public IActionResult DeleteTask(int id)
        {
            todoItemsService.DeleteTask(id);
            return Ok();
        }  
        [HttpGet("{id}")]
        public ActionResult<TodoTask> GetTask(int id)
        {
            return todoItemsService.GetTask(id);
        }
    }
}
 // [HttpGet]
        // public IActionResult GetTodoTask(int listId)
        // {
        //     return todoItemsService.GetTodoTask(listId);
        // }
//         // [HttpGet("{id}")]
//         // public ActionResult<TodoItem> GetTodoItem(int listId, int id)
//         // {
//         //     return todoItemsService.GetListById(listId, id);
//         // }

//         

//         // [HttpPut("{id}")]
//         // public ActionResult PutTodoTask(int listId, int id, TodoItem task)
//         // {
//         //     return todoItemsService.PutTaskInList(listId, id, task) ? StatusCode(204) : StatusCode(404);
//         // }

//         // [HttpPatch("{id}")]
//         // public ActionResult PatchTodoTask(int listId, int id, TodoItem task)
//         // {
//         //     return todoItemsService.PatchTaskInList(listId, id, task) ? StatusCode(204) : StatusCode(404);
//         // }

//         // [HttpDelete("{id}")]
//         // public ActionResult DeleteTodoTask(int listId, int id)
//         // {
//         //     return todoItemsService.DeleteTask(listId, id) ? StatusCode(204) : StatusCode(404);
//         // }
//     }
// }
