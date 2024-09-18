using Enums;
using Microsoft.AspNetCore.Mvc;
using SecureWebAPI.AuthAttributes;


namespace SecureWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : Controller
    {
        [AuthAttributes(Permissions.CreateArticle)]
        [HttpPost("createArticle")]
        public ActionResult CreateArticle()
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }
        
        [AuthAttributes(Permissions.ReadArticle)]
        [HttpGet]
        public ActionResult Index()
        {
            return Ok();
        }

        [AuthAttributes(Permissions.EditArticle)]
        [HttpPut("editArticle")]
        public ActionResult EditArticle([FromQuery] int id, [FromQuery] string creatorId)
        {
            var userIdClaim = HttpContext.User.Claims.FirstOrDefault()?.Value;

            if (userIdClaim == null)
            {
                return Unauthorized();
            }
            
            var userId = userIdClaim;

            if (creatorId != userId) // proof of concept.. not proud of it.
            {
                return Forbid();
            }

            return Ok();
        }

        [AuthAttributes(Permissions.DeleteArticle)]
        [HttpDelete("deleteArticle/{id}")]
        public ActionResult DeleteArticle(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }

        [AuthAttributes(Permissions.CreateComment)]
        [HttpPost("createComment")]
        public ActionResult CreateComment()
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }

        [AuthAttributes(Permissions.EditComment)]
        [HttpPut("editComment/{id}")]
        public ActionResult EditComment(int id)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return Ok();
            }
        }

        [AuthAttributes(Permissions.DeleteComment)]
        [HttpDelete("deleteComment/{id}")]
        public ActionResult DeleteComment(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
