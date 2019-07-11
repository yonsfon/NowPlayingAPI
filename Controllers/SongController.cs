using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NowPlaying.Models;
using NowPlaying.Work;

namespace NowPlaying.Controllers
{
    [Route("api/songplaying")]
    // [ApiController]
    public class SongPlayingController : ControllerBase
    {
        // GET api/songplaying
        [HttpGet]
        public ActionResult<SongPlaying> Get()
        {
            SongCreator s = new SongCreator();
            return s.Song;
            
        }
    }
}