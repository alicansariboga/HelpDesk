using HelpDesk.Domain.Enums;
using HelpDesk.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace HelpDesk.Application.Interfaces.FileInterfaces
{
    public interface IFileRepository
    {
        public Task PostFileAsync(IFormFile fileData, FileType fileType);

        public Task PostMultiFileAsync(List<FileUploadModel> fileData);

        public Task DownloadFileById(int Id);
        public Task CopyStream(Stream stream, string downloadPath);
    }
}
