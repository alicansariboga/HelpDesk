using HelpDesk.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace HelpDesk.Application.Dtos
{
    public class FileUploadModel
    {
        public IFormFile FileDetails { get; set; }
        public FileType FileType { get; set; }
    }
}
