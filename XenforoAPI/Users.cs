using System;
using System.Threading.Tasks;

namespace XenforoAPI
{
    public class Users : Hub
    {
        public Users(string url, string apiKey) : base(url, apiKey) { }

        public async Task<string> GetUsersAsync(int page = 0)
        {
            return await GetRequestAsync($"{_baseURL}/api/users/?page={page}", _apiKey);
        }

        public async Task<string> CreateUserAsync(string data)
        {
            return await PostRequestAsync($"{_baseURL}/api/users/", data, _apiKey);
        }

        public async Task<string> FindUserByEmail(string email)
        {
            return await GetRequestAsync($"{_baseURL}/api/users/find-email?email={email}", _apiKey);
        }

        public async Task<string> FindUserByUsernamePrefix(string username)
        {
            return await GetRequestAsync($"{_baseURL}/api/users/find-name?username={username}", _apiKey);
        }

        public async Task<string> GetUserAsync(int userID, bool with_posts = false, int page = 0)
        {
            return await GetRequestAsync($"{_baseURL}/api/users/{userID}/?with_posts={with_posts.ToString().ToLower()}&page={page}", _apiKey);
        }

        public async Task<string> UpdateUserAsync(int userID, string data)
        {
            return await PostRequestAsync($"{_baseURL}/api/users/{userID}", data, _apiKey);
        }

        public async Task<string> DeleteUserAsync(int userID, string data = "")
        {
            return await PostRequestAsync($"{_baseURL}/api/users/{userID}/", data, _apiKey, method: "DELETE");
        }

        public async Task<string> DeleteUserAvatarAsync(int userID)
        {
            return await PostRequestAsync($"{_baseURL}/api/users/{userID}/avatar", "", _apiKey, method: "DELETE");
        }

        public async Task<string> GetUserProfilePostsAsync(int userID, int page = 0)
        {
            return await GetRequestAsync($"{_baseURL}/api/users/{userID}/profile-posts?page={page}", _apiKey);
        }
    }
}
