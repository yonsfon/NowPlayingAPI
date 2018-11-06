using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NowPlaying.Controllers
{
    [Route("api/[controller]")]
    // [ApiController]
    public class NowPlayingController : ControllerBase
    {
        // GET api/nowPlaying
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            string nowPlayingSTR = WinampFrontEndLib.WinampLib.GetCurrentSongTitle();
            return new string[] { nowPlayingSTR };
        }
    }
}