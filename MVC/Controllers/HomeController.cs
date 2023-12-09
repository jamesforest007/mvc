using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MvcMovie.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;

namespace MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;


    private List<Movie> movies = new List<Movie>
    {
        new Movie { Id = 5,Title="Holy Grail"
            , ReleaseDate=new DateTime(2023, 3, 11)}
  

    };


    public IActionResult ExportToCSV()
    {
        var builder = new StringBuilder();
        builder.AppendLine("Id,Title");
        foreach (var movie in movies)
        {
            builder.AppendLine($"{movie.Id},{movie.Title}");
        }
        return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "movies.csv");

    }

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

