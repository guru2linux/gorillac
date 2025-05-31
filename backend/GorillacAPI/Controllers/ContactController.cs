using Microsoft.AspNetCore.Mvc;
using GorillacApi.Models;
using System.Threading.Tasks;

namespace GorillacApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        public ContactController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ContactMessage message)
        {
            _db.ContactMessages.Add(message);
            await _db.SaveChangesAsync();
            return Ok(new { message = "Message received. Thank you!" });
        }
    }
}
