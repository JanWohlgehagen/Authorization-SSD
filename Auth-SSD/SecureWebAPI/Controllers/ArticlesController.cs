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
        [HttpGet("createArticle")]
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

        [HttpGet]
        [AuthAttributes(Permissions.ReadArticle)]
        public ActionResult Index()
        {
            return Ok();
        }


        [AuthAttributes(Permissions.EditArticle)]
        [HttpGet("editArticle/{id}")]
        public ActionResult EditArticle(int id)
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

        [AuthAttributes(Permissions.DeleteArticle)]
        [HttpPost("deleteArticle/{id}")]
        [ValidateAntiForgeryToken]
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
        [HttpGet("createComment")]
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
        [HttpGet("editComment/{id}")]
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
        [HttpPost("deleteComment/{id}")]
        [ValidateAntiForgeryToken]
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
