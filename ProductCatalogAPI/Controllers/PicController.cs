using System;
using System.Collections.Generic;
using IOfile = System.IO.File;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicController : ControllerBase
    {
        private readonly IHostingEnvironment _env;//global vr
        public PicController(IHostingEnvironment evn)//hosting env will map my folder level,evn is a local vr   
        {
            _env = evn;
        }
        [HttpGet("{id}")]//get request and excpect a paramenter
        public IActionResult GetImage(int id)//converst return type into a jason form
        {
            var webRoot = _env.WebRootPath;//reach pics folder
            var path=Path.Combine($"{webRoot}/Pics/", $"Ring{id}.jpg");///combine with the name of the file and make the root path
            var buffer = IOfile.ReadAllBytes(path);
            return File(buffer, "image/jpeg");


        }
    }
}
   

