namespace _6_DM2.Learning.Infra.WeAPI.Interfaces
{
    public interface IBaseSGPHttpClient
    {
        string GetSiglaIdioma();
        string GetBaseUrl();
        HttpClient HttpClient();
        void ValidarRequisicaoHttp(HttpResponseMessage httpResponseMessage, string result, string url);
    }
}
