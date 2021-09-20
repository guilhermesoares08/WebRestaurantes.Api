using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebRestaurantes.Domain;

namespace WebRestaurantes.WebAPI.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    [ApiController] 
    public class RestaurantAddressController : ControllerBase
    {
        
        private readonly IRestaurantAddressService _restaurantAddressService;
        private readonly IMapper _mapper;

        public RestaurantAddressController(IRestaurantAddressService restaurantAddressService, IMapper mapper)
        {
            _restaurantAddressService = restaurantAddressService;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _restaurantAddressService.GetAllAsync();

                //var resultMap = _mapper.Map<IEnumerable<RestaurantDto>>(results);

                return Ok(results);
                
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou {ex.Message}");
            }
        }
    }
}