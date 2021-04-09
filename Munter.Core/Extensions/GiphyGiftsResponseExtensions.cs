using Munter.Core.Data.Entities;
using Munter.Core.Models.Giphy;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Munter.Core.Extensions
{
    public static class GiphyGiftsResponseExtensions
    {
        public static GiphyGiftsResponse GetGiphyGiftsResponse(this TrendingResponse obj)
        {
            return Json2GiphyGiftsResponse(obj?.JsonData);
        }
        public static GiphyGiftsResponse GetGiphyGiftsResponse(this SearchResponse obj)
        {
            return Json2GiphyGiftsResponse(obj?.JsonData);
        }
        private static GiphyGiftsResponse Json2GiphyGiftsResponse(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;
            return JsonConvert.DeserializeObject<GiphyGiftsResponse>(json);
        }

        public static TrendingResponse SetGiphyGiftsResponse(this TrendingResponse obj, GiphyGiftsResponse response)
        {
            obj.JsonData = GiphyGiftsResponse2Json(response);
            return obj;
        }
        public static SearchResponse SetGiphyGiftsResponse(this SearchResponse obj, GiphyGiftsResponse response)
        {
            obj.JsonData = GiphyGiftsResponse2Json(response);
            return obj;
        }
        private static string GiphyGiftsResponse2Json(GiphyGiftsResponse obj)
        {
            if (obj == null)
                return null;
            return JsonConvert.SerializeObject(obj);
        }
    }
}
