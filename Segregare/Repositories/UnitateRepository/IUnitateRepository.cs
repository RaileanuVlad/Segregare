using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Segregare.Models;

namespace Segregare.Repositories.UnitateRepository
{
    public interface IUnitateRepository
    {
        List<Unitate> GetAll();
        Unitate Get(int Id);
        Unitate Create(Unitate unitate);
        Unitate Update(Unitate unitate);
        Unitate Delete(Unitate unitate);
    }
}
