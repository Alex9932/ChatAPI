using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAPI.Data.Models
{
    public class Token
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public User User { get; set; }
    }
}
