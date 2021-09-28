using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebRestaurantes.Domain;

namespace WebRestaurantes.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulingController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISchedulingService _schedulingService;

        public SchedulingController(ISchedulingService schedulingService, IMapper mapper)
        {
            _schedulingService = schedulingService;
            _mapper = mapper;
        }
         
        [HttpPost("{restaurantId}")]
        [AllowAnonymous]
        public IActionResult Get(int restaurantId, [FromBody] ScheduleFilter obj)
        {
            try
            {
                var results = _schedulingService.GetAvailableScheduling(restaurantId, obj.ScheduleDate, obj.ScheduleTime, obj.RestaurantVendorId);

                return Ok(results);
            }
            catch (System.Exception ex)
            {
                string innerEx = "";//ex.InnerException.Message;
                string exMessage = ex.Message;
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco Dados Falhou{exMessage + "|" + innerEx}");
            }
        }
    }
}