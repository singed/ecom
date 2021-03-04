using System.Net;
using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;

        public BuggyController(StoreContext context)
        {
            _context = context;
        }
        
        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var ting = _context.Products.Find(42);
            if (ting == null)
            {
                return NotFound(new ApiResponse((int)HttpStatusCode.NotFound));
            }

            return Ok();
        }
        
        [HttpGet("servererror")]
        public ActionResult GetServerErrorRequest()
        {
            var ting = _context.Products.Find(42);

            var thingtoreturn = ting.ToString();
            
            return Ok();
        }
        
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest();
        }
        
        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }
}