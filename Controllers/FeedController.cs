using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DailyExperienceApi.Services;
using DailyExperienceApi.Models;

namespace DailyExperienceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FeedController : ControllerBase
    {

        private readonly FeedService _feedService;

        public FeedController(FeedService feedService)
        {
            _feedService = feedService;
        }

        [HttpGet]
        public IEnumerable<Feed> Index()
        {
            var feeds = _feedService.Get().ToList();
            return feeds;
        }

        [HttpPost]
        public IActionResult Index(Feed feed)
        {
            var result = new Result();

            var feedInfo = _feedService.Create(feed);
            return Ok(result);
        }

           [HttpPut]
        public IActionResult Update(string id ,Feed feed)
        {
            var result = new Result();

             _feedService.Update(id,feed);
            return Ok(result);
        }
    }
}
