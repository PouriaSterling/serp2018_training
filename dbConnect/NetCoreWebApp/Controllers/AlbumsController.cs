using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using NetCoreWebApp.Models;

namespace NetCoreWebApp.Controllers  
{  
   [Route("api/[controller]")]
   [ApiController]
    public class AlbumController : Controller  
    {  
        // [HttpGet]
        public IActionResult Index()  
        {  
            MusicStoreContext context = HttpContext.RequestServices.GetService(typeof(NetCoreWebApp.Models.MusicStoreContext)) as MusicStoreContext;  
    
            return View(context.GetAllAlbums());  
        }  

        [HttpGet("{id}")]
        public ActionResult<Album> Get(int id)
        {
            MusicStoreContext context = HttpContext.RequestServices.GetService(typeof(NetCoreWebApp.Models.MusicStoreContext)) as MusicStoreContext;
            
            return context.GetAlbum(id);
        }

        // GET api/albums
        [HttpGet("test")]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "x", "d" };
        }
    }  
} 