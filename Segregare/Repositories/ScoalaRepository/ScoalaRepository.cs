using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Segregare.Models;
using Segregare.Contexts;
using Segregare.Helpers;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace Segregare.Repositories.ScoalaRepository
{
    public class ScoalaRepository: IScoalaRepository
    {
        public Context _context { get; set; }
        private readonly AppSettings _appSettings;

        public ScoalaRepository(Context context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var scoala = _context.Scoli.SingleOrDefault(x => x.Email == model.Email && x.Parola == model.Parola);

            // return null if user not found
            if (scoala == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(scoala);

            return new AuthenticateResponse(scoala, token);
        }
        public Scoala Create(Scoala scoala)
        {
            var result = _context.Add<Scoala>(scoala);
            _context.SaveChanges();
            return result.Entity;
        }
        public Scoala Get(int Id)
        {
            return _context.Scoli.SingleOrDefault(x => x.Id == Id);
        }
        public List<Scoala> GetAll()
        {
            return _context.Scoli.ToList();
        }
        public Scoala Update(Scoala scoala)
        {
            _context.Entry(scoala).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return scoala;
        }
        public Scoala Delete(Scoala scoala)
        {
            var result = _context.Remove(scoala);
            _context.SaveChanges();
            return result.Entity;
        }
        private string generateJwtToken(Scoala scoala)
        {
            // generate token that is valid for 1 day
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", scoala.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
