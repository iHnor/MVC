using System;
using System.Collections.Generic;

namespace todo_rest_api
{
    public class DashboardDTO
    {
        public int todayTasks { get; set; }
        public List<TaskDashboardDTO> unDoneList { get; set; }
        public DashboardDTO()
        {
            unDoneList = new List<TaskDashboardDTO>();
        }

        public DashboardDTO(List<TaskDashboardDTO> unDoneList, int todayTasks)
        {
            this.todayTasks = todayTasks;
            this.unDoneList = unDoneList;
        }
    }

    public class TaskDashboardDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CountUndoneTasks { get; set; }
    }
}