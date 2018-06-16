using System;

namespace Dating.API.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime MessageSent { get; set; }
        public bool Read { get; set; }
        public DateTime DateRead { get; set; }
        public int ParentId { get; set; }
        public User Sender { get; set; }
        public int SenderId { get; set; }
        public User Recipient { get; set; }
        public int RecipientId { get; set; }
    }
}