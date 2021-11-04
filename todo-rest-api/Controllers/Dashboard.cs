using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace todo_rest_api
{
    [Route("dashboard")]
    [ApiController]
    public class DashboardController:ControllerBase
    {
        private TodoItemService todoItemsService;
        public DashboardController(TodoItemService service)
        {
            this.todoItemsService = service;
        }

        [HttpGet("/today")]
        public ActionResult<DashboardDTO> TodayTasks()
        {
            
            return todoItemsService.Dashboard();
        }  
    }

}