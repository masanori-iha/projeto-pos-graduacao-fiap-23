using _5._1_DM2.Learning.Infra.Azure.Storage.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace _1_DM2.Learning.Presentation.Areas.User.Controllers
{
    [Area("User")]
    [Route("[controller]/[action]")]
    public class UserReportController : Controller
    {
        private readonly FileAzureStorageService _fileAzureStorageService;

        public UserReportController(FileAzureStorageService fileAzureStorageService)
        {
            _fileAzureStorageService = fileAzureStorageService;
        }

        public async Task<IActionResult> Index()
        {
            var userImages = await _fileAzureStorageService.ListBlobsUrls();

            return View(userImages);
        }
    }
}
