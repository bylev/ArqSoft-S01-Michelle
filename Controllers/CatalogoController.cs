using Microsoft.AspNetCore.Mvc;
using Catalogo.Models;

namespace Catalogo.Controllers
{
    public class CatalogoController : Controller
    {
        private static List<Item> _items = new()
        {
            new Item
            {
                Id = 1,
                Nombre = "Debí tirar más fotos",
                Genero = "Urbana",
                Ano = 2025,
                Formato = "Digital",
                Artista = "Bad bunny"
            },
            new Item {
                Id = 2,
                Nombre = "Harry's House",
                Genero = "Pop",
                Ano = 2022,
                Formato = "CD",
                Artista = "Harry Styles"
            },
            new Item {
                Id = 3,
                Nombre = "Unfold",
                Genero = "K-Pop",
                Ano = 2026,
                Formato = "Digital",
                Artista = "Monsta X"
            },
            new Item {
                Id = 4,
                Nombre = "Midnights",
                Genero = "Pop",
                Ano = 2022,
                Formato = "CD",
                Artista = "Taylor Swift"
            },
            new Item
            {
                Id = 5,
                Nombre = "Guts",
                Genero = "Pop",
                Ano = 2023,
                Formato = "Digital",
                Artista = "Olivia Rodrigo"

            },
            new Item
            {
                Id = 6,
                Nombre = "K de Karma",
                Genero = "Urbana",
                Ano = 2026,
                Formato = "Vinilo",
                Artista = "Kenia Os"
        },
            };

        public IActionResult Index(string? genero)
        {
            var resultado = string.IsNullOrEmpty(genero) ? _items : _items.Where(i => i.Genero == genero).ToList();

            ViewBag.Generos = _items.Select(i => i.Genero).Distinct().ToList();
            ViewBag.GeneroActual = genero;

            return View(resultado);
        }

        public IActionResult Detalle(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            return item == null ? NotFound() : View(item);
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agregar(Item item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
            return RedirectToAction("Index");
        }
    }
}
