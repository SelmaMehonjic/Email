using Microsoft.AspNetCore.Http;

namespace Send_and_track.DTO
{
    public class EMailDTO
    {
        public string SendTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string File { get; set; }
    }
}