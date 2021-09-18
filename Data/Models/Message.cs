using System;
using System.ComponentModel.DataAnnotations;

namespace ChatAPI.Data.Models
{
    public class Message
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public User Author { get; set; }
        [Required]
        public string Text { get; set; }
    }
}
