using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebAPI.DataModels;
using WebAPI.Models;
using WebAPI.ViewModels;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        readonly ApplicationContext database;
        public CategoriesController(ApplicationContext context)
        {
            database = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> Get()
        {
            var categories = await database.Categories.ToListAsync();

            if (categories.Count == 0)
                return NotFound();

            var rnd = new Random();
            for (int i = 0; i < categories.Count; i++)
            {
                var tmp = categories[0];
                categories.RemoveAt(0);
                categories.Insert(rnd.Next(categories.Count), tmp);
            }

            var result = new List<CategoryViewModel>();

            foreach (Category category in categories)
                result.Add(new CategoryViewModel(category));

            return Ok(result);
        }

        [HttpGet("{id}/posts")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<PostViewModel>>> GetPosts(int id)
        {
            var posts = await database.Posts.Where(x => x.CategoryID == id).Include(x => x.Attachments).Include(x => x.User).OrderBy(x=>x.Rating).ToListAsync();

            if (posts.Count == 0)
                return NotFound();

            var result = new List<PostViewModel>();

            foreach (Post post in posts)
                result.Add(new PostViewModel(post, post.User));

            return Ok(result);
        }

    }
}

