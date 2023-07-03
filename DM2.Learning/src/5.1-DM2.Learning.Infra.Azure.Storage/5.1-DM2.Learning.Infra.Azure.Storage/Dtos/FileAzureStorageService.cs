using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace _5._1_DM2.Learning.Infra.Azure.Storage.Dtos
{
    public class FileAzureStorageService
    {
        private IConfiguration _configuration;
        private readonly string _container = "stogareusuarios";
        private readonly BlobContainerClient _fileContainer;
        private readonly string _key = "";
        private readonly string _baseUri = "";

        public FileAzureStorageService(IConfiguration configuration)
        {
            _configuration = configuration;
            _key = "?sp=racwdli&st=2023-07-02T22:21:21Z&se=2023-07-03T06:21:21Z&spr=https&sv=2022-11-02&sr=c&sig=p4ybMqJLprHe7%2Bw4IUYK26R2%2B0bO9oFQt49g6XbLVkE%3D";
            _baseUri = $"https://{_configuration.GetSection("azureStorage").Value ?? ""}.blob.core.windows.net/";

            var blobServiceClient = new BlobServiceClient(new Uri($"{_baseUri}{_key}"));
            _fileContainer = blobServiceClient.GetBlobContainerClient(_container);
        }

        public string ObterUrlBlob(string blobName)
        {
            return $"https://{_configuration.GetSection("azureStorage").Value}.blob.core.windows.net/{_container}/{blobName}{_key}";
        }


        public async Task<BlobResponseDto> UploadAsync(IFormFile blob)
        {
            BlobResponseDto response = new();
            BlobClient client = _fileContainer.GetBlobClient(blob.FileName);

            await using (Stream? data = blob.OpenReadStream())
            {
                var resultado = await client.UploadAsync(data);
            }

            response.Status = $"File {blob.FileName} Uploaded successfully";
            response.Error = false;
            response.Blob.Uri = client.Uri.AbsoluteUri;
            response.Blob.Name = client.Name;

            return response;
        }

        public async Task<IEnumerable<BlobDto>> List()
        {
            List<BlobDto> files = new();

            await foreach (var blob in _fileContainer.GetBlobsAsync())
            {
                var name = blob.Name;
                var fullUri = $"{_baseUri}{_container}/{name}{_key}";

                files.Add(new BlobDto
                {
                    Uri = fullUri,
                    Name = name,
                    ContentType = blob.Properties.ContentType
                });
            }

            return files;
        }

        public async Task<IEnumerable<string>> ListBlobsUrls()
        {
            List<string> urls = new();

            await foreach (var blob in _fileContainer.GetBlobsAsync())
            {
                var name = blob.Name;
                var fullUri = $"{_baseUri}{_container}/{name}{_key}";

                urls.Add($"{name}|{fullUri}");
            }

            return urls;
        }

        public async Task<BlobResponseDto> Excluir(string filename)
        {
            var file = _fileContainer.GetBlobClient(filename);

            await file.DeleteAsync();

            return new BlobResponseDto
            {
                Error = false,
                Status = $"Arquivo: {filename} excluído com sucesso"
            };
        }
    }
}
