using Livraria.Web.Models;
using Livraria.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.Namespace
{
    public class GenreController : Controller
    {
        private readonly IGenreRepository _genreRepository;
        public GenreController(IGenreRepository genreRepository)
        {
            this._genreRepository = genreRepository;
        }
        // GET: GenreController
        public IActionResult Index()
        {
            IEnumerable<Genre> genre = _genreRepository.FindAll(1);
            return View(genre);
        }

    }
}
