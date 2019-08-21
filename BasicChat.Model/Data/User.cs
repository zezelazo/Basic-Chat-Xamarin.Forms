using System;
using System.Collections.Generic;

namespace BasicChat.Model.Data
{
    public class User
    {
        public string UserName { get; set; }
        public Guid Id { get; set; }
        public string ShowName { get; set; }
        public string TagLine { get; set; }
        public string PhoneNumber { get; set; }
        public List<User> Friends { get; set; }
        public List<Room> AdminRooms { get; set; }
    }

}