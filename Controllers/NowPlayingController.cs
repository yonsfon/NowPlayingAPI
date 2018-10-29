using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NowPlaying.Controllers
{
    [Route("api/nowplaying")]
    [ApiController]
    public class NowPlayingController : ControllerBase
    {
        // GET api/NowPlaying
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

            string nowPlayingSTR = WinampFrontEndLib.WinampLib.GetCurrentSongTitle();

            return new string[] { nowPlayingSTR };

        }
    }
}