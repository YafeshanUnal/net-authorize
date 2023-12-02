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
            return Ok("Crawling...");
        }

        [HttpGet("/crawlwithoutAuth")]
        public string CrawlWithoutAuth()
        {
            return $"Crawling without auth at {DateTime.Now}";
        }

    }
}
