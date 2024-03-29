﻿using Microsoft.AspNetCore.Mvc;

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
            var dir = new Dir.Dir(path);
            return PartialView("DirectoryViewModel", dir);
        }

        public IActionResult Previous(string path)
        {
            return PartialView("DirectoryViewModel");
        }
    }
}
