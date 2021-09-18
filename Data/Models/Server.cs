using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChatAPI.Data.Models
{
    public class Server
    {
        [Required]
        public Guid Id { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Channel> Channels { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
