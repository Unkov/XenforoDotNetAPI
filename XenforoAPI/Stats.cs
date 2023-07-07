using System;
using System.Threading.Tasks;

namespace XenforoAPI
{
    public class Stats : Hub
    {
        public Stats(string url, string apiKey) : base(url, apiKey) { }

        public async Task<string> GetStatsAsync()
        {
            return await GetRequestAsync($"{_baseURL}/api/stats/", _apiKey);
        }
    }
}
