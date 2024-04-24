using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TODO.Core;
using TODO.Core.Models;

namespace TODO.Data;

public interface IToDoDbContext
{
    DbSet<T> Set<T>() where T : class;
    EntityEntry<T> Entry<T>(T entity) where T : class;
    DbSet<Item> Items { get; set; }
    void ExecuteSqlRaw(string sql, params object[] parameters);
    int SaveChanges();
}