namespace Send_and_track.models
{
    public class Attachment
    {
        public int Id { get; set; }
        public byte[] BinaryFile { get; set; }

        public Email Email {get; set;}
        public int EmailId { get; set; }

        public bool IsOpened { get; set; }
    }
}