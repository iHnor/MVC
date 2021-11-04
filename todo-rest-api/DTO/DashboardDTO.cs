using System;
using System.Collections.Generic;

namespace todo_rest_api
{
    public class DashboardDTO
    {
        public int todayTasks { get; set; }
        public List<TaskDashboardDTO> unDoneList { get; set; }

        public DashboardDTO(List<TaskDashboardDTO> unDoneList, int todayTasks)
        {
            this.todayTasks = todayTasks;
            this.unDoneList = unDoneList;
        }
    }

    public class TaskDashboardDTO
    {
        public int id { get; set; }
        public string title { get; set; }
        public int countUndoneTasks { get; set; }
    }
}