using TODO.Core;
using TODO.Core.Services;
using TODO.Data;

namespace TODO.Services;

public class EntityService<T> : IEntityService<T> where T: Entity
{
    protected readonly IToDoDbContext _context;

    public EntityService(IToDoDbContext context)
    {
        _context = context;
    }
    
    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T? GetById(int id)
    {
        return _context.Set<T>().SingleOrDefault(entity => entity.Id == id);
    }

    public void Create(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        _context.SaveChanges();
    }

    public void DeleteAll()
    {
        _context.Set<T>().RemoveRange(_context.Set<T>());
        _context.ExecuteSqlRaw($"DBCC CHECKIDENT ('Items', RESEED, 0)");
        _context.SaveChanges();
    }
}