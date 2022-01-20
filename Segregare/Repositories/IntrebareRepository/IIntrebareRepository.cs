using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Segregare.Models;

namespace Segregare.Repositories.IntrebareRepository
{
    public interface IIntrebareRepository
    {
        List<Intrebare> GetAll();
        Intrebare Get(int Id);
        List<Intrebare> GetTip(string Tip);
        Intrebare Create(Intrebare intrebare);
        Intrebare Update(Intrebare intrebare);
        Intrebare Delete(Intrebare intrebare);

    }
}
