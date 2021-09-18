using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatAPI.Data.DTO
{
    public class Error
    {
        public string Message { get; set; }

        public Error(string message)
        {
            Message = message;
        }
    }
}
