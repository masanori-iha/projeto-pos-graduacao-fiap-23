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

public class UserImageControllerWebApi
{
    private readonly HttpClient _httpClient;
    private readonly AppSetting _appSetting;

    public UserImageControllerWebApi(HttpClient httpClient, IOptions<AppSetting> appSetting)
    {
        _httpClient = httpClient;
        _appSetting = appSetting.Value;
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

    public async Task Update(UserImageViewModel userImageUpdate)
    {
        var url = new Uri($"{_appSetting.BaseApiUrl}{_appSetting.UpdateUserImage}");
        var content = ToRequest(userImageUpdate);

        var resposta = await _httpClient.PutAsync(url, content);
    }

    public async Task Remove(Guid id)
    {
        var url = new Uri($"{_appSetting.BaseApiUrl}{_appSetting.UpdateUserImage}/{id}");
       
        var resposta = await _httpClient.DeleteAsync(url);
    }
}
