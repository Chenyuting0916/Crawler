using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Crawler.Models;
using AngleSharp;

namespace Crawler.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var config = Configuration.Default.WithDefaultLoader();
        var context = BrowsingContext.New(config);
        var document = await context.OpenAsync("https://calendar.google.com/calendar/u/1/r");
        var contents = document.QuerySelectorAll(".content");
        return View(contents);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}