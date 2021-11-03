using System;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace todo_rest_api
{
    public class TodoListContext : DbContext
    {
        public DbSet<TodoTask> TodoTasks { get; set; }
        public DbSet<TodoList> TodoLists { get; set; }

        public TodoListContext(DbContextOptions<TodoListContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
               .LogTo(Console.WriteLine);
        }
    }



}