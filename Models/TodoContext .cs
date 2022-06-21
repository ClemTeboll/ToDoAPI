using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public DbSet<ToDoItem> ToDoItems { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
                options.useMySql(Configuration.GetConnectionString("todolist_db"));
        }
    }
}