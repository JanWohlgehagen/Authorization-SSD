using Enums;
using JWT.Services;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JWTController : ControllerBase
    {
        private readonly JwtTokenService _jwtTokenService;
        
        public JWTController(JwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }
        
        [HttpGet("EditorToken")]
        public IActionResult GetEditorToken()
        {
            // Define custom attributes/permissions
            var attributes = new List<Permissions> { Permissions.DeleteArticle, Permissions.EditArticle, Permissions.EditComment, Permissions.DeleteComment };

            // Call the service to create a token with these attributes
            var token = _jwtTokenService.CreateTokenWithAttributes(attributes);

            // Return the token
            return Ok(new
            {
                token,
                expiration = DateTime.UtcNow.AddMinutes(30)
            });
            
        }
        [HttpGet("JournalistToken")]
        public IActionResult GetJournalistToken()
        {
            // Define custom attributes/permissions
            var attributes = new List<Permissions> { Permissions.EditArticle, Permissions.CreateArticle };

            // Call the service to create a token with these attributes
            var token = _jwtTokenService.CreateTokenWithAttributes(attributes);

            // Return the token
            return Ok(new
            {
                token,
                expiration = DateTime.UtcNow.AddMinutes(30)
            });
        }

    }
    
    
}
