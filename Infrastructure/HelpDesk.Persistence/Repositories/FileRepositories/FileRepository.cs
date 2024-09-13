using HelpDesk.Application.Interfaces.FileInterfaces;
using HelpDesk.Domain.Enums;
using HelpDesk.Domain.Models;
using HelpDesk.Persistence.Context;
using Microsoft.AspNetCore.Http;

namespace HelpDesk.Persistence.Repositories.FileRepositories
{
    public class FileRepository : IFileRepository
    {
        private readonly HelpDeskContext _context;

        public FileRepository(HelpDeskContext context)
        {
            _context = context;
        }
        public async Task DownloadFileById(int Id)
        {
            try
            {
                var file = _context.TicketDocuments.Where(x => x.Id == Id).FirstOrDefaultAsync();

                var content = new System.IO.MemoryStream(file.Result.FileData);
                var path = Path.Combine(
                   Directory.GetCurrentDirectory(), "FileDownloaded",
                   file.Result.File);

                await CopyStream(content, path);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task PostFileAsync(IFormFile fileData, FileType fileType)
        {
            try
            {
                var ticketDocument = new TicketDocument()
                {
                    Id = 0,
                    File = fileData.FileName,
                    FileType = fileType,
                    CreatedDate = DateTime.Now.ToString("yyyy-MM-dd"),
                };

                using (var stream = new MemoryStream())
                {
                    fileData.CopyTo(stream);
                    ticketDocument.FileData = stream.ToArray();
                }

                var result = _context.TicketDocuments.Add(ticketDocument);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task PostMultiFileAsync(List<FileUploadModel> fileData)
        {
            try
            {
                foreach (FileUploadModel file in fileData)
                {
                    var ticketDocument = new TicketDocument()
                    {
                        Id = 0,
                        File = file.FileDetails.FileName,
                        FileType = file.FileType,
                    };

                    using (var stream = new MemoryStream())
                    {
                        file.FileDetails.CopyTo(stream);
                        ticketDocument.FileData = stream.ToArray();
                    }

                    var result = _context.TicketDocuments.Add(ticketDocument);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task CopyStream(Stream stream, string downloadPath)
        {
            using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }
        }
    }
}
