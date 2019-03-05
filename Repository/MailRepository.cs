using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Send_and_track.Data;
using Send_and_track.models;

namespace Send_and_track.Repository
{
    public class MailRepository : IRepository
    {
        private readonly DataContext _context;

        public MailRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Attachment>> GetAttachments(int id)
        {
            var attachment = await _context.Attachment.Where(a => a.EmailId == id).ToListAsync();
            return attachment;
        }


        public async Task<byte[]> GetAttachmentByteArray(int id)
        {
            var attachment = await _context.Attachment.FirstOrDefaultAsync(a => a.Id == id);
            return attachment.BinaryFile;
        }


        public async Task SendAttachments(Attachment attachment)
        {
            await _context.Attachment.AddAsync(attachment);
            await _context.SaveChangesAsync();
        }

        public async Task<Email> SendEmail(Email email)
        {
            await _context.Email.AddAsync(email);
            await _context.SaveChangesAsync();
            return email;
        }
        public async Task<Email> UpdateEmail(Email email)
        {
            _context.Update(email);
            await _context.SaveChangesAsync();
            var att = await Updateatt(email.Id);
            return email;
        }

        public async Task<Attachment> Updateatt(int id)
        {

            var att = await GetAttachmentAsync(id);
            att.IsOpened = true;
            _context.Update(att);
            await _context.SaveChangesAsync();
            return att;
        }

        public async Task<Attachment> GetAttachmentAsync(int id)
        {
            var attachment = await _context.Attachment.FirstOrDefaultAsync(a => a.Id == id);
            return attachment;
        }

        public async Task<Email> GetEmail(int id)
        {
                var email = await _context.Email.FirstOrDefaultAsync(a => a.Id == id);
            return email;
        }
    }
}