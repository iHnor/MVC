using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace todo_rest_api
{

    [Route("collection")]
    [ApiController]
    public class CollectionController:ControllerBase
    {
        private TodoItemService todoItemsService;
        public CollectionController(TodoItemService service)
        {
            this.todoItemsService = service;
        }

        [HttpGet("/today")]
        public ActionResult<List<TaskCollectionDTO>> TodayTask()
        {
            return todoItemsService.TodayTask();
        }
    }
}