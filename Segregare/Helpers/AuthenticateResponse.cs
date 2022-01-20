using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Segregare.Models;
using Segregare;

namespace Segregare.Helpers
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }
        public string Token { get; set; }



        public AuthenticateResponse(Scoala scoala, string token)
        {
            Id = scoala.Id;
            Email = scoala.Email;
            Token = token;
        }

        public AuthenticateResponse(Monitor monitor, string token)
        {
            Id = monitor.Id;
            Email = monitor.Email;
            Token = token;
        }
    }
}
