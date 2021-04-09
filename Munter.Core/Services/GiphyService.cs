using Munter.Core.Data;
using Munter.Core.Data.Entities;
using Munter.Core.Extensions;
using Munter.Core.Models.Giphy;
using Munter.Core.Utils;
using System;
using System.Linq;

namespace Munter.Core.Services
{
    public interface IGiphyService
    {
        GiphyGiftsResponse GetGiftsTrending(MyDbContext dbContext);
        GiphyGiftsResponse SearchGifts(MyDbContext dbContext, string searchText);
    }
    internal class GiphyService : IGiphyService
    {
        private static TrendingResponse mLastTrendingResponse = null;
        private void UpdateTrendingResponse(MyDbContext db)
        {
            mLastTrendingResponse = db.TrendingResponses
                .Where(x => x.CreatedTime.Date == DateTime.Today)
                .OrderByDescending(x => x.CreatedTime)
                .FirstOrDefault();
            if (mLastTrendingResponse == null)
            {
                var onlineResponse = GiphyUtils.GetGiftsTrending().Result;
                mLastTrendingResponse = new TrendingResponse()
                {
                    CreatedTime = DateTime.Now
                }
                .SetGiphyGiftsResponse(onlineResponse);
                db.TrendingResponses.Add(mLastTrendingResponse);
                db.SaveChanges();
            }
        }
        public GiphyGiftsResponse GetGiftsTrending(MyDbContext db)
        {
            if (mLastTrendingResponse == null ||
                mLastTrendingResponse.CreatedTime.Date != DateTime.Today)
            {
                UpdateTrendingResponse(db);
            }
            return mLastTrendingResponse.GetGiphyGiftsResponse();
        }
        public GiphyGiftsResponse SearchGifts(MyDbContext db, string searchText)
        {
            SearchResponse response = null;
            response = db.SearchResponses
                .Where(x => x.CreatedTime.Date == DateTime.Today
                    && x.SearchText.ToLower() == searchText.ToLower())
                .OrderByDescending(x => x.CreatedTime)
                .FirstOrDefault();
            if (response == null)
            {
                var onlineResponse = GiphyUtils.SearchGifts(searchText).Result;

                response = new SearchResponse()
                {
                    CreatedTime = DateTime.Now,
                    SearchText = searchText.ToLower(),
                }
                .SetGiphyGiftsResponse(onlineResponse);
                db.SearchResponses.Add(response);
                db.SaveChanges();
            }
            return response.GetGiphyGiftsResponse();
        }
    }
}
