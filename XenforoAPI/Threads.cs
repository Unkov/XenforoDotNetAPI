using System;
using System.Threading.Tasks;

namespace XenforoAPI
{
    public class Threads : Hub
    {
        public Threads(string url, string apiKey) : base(url, apiKey) { }

        public async Task<string> GetThreadsAsync(int page, int prefix_id = -1, int starter_id = -1, int last_days = -1, bool unread = false, string thread_type = "", string order = "", string direction = "")
        {
            return await GetRequestAsync($"{_baseURL}/api/threads/?page={page}&prefix_id={prefix_id}&starter_id={starter_id}&last_days={last_days}&unread={unread}&thread_type={thread_type}&order={order}&direction={direction}", _apiKey);
        }

        public async Task<string> CreateThreadAsync(string data)
        {
            return await PostRequestAsync($"{_baseURL}/api/threads/", data, _apiKey);
        }

        public async Task<string> GetThreadInfoAsync(int id, int page, string order = "")
        {
            return await GetRequestAsync($"{_baseURL}/api/threads/{id}/?page={page}&order={order}", _apiKey);
        }

        public async Task<string> UpdateThreadAsync(int id, string data)
        {
            return await PostRequestAsync($"{_baseURL}/api/threads/{id}/", data, _apiKey);
        }

        public async Task<string> DeleteThreadAsync(int id, string data)
        {
            return await PostRequestAsync($"{_baseURL}/api/threads/{id}/", data, _apiKey, method: "DELETE");
        }

        public async Task<string> ChangeTypeThreadAsync(int id, string data)
        {
            return await PostRequestAsync($"{_baseURL}/api/threads/{id}/change-type", data, _apiKey);
        }

        public async Task<string> MarkReadThreadAsync(int id, string data)
        {
            return await PostRequestAsync($"{_baseURL}/api/threads/{id}/mark-read", data, _apiKey);
        }

        public async Task<string> MoveThreadAsync(int id, string data)
        {
            return await PostRequestAsync($"{_baseURL}/api/threads/{id}/move", data, _apiKey);
        }

        public async Task<string> GetThreadPostsAsync(int id, string data)
        {
            return await PostRequestAsync($"{_baseURL}/api/threads/{id}/posts", data, _apiKey);
        }

        public async Task<string> VoteThreadAsync(int id, string data)
        {
            return await PostRequestAsync($"{_baseURL}/api/threads/{id}/vote", data, _apiKey);
        }
    }
}
