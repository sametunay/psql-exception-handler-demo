using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ExceptionTest.Data;

public class DbOperations
{
    private readonly Context _context;
    private object entryLock = new object();

    public DbOperations(Context context)
    {
        _context = context;
    }

    private ICollection<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> condition) where TEntity : class
    {
        return _context.Set<TEntity>().Where(condition).ToList();
    }
    public TEntity Get<TEntity>(Expression<Func<TEntity, bool>> condition) where TEntity : class
    {
        return _context.Set<TEntity>().FirstOrDefault(condition);
    }
    public void Remove<TEntity>(TEntity data) where TEntity : class
    {
        _context.Remove(data);
        _context.SaveChanges();
    }
    public void Clear<TEntity>() where TEntity : class
    {
        _context.RemoveRange(_context.Set<TEntity>());
        _context.SaveChanges();
    }
    public void Add(params dynamic[] data)
    {
        _context.AddRange(data);
        _context.SaveChanges();
    }
    public void Update(params dynamic[] data)
    {
        _context.UpdateRange(data);
        _context.SaveChanges();
    }
}