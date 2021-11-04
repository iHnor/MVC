using System;
using System.Collections.Generic;

namespace todo_rest_api
{
    public class DashboardDTO
    {
        public int todayTasks { get; set; }
        public List<TaskDTO> unDoneList { get; set; }

        public DashboardDTO(List<TaskDTO> unDoneList, int todayTasks)
        {
            this.todayTasks = todayTasks;
            this.unDoneList = unDoneList;
        }
    }

    public class TaskDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public int countUndoneTasks { get; set; }
    }
}