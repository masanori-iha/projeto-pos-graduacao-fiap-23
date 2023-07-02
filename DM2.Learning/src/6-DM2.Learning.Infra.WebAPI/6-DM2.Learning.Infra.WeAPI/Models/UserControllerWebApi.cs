using _3_DM2.Learning.Application.ViewModels;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace _6_DM2.Learning.Infra.WeAPI.Models;

public class UserControllerWebApi
{
    private readonly HttpClient _httpClient;
    private readonly AppSetting _appSetting;

    public UserControllerWebApi(HttpClient httpClient, IOptions<AppSetting> appSetting)
    {
        _httpClient = httpClient;
        _appSetting = appSetting.Value;
    }

    public async Task Create(UserViewModel user)
    {
        Uri uri = new Uri($"{_appSetting.BaseApiUrl}{_appSetting.Createuser}");

        try
        {
            var myContent = System.Text.Json.JsonSerializer.Serialize(user);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            await _httpClient.PostAsync($"{uri}", byteContent);

        }
        catch (Exception ex)
        {

        }
        return;
    }

    public async Task<UserViewModel> GetUserById(Guid id)
    {
        var uri = new Uri($"{_appSetting.BaseApiUrl}{_appSetting.GetUser}{id}");
        var response = await _httpClient.GetAsync(uri);

        var userResult = await response.Content.ReadAsStringAsync();

        var jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            IgnoreReadOnlyProperties = true,
            WriteIndented = true
        };

        var user = JsonSerializer.Deserialize<UserViewModel>(userResult, jsonSerializerOptions);

        return user;
    }

    public async Task<IEnumerable<UserViewModel>> GetAll()
    {
        var uri = new Uri($"{_appSetting.BaseApiUrl}{_appSetting.GetAllUser}");
        var response = await _httpClient.GetAsync(uri);

        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            var _users = new List<UserViewModel>();
            return _users;
        }

        var usersResult = await response.Content.ReadAsStringAsync();

        var jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            IgnoreReadOnlyProperties = true,
            WriteIndented = true
        };

        var users = JsonSerializer.Deserialize<IEnumerable<UserViewModel>>(usersResult, jsonSerializerOptions);

        return users;
    }

    public async Task Delete(Guid id)
    {
        var uri = new Uri($"{_appSetting.BaseApiUrl}{_appSetting.DeleteUser}/{id}");
        
        await _httpClient.DeleteAsync(uri);

        return;
    }
}
