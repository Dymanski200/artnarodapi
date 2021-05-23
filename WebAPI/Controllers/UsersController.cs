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
    public class UsersController : Controller
    {
        readonly ApplicationContext database;
        public UsersController(ApplicationContext context)
        {
            database = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> Get()
        {
            var users = await database.Users.ToListAsync();

            if (users.Count == 0)
                return NotFound();
 
            var result = new List<UserViewModel>();

            foreach (User user in users)
                result.Add(new UserViewModel(user));

            return Ok(result);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<UserViewModel>> Get(int id)
        {
            var user = await database.Users.FirstOrDefaultAsync(x=>x.ID==id);

            if (user == null)
                return NotFound();

            return Ok(new UserViewModel(user));
        }

        [HttpGet("{id}/posts")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<PostViewModel>>> GetPosts(int id)
        {
            var posts = await database.Posts.Where(x => x.UserID == id).Include(x => x.Attachments).Include(x => x.User).ToListAsync();

            if (posts.Count == 0)
                return NotFound();

            var result = new List<PostViewModel>();

            foreach (Post post in posts)
                result.Add(new PostViewModel(post, post.User));

            return Ok(result);
        }

    }
}

