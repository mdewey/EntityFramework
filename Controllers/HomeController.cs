using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EntityFramework.Models;
using EntityFramework.DataContext;

namespace EntityFramework.Controllers
{
    public class HomeController : Controller
    {

        private SuperBlogContext _context;

        public HomeController(SuperBlogContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Blogs.ToList());
        }


        public IActionResult Seed()
        {
            var seedBlags = new List<Blog>(){
                new Blog {
                        Author = "me",
                        Body = "lorem ipsum body",
                        Description = "Cool article 1",
                        IsPublished = true,
                        Url = "http://www.google.com"
                    },
                    new Blog {
                        Author = "me",
                        Body = "lorem ipsum body",
                        Description = "Cool article 2",
                        IsPublished = true,
                        Url = "http://www.google.com"
                    },
                    new Blog {
                        Author = "me",
                        Body = "lorem ipsum body",
                        Description = "Cool article 3",
                        Url = "http://www.google.com"
                    },
                    new Blog {
                        Author = "me",
                        Body = "lorem ipsum body",
                        Description = "Cool article 4",
                        Url = "http://www.google.com"
                    },new Blog {
                        Author = "me",
                        Body = "lorem ipsum body",
                        Description = "Cool article 5",
                        IsPublished = true,
                        Url = "http://www.google.com"
                    },
            };

            seedBlags.ForEach(blag => _context.Blogs.Add(blag));

            _context.SaveChanges();

            return Ok();
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
