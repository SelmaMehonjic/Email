
using Microsoft.AspNetCore.Http;
namespace Send_and_track.DTO
{
    public class AttachmentDTO
    {
        public IFormFile[] File { get; set; }

    }
}