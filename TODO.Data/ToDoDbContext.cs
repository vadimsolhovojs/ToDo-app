using Microsoft.EntityFrameworkCore;
using TODO.Core;
using TODO.Core.Models;

namespace TODO.Data;

public class ToDoDbContext : DbContext, IToDoDbContext
{
    public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : 
        base(options)
    {
        
    }
    
    public DbSet <Item> Items { get; set; }
    public void ExecuteSqlRaw(string sql, params object[] parameters)
    {
        Database.ExecuteSqlRaw(sql, parameters);
    }
}

