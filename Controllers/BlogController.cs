using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntityFramework.DataContext;
using EntityFramework.Models;

namespace EntityFramework.Controllers
{
    public class BlogController : Controller
    {
        private readonly SuperBlogContext _context;

        public BlogController(SuperBlogContext context)
        {
            _context = context;
        }

        // GET: Blog
        public async Task<IActionResult> Index()
        {
            return View(await _context.Blogs.ToListAsync());
        }

        // GET: Blog/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs
                .Include(i => i.Posts) // this line is the JOIN statement 
                .SingleOrDefaultAsync(m => m.Id == id);
            Console.WriteLine(blog.Posts?.Count());
            
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        public IActionResult Publish(int id)
        {
            var blog = _context.Blogs
                .SingleOrDefault(m => m.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

            blog.Publish();

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        // GET: Blog/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Url,Author,ImageUrl,Description,Body,IsPublished,PublishedDate")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        // GET: Blog/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs.SingleOrDefaultAsync(m => m.Id == id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        // POST: Blog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Url,Author,ImageUrl,Description,Body,IsPublished,PublishedDate")] Blog blog)
        {
            if (id != blog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(blog.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        // GET: Blog/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs
                .SingleOrDefaultAsync(m => m.Id == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // POST: Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await _context.Blogs.SingleOrDefaultAsync(m => m.Id == id);
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPost([FromRoute] int id, [FromForm] string comment)
        {
            Console.WriteLine(id.ToString());
            Console.WriteLine(comment);
            
            // put the object into context
            var blog = await _context.Blogs.SingleOrDefaultAsync(s => s.Id == id);
            // modify it
            blog.Posts.Add(new Post
            {
                Body = comment
            });
            // save
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Details), new { id });
        }


        private bool BlogExists(int id)
        {
            return _context.Blogs.Any(e => e.Id == id);
        }
    }
}
