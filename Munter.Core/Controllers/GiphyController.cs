using Microsoft.AspNetCore.Mvc;
using Munter.Core.Data;
using Munter.Core.Models.Giphy;
using Munter.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Munter.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiphyController : ControllerBase
    {
        private IGiphyService mGiphyService;
        private MyDbContext mDbContext;
        public GiphyController(MyDbContext db, IGiphyService giphyService)
        {
            mDbContext = db;
            mGiphyService = giphyService;
        }
        [HttpGet("GiftsTrending")]
        public ActionResult<GiphyGiftsResponse> GetGiftsTrending()
        {
            return mGiphyService.GetGiftsTrending(mDbContext);
        }

        [HttpGet("SearchGifts/{searchText}")]
        public ActionResult<GiphyGiftsResponse> SearchGifts(string searchText)
        {
            return mGiphyService.SearchGifts(mDbContext, searchText);
        }
    }
}
