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

        [Get("/api/TemplateOriginatorService/GetAsync/{user}")]
        Task<string> GetContextAsync(string user);

        [Get("/api/TemplateOriginatorService/Get/{user}")]
        Task<string> GetContextSync(string user);

        [Get("/api/BasicDepartmentService/GetBasicDepartmentListByStateAsync/{id}")]
        Task<string> GetBasicDepartmentListByStateAsync(string id);

        [Get("/api/BasicDepartmentService/GetBasicDepartmentListByState/{id}")]
        Task<string> GetBasicDepartmentListByStateSync(string id);
    }
}
