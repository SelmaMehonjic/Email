namespace Send_and_track.models
{
    public class Email
    {
        public int Id { get; set; }
        public string SendTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        
    }
}