using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace WebRestaurantes.Repository
{
    public class WebRestaurantesRepository : Interfaces.IWebRestaurantesRepository
    {
        private readonly WebRestaurantesContext _webRestaurantesContext;
        public WebRestaurantesRepository(WebRestaurantesContext WebRestaurantesContext)
        {
            _webRestaurantesContext = WebRestaurantesContext;
            _webRestaurantesContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public void Add<T>(T entity) where T : class
        {
            _webRestaurantesContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _webRestaurantesContext.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _webRestaurantesContext.Update(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            // retorno maior que 0 adicionou no bd
            return (await _webRestaurantesContext.SaveChangesAsync()) > 0;
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _webRestaurantesContext.RemoveRange(entityArray);
        }      
    }
}