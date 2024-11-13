using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _commentContext;

        public CommentsController(CommentContext commentContext)
        {
            _commentContext = commentContext;
        }

        [HttpGet]
        public IActionResult CommentList()
        {
            var values = _commentContext.UserComments.ToList();
            return Ok(values);
        }  
        [HttpPost]
        public IActionResult CreateComment(UserComment userComment)
        {
            _commentContext.UserComments.Add(userComment);
            _commentContext.SaveChanges();
            return Ok("Yorum Başarı ile Eklendi");
        }  
        [HttpPut]
        public IActionResult UpdateComment(UserComment userComment)
        {
            _commentContext.UserComments.Update(userComment);
            _commentContext.SaveChanges();
            return Ok("Yorum Başarı ile Güncellendi");
        } 
        [HttpDelete]
        public IActionResult DeleteComment(int id)
        {
            var value=  _commentContext.UserComments.Find(id);
            _commentContext.UserComments.Remove(value);
            _commentContext.SaveChanges();
            return Ok("Yorum Başarı ile silindi.");
        } 
         [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            return Ok(_commentContext.UserComments.Find(id));
        }  
        [HttpGet("CommentListByProductId/{id}")]
        public IActionResult CommentListByProductId(string id)
        {
            var values = _commentContext.UserComments.Where(x => x.ProductId == id).ToList();

            return Ok(values);
        }
        
        [HttpGet("GetActiveCommandCount")]
        public IActionResult GetActiveCommandCount(string id)
        {
            int value = _commentContext.UserComments.Where(x=>x.Status==true).Count();

            return Ok(value);
        } 
        [HttpGet("GetPassiveCommandCount")]
        public IActionResult GetPassiveCommandCount(string id)
        {
            int value = _commentContext.UserComments.Where(x=>x.Status==false).Count();

            return Ok(value);
        }  
        [HttpGet("GetTotalCommandCount")]
        public IActionResult GetTotalCommandCount(string id)
        {
            int value = _commentContext.UserComments.Count();

            return Ok(value);
        } 
       
    }
}
