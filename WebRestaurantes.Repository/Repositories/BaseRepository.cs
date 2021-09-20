using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebRestaurantes.Domain;

namespace WebRestaurantes.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly WebRestaurantesContext _webRestaurantesContext;

        public BaseRepository(WebRestaurantesContext webRestaurantesContext)
        {
            _webRestaurantesContext = webRestaurantesContext;
            _webRestaurantesContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;            
        }

        public void Add<T>(TEntity entity) 
        {
            _webRestaurantesContext.Add(entity);
        } 

        public void Delete<T>(TEntity entity)
        {
            _webRestaurantesContext.Remove(entity);
        }

        public void Update<T>(TEntity entity) 
        {
            _webRestaurantesContext.Update(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            // retorno maior que 0 adicionou no bd
            return (await _webRestaurantesContext.SaveChangesAsync()) > 0;
        }

        public void DeleteRange<T>(TEntity[] entityArray)
        {
            _webRestaurantesContext.RemoveRange(entityArray);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _webRestaurantesContext.Set<TEntity>().ToListAsync();
        }
    }
}
