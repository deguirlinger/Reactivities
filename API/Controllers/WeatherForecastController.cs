using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly DataContext _context;

        public WeatherForecastController(DataContext context)
        {
            _context = context;
        }

        // GET /WeatherForecast
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> Get()
        {
            var weatherForecasts = await _context.WeatherForecasts.ToListAsync();
            return Ok(weatherForecasts);
        }

        // GET /WeatherForecast/2
        [HttpGet("{id}")]
        public async Task<ActionResult<WeatherForecast>> Get(int id)
        {
            var weatherForecast = await _context.WeatherForecasts.FindAsync(id);
            return Ok(weatherForecast);
        }
    }
}
