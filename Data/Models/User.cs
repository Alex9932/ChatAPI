using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChatAPI.Data.Models
{
    public class User
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public string Name { get; set; }
        public IEnumerable<Server> Servers { get; set; }
    }
}
