using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Segregare.Models;

namespace Segregare.Repositories.ScoalaIntrebareRepository
{
    public interface IScoalaIntrebareRepository
    {
        List<ScoalaIntrebare> GetAll();
        ScoalaIntrebare Get(int Id);
        ScoalaIntrebare GetSI(int idS, int idI);
        List<ScoalaIntrebare> GetS(int idS);
        ScoalaIntrebare Create(ScoalaIntrebare scoalaIntrebare);
        ScoalaIntrebare Update(ScoalaIntrebare scoalaIntrebare);
        ScoalaIntrebare Delete(ScoalaIntrebare scoalaIntrebare);
    }

}
