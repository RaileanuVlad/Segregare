using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Segregare.Models;
using Segregare.Helpers;

namespace Segregare.Repositories.ScoalaRepository
{
    public interface IScoalaRepository
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        List<Scoala> GetAll();
        Scoala Get(int Id);
        Scoala Create(Scoala scoala);
        Scoala Update(Scoala scoala);
        Scoala Delete(Scoala scoala);
    }
}
