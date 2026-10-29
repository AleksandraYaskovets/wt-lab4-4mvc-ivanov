using Microsoft.AspNetCore.Mvc;
using wt_lab4_4mvc_ivanov.Models;

namespace wt_lab4_4mvc_ivanov.Controllers;

public class TrackController : Controller
{
    // Статический список — имитация базы данных (Блок 7, п.7)
    private static List<Track> _tracks = new()
    {
        new Track { Id = 1, Title = "Bohemian Rhapsody", ArtistName = "Queen", DurationSeconds = 355, AlbumId = 1 },
        new Track { Id = 2, Title = "Imagine", ArtistName = "John Lennon", DurationSeconds = 183, AlbumId = 2 },
        new Track { Id = 3, Title = "Love of My Life", ArtistName = "Queen", DurationSeconds = 219, AlbumId = 1 }
    };
    
    private static List<Album> _albums = new()
    {
        new Album { Id = 1, Title = "A Night at the Opera", Year = 1975 },
        new Album { Id = 2, Title = "Imagine", Year = 1971 }
    };

    // GET: /Track/Index (Список)
    public IActionResult Index()
    {
        return View(_tracks);
    }

    // GET: /Track/Details/1
    public IActionResult Details(int id)
    {
        var track = _tracks.FirstOrDefault(t => t.Id == id);
        if (track == null) return NotFound(); // Обработка 404 (Блок 3, уровень 3)
        
        ViewBag.Album = _albums.FirstOrDefault(a => a.Id == track.AlbumId);
        return View(track);
    }

    // GET: /Track/Create (Показать форму)
    public IActionResult Create()
    {
        ViewBag.Albums = _albums;
        return View();
    }

    // POST: /Track/Create (Обработать форму)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Track track)
    {
        if (ModelState.IsValid)
        {
            track.Id = _tracks.Any() ? _tracks.Max(t => t.Id) + 1 : 1;
            _tracks.Add(track);
            return RedirectToAction(nameof(Index)); // Редирект после успеха
        }
        ViewBag.Albums = _albums;
        return View(track); // Если ошибка валидации, вернуть форму
    }
}