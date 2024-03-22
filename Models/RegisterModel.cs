using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class RegisterModel
    {
        public string? USERNAME {get; set;} 
        public string? EMAIL_ID {get; set;} 
        public string? USER_ID {get; set;} 
        public string? PASSWORD {get; set;} 
        public string? CONFIRM_PASSWORD {get; set;} 
    }
}