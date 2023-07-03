using _3_DM2.Learning.Application.Dto;
using _6_DM2.Learning.Infra.WeAPI.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace _6_DM2.Learning.Infra.WeAPI
{
    public class HttpGenericCall
    {
        private readonly AppSetting _appSettingsUi;
        private readonly IBaseSGPHttpClient _baseSGPHttpClient;

        public HttpGenericCall(IBaseSGPHttpClient baseSGPHttpClient, IOptions<AppSetting> appSettingsUi)
        {
            _baseSGPHttpClient = baseSGPHttpClient;
            _appSettingsUi = appSettingsUi.Value;
        }

        public async Task<TResult> CallMethod<TResult>(HttpMethod typeMethod, string methodToCall, CancellationToken cancellationToken,
            Dictionary<string, object> paramsToQuery = null, object paramsToBody = null, string jwtToken = null, string jsonParam = null, string baseUrl = null)
        {
            string url;

            if (baseUrl == null)
            {
                url = _baseSGPHttpClient.GetBaseUrl() + methodToCall;
            }
            else
            {
                url = baseUrl + methodToCall;
            }

            if (paramsToQuery != null)
                url = HttpHelper.UriWithParameters(url, paramsToQuery);

            using (HttpRequestMessage request = new HttpRequestMessage(typeMethod, url))
            {
                if (paramsToBody != null)
                    request.Content = HttpHelper.CreateHttpContent(paramsToBody);

                if (jsonParam != null)
                    request.Content = new StringContent(jsonParam, Encoding.UTF8, "application/json");

                if (jwtToken != null)
                    request.Headers.Add("Authorization", $"Bearer {jwtToken}");

                using (HttpResponseMessage response = await _baseSGPHttpClient.HttpClient()
                        .SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                        .ConfigureAwait(false))
                {
                    string result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    if (response.Headers.Contains("access-token") && response.Headers.GetValues("access-token") != null)
                        PersistToken._token = new TokenDto(response.Headers.GetValues("access-token").FirstOrDefault());

                    _baseSGPHttpClient.ValidarRequisicaoHttp(response, result, url);

                    if (!result.Contains("{") && !result.Contains("}") && result != "[]")
                        return JsonConvert.DeserializeObject<TResult>(JsonConvert.SerializeObject(result));

                    return JsonConvert.DeserializeObject<TResult>(result);
                }
            }
        }
    }

    public class PersistToken
    {
        public static TokenDto _token { get; set; }
    }

    public static class HttpHelper
    {
        public static HttpContent CreateHttpContent(object content)
        {
            HttpContent httpContent = null;

            if (content != null)
            {
                var ms = new MemoryStream();
                //JsonHelper.SerializeJsonIntoStream(content, ms);
                ms.Seek(0, SeekOrigin.Begin);
                httpContent = new StreamContent(ms);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            }

            return httpContent;
        }

        public static string UriWithParameters(string uri, Dictionary<string, object> arParams)
        {
            try
            {
                string queryStringParameters = string.Join("&", arParams.Select(item => $"{item.Key}={HttpUtility.UrlEncode(item.Value == null ? "" : item.Value.ToString())}"));
                return $"{uri}?{queryStringParameters}";
            }
            catch (System.Exception ex)
            {
                throw new System.Exception($"UriWithParameters: {ex.Message}");
            }
        }
    }
}
