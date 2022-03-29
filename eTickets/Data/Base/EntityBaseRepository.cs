using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace eTickets.Data.Base;

public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
{
    private readonly AppDbContext _dbContext;

    protected EntityBaseRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<IEnumerable<T>> GetAllAsync()
    {
        var result = await _dbContext.Set<T>().ToListAsync();
        return result;
    }

    public async Task<T?> GetByIdAsync(int id)=> await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);



    public async Task AddAsync(T entity)
    {
        await _dbContext.Set<T>().AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        
    }


    public async  Task UpdateAsync(int id, T entity)
    {
        EntityEntry entityEntry =   _dbContext.Entry<T>(entity);
        entityEntry.State =  EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        
    }

    public async Task DeleteAsync(int id)
    {
        var entity =  await _dbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        if (entity != null)
        {
            EntityEntry entityEntry =   _dbContext.Entry<T>(entity);
            entityEntry.State =  EntityState.Deleted; 
            await _dbContext.SaveChangesAsync();
        }
        
    }
}