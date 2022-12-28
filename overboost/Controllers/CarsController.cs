using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using overboost.Models;
using overboost.Services;

namespace overboost.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        public CarsController(JsonFileCarsService CarsService)
        {
            this.CarsService = CarsService;
        }

        public JsonFileCarsService CarsService { get; }

        [HttpGet]

        public IEnumerable<Car> Get()
        {
            return CarsService.GetCars();
        }

        //[HttpPatch] "[FromBody]"
        [Route("Rate")]
        [HttpGet]
        public ActionResult Get([FromQuery] string carId, int Rating)
        {
            CarsService.AddRating(carId, Rating);
            return Ok();
        }
    }
}
