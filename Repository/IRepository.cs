using System.Threading.Tasks;
using Send_and_track.models;

namespace Send_and_track.Repository
{
    public interface IRepository
    {
         Task<Email> SendEmail(Email email);
         Task SendAttachments(Attachment attachment);
         Task<Attachment> GetAttachments(int id);
         Task<Email> UpdateEmail(Email email);
         Task<Attachment> Updateatt(int id);
         Task<byte[]> GetAttachmentByteArray(int id);
    }
}