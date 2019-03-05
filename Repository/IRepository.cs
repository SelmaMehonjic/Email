using System.Collections.Generic;
using System.Threading.Tasks;
using Send_and_track.models;

namespace Send_and_track.Repository
{
    public interface IRepository
    {
         Task<Email> SendEmail(Email email);
         Task<Email> GetEmail(int id);
         Task SendAttachments(Attachment attachment);
         Task<IEnumerable<Attachment>> GetAttachments(int id);
         Task<Attachment> GetAttachmentAsync(int id);

         Task<Email> UpdateEmail(Email email);
         Task<Attachment> Updateatt(int id);
         Task<byte[]> GetAttachmentByteArray(int id);
    }
}