using HelpDesk.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace HelpDesk.Domain.Models
{
    public class FileUploadModel
    {
        public IFormFile FileDetails { get; set; }
        public FileType FileType { get; set; }
    }
}
