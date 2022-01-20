using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Segregare.Models;

namespace Segregare.Repositories.UnitateIntrebareRepository
{
    public interface IUnitateIntrebareRepository
    {
        List<UnitateIntrebare> GetAll();
        UnitateIntrebare Get(int Id);
        UnitateIntrebare GetUI(int idU, int idI);
        List<UnitateIntrebare> GetU(int idU);
        UnitateIntrebare Create(UnitateIntrebare unitateIntrebare);
        UnitateIntrebare Update(UnitateIntrebare unitateIntrebare);
        UnitateIntrebare Delete(UnitateIntrebare unitateIntrebare);
    }
}
