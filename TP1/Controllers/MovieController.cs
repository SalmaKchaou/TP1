using Microsoft.AspNetCore.Mvc;
using TP1.Models;

namespace TP1.Controllers
{
    public class MovieController : Controller
    {
        public List<Movie> movies = new List<Movie>()
                {
                    new Movie{Name="movie 1"},
                    new Movie{Name="movie 2"},
                    new Movie{Name="movie 3"},
                };
        public IActionResult Index()
        {
            var c = getAllMovies();
            return View(c);
        }
        public IActionResult Edit(int id) 
        {
            return Content("Test Id" + id);
        }
        [Route("Movie/released/{year:int}/{month:int}")]//to specify the route for this action 
        public IActionResult released(int month,int year)
        {
            List<Movie> movies = new List<Movie>()
                {
                    new Movie{Name="movie 1",ReleaseDate=new DateTime(2023,1,1)},
                    new Movie{Name="movie 2",ReleaseDate=new DateTime(2023,2,1)},
                    new Movie{Name="movie 3",ReleaseDate=new DateTime(2023,1,3)},
                };
            //to filter 
            var releasedMovies=movies.Where(m => m.ReleaseDate.Month == month && m.ReleaseDate.Year == year).ToList();

            // Convert the list of movies to a string
            var content = string.Join(", ", releasedMovies.Select(m => m.Name));

            return Content(content);
        }
        public IActionResult Details(int? id)
        {
            if (id == null) return Content("Id not found ");
            var testDetails = getAllMovies().FirstOrDefault(c => c.Id == id);
            return View(testDetails);
        }

        public IEnumerable<Movie> getAllMovies()
        {
            return movies;
        }
    }
}
