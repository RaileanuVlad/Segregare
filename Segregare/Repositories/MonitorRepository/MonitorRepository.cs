using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Segregare.Models;
using Segregare.Contexts;
using Segregare.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Options;

namespace Segregare.Repositories.MonitorRepository
{
    public class MonitorRepository: IMonitorRepository
    {
        public Context _context { get; set; }
        private readonly AppSettings _appSettings;

        public MonitorRepository(Context context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var monitor = _context.Monitori.SingleOrDefault(x => x.Email == model.Email && x.Parola == model.Parola);

            // return null if user not found
            if (monitor == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtTokenM(monitor);

            return new AuthenticateResponse(monitor, token);
        }

        public Monitor Create(Monitor monitor)
        {
            var result = _context.Add<Monitor>(monitor);
            _context.SaveChanges();
            return result.Entity;
        }
        public Monitor Get(int Id)
        {
            return _context.Monitori.SingleOrDefault(x => x.Id == Id);
        }
        public List<Monitor> GetAll()
        {
            return _context.Monitori.ToList();
        }
        public Monitor Update(Monitor monitor)
        {
            _context.Entry(monitor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return monitor;
        }
        public Monitor Delete(Monitor monitor)
        {
            var result = _context.Remove(monitor);
            _context.SaveChanges();
            return result.Entity;
        }

        private string generateJwtTokenM(Monitor monitor)
        {
            // generate token that is valid for 1 day
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", monitor.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
