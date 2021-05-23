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
    public class PostsController : Controller
    {
        readonly ApplicationContext database;
        public PostsController(ApplicationContext context)
        {
            database = context;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(PostDataModel model)
        {
            var user = await database.Users.FirstOrDefaultAsync(x => x.Email == User.FindFirst(ClaimTypes.Email).Value);
            if (user == null)
                return Unauthorized();

            var attachments = new List<Attachment>();

            foreach (AttachmentDataModel attachmentDataModel in model.Attachments)
                attachments.Add(new Attachment
                {
                    Type = attachmentDataModel.Type,
                    Url = attachmentDataModel.Url,
                });

            Post post = new Post
            {
                Name = model.Name,
                UserID = user.ID,
                Text = model.Text,
                Rating = 0,
                Date = DateTime.Now,
                CategoryID = model.CategoryID,
                Attachments = attachments
            };

            database.Posts.Add(post);
            await database.SaveChangesAsync();

            return Ok();
        }
    }
}

