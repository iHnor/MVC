using System;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace todo_rest_api
{
    public class TodoListContext : DbContext
    {
        public DbSet<TodoItem> TodoTask { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Username=admin;Password=12341234qs;Database=todo");
        }
    }

    public class TodoTask
    {
        public int taskId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime duedate { get; set; }
        public bool done { get; set; }

        public int listId { get; set; }
        public TodoList TodoList { get; set; }

    }
    public class TodoLists
    {
        public int listId { get; set; }
        public string title { get; set; }
        public List<TodoTask> TodoTasks { get; set; }


    }
}