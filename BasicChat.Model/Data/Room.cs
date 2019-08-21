using System;
using System.Collections.Generic;

namespace BasicChat.Model.Data
{
    public class Room
    {
        public string Name { get; set; }
        public string TagLine { get; set; }
        public List<User> Owners { get; set; } 
        public List<User> Users { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastActivity { get; set; }
        public Message LastMessage { get; set; }
    }
}
