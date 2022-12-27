using Microsoft.AspNetCore.Mvc.RazorPages;
using overboost.Models;
using overboost.Services;

namespace overboost.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public JsonFileCarsService CarsService { get; }
        public IEnumerable<Car> Cars { get; private set; }

        public IndexModel(
            
            ILogger<IndexModel> logger,
            JsonFileCarsService carsService)
        {
            _logger = logger;
            CarsService = carsService;
        }
        public void OnGet()
        {
            Cars = CarsService.GetCars();
        }
    }
}