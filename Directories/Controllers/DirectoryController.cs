using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Directories.Controllers
{
    public class DirectoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Directory(string path)
        {
            return PartialView("DirectoryViewModel", new Dir.Dir(path));
        }
    }
}
