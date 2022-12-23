using Microsoft.AspNetCore.Mvc;

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
