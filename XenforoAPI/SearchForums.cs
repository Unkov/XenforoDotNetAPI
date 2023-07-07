using System;
using System.Threading.Tasks;

namespace XenforoAPI
{
    public class SearchForums : Hub
    {
        public SearchForums(string url, string apiKey) : base(url, apiKey) { }

        public async Task<string> SearchForumsAsync(int id, int page, bool with_threads = false)
        {
            return await GetRequestAsync($"{_baseURL}/api/search-forums/{id}/?page={page}&with_threads={with_threads}", _apiKey);
        }

        public async Task<string> SearchForumsThreadsAsync(int id)
        {
            return await GetRequestAsync($"{_baseURL}/api/search-forums/{id}/threads/", _apiKey);
        }
    }
}
