using Microsoft.EntityFrameworkCore;
using Send_and_track.models;

namespace Send_and_track.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
      public  DbSet<Email> Email {get; set; }
      public  DbSet<Attachment> Attachment {get; set; }
    }
}