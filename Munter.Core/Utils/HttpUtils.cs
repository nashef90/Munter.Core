using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Munter.Core.Utils
{
    public static class HttpUtils
    {
        private static HttpClient client = new HttpClient();
        internal static async Task<T> GetAsync<T>(string requestPath, Dictionary<string, string> queryLink = null) where T : class
        {
            var builder = new UriBuilder(Properties.Resources.GiphyBaseApiUrl);
            builder.Path = requestPath;
            if (queryLink != null)
            {
                var query = HttpUtility.ParseQueryString(builder.Query);
                foreach (var item in queryLink)
                {
                    query[item.Key] = item.Value;
                }
                builder.Query = query.ToString();
            }
            T product = null;
            HttpResponseMessage response = await client.GetAsync(builder.ToString());
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<T>();
            }
            return product;
        }
    }
}
