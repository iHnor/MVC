using System;
using System.Collections.Generic;

namespace todo_rest_api
{
    public class DashboardDTO
    {
        public int todayTasks { get; set; }
        public List<TaskDTO> doneList = new List<TaskDTO>();

        public DashboardDTO()
        {
            
        }
    }

    public class TaskDTO
    {
        private int id { get; set; }
        private string title { get; set; }
        private int count { get; set; }

        public TaskDTO(int id, string title, int count)
        {
            this.id = id;
            this.title = title;
            this.count = count;
        }
    }
}