using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChatAPI.Data.Models
{
    public class Channel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Server Server { get; set; }
        [Required]
        public string Name { get; set; }
        public IEnumerable<Message> Messages { get; set; }
    }
}
