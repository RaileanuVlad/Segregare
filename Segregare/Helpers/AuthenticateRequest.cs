using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Segregare.Helpers
{
    public class AuthenticateRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Parola { get; set; }
    }
}