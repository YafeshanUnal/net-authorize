using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrawlerController
{
    [ApiController]
    [Route("api/")]
    public class Controller : ControllerBase
    {
        // [Authorize("HashKeyPolicy")] second way to authorize
        [HttpGet("/crawlwithAuth")]
        public IActionResult Crawl()
        {
            Array otels = new string[] { "Hilton", "Marriot", "Ritz" };
            return Ok(otels);
        }

        [HttpGet("/crawlwithoutAuth")]
        public string CrawlWithoutAuth()
        {
            return $"Crawling without auth at {DateTime.Now}";
        }

    }
}
