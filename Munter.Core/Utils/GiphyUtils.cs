using Munter.Core.Models.Giphy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Munter.Core.Utils
{
    public static class GiphyUtils
    {
        public static Task<GiphyGiftsResponse> GetGiftsTrending()
        {
            Dictionary<string, string> query = new Dictionary<string, string>();
            query.Add("api_key", Properties.Resources.GiphyApiKey);
            query.Add("limit", Properties.Resources.GiphyApiLimit);
         
            return HttpUtils.GetAsync<GiphyGiftsResponse>("v1/gifs/trending", query);
        }
        public static Task<GiphyGiftsResponse> SearchGifts(string searchText)
        {
            Dictionary<string, string> query = new Dictionary<string, string>();
            query.Add("api_key", Properties.Resources.GiphyApiKey);
            query.Add("limit", Properties.Resources.GiphyApiLimit);
            query.Add("offset", "0");
            query.Add("q", searchText);

            return HttpUtils.GetAsync<GiphyGiftsResponse>("v1/gifs/search", query);
        }
    }
}
