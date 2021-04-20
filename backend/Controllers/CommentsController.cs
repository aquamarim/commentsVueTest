using DAL.Models.Models;
using DAL.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        protected readonly ICommentsRepo CommentsRepo;

        public CommentsController(ICommentsRepo commentsRepo)
        {
            CommentsRepo = commentsRepo;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Comment>> GetAll()
        {
            return Ok(CommentsRepo.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Comment> GetOne(int id)
        {
            var entity = CommentsRepo.Find(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(entity);
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CommentsRepo.Add(comment);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetOne), new { id = comment.Id }, comment);
        }
    }
}
