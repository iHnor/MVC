using System;

namespace todo_rest_api
{
    public class TaskCollectionDTO
    {
        public AboutList list { get; set; }
        public int id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Duedate { get; set; }
        public bool Done { get; set; }
    }

    public class AboutList
    {
        public int id { get; set; }
        public string title { get; set; }
    }
}