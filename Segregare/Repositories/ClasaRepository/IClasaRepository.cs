using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Segregare.Models;

namespace Segregare.Repositories.ClasaRepository
{
    public interface IClasaRepository
    {
        List<Clasa> GetAll();
        Clasa Get(int Id);
        Clasa Create(Clasa clasa);
        Clasa Update(Clasa clasa);
        Clasa Delete(Clasa clasa);
    }
}
