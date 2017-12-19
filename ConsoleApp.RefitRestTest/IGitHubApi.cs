using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.RefitRestTest
{
    public interface IGitHubApi
    {
        [Get("/users/{user}")]
        Task<User> GetUserAsync(string user);
    }
}
