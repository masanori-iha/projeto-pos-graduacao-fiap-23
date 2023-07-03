using _3_DM2.Learning.Application.ViewModels;
using _4_DM2.Learning.Domain.Entities;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

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
        var url = new Uri($"{_appSetting.BaseApiUrl}{_appSetting.Createuser}");
        var content = ToRequest(user);

        var resposta = await _httpClient.PostAsync(url, content);

        return;
    }

    private static StringContent ToRequest(object obj)
    {
        var jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            IgnoreReadOnlyProperties = true,
            WriteIndented = true
        };

        var json = JsonSerializer.Serialize(obj, jsonSerializerOptions);
        var content = new StringContent(json);
        content.Headers.ContentType = new MediaTypeHeaderValue("Application/Json");

        return content;
    }

    public async Task Update(UserImageUpdateViewModel userUpdate)
    {
        var url = new Uri($"{_appSetting.BaseApiUrl}{_appSetting.UpdateUser}");
        var content = ToRequest(userUpdate);

        var resposta = await _httpClient.PutAsync(url, content);
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
