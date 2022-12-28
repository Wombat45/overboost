using System.Text.Json;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using overboost.Models;

namespace overboost.Services

{
    public class JsonFileCarsService
    {
        public JsonFileCarsService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "cars.json");

        public IEnumerable<Car> GetCars()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);
            return JsonSerializer.Deserialize<Car[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }

        public void AddRating(string carId, int rating)
        {
            var cars = GetCars();

            if (cars.First(x => x.Id == carId).Ratings == null)
            {
                cars.First(x => x.Id == carId).Ratings = new int[] { rating };
            }
            else
            {
                var ratings = cars.First(x => x.Id == carId).Ratings.ToList();
                ratings.Add(rating);
                cars.First(x => x.Id == carId).Ratings = ratings.ToArray();
            }

            using var outputStream = File.OpenWrite(JsonFileName);

            JsonSerializer.Serialize<IEnumerable<Car>>(
                new Utf8JsonWriter(outputStream, new JsonWriterOptions
                {
                    SkipValidation = true,
                    Indented = true
                }),
                cars
            );
        }
    }
}