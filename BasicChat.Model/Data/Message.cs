using System;

namespace BasicChat.Model.Data
{
    public class Message
    {
        public Guid Id { get; set; }
        public MessageType Type{ get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public Room Room { get; set; }
        public User Sender { get; set; }
        public User Receiver { get; set; }
        public  Guid ParentI { get; set; }
    }
}