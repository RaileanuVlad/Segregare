using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Segregare.Models;
using Segregare.Contexts;

namespace Segregare.Repositories.ClasaRepository
{
    public class ClasaRepository: IClasaRepository
    {
        public Context _context { get; set; }

        public ClasaRepository(Context context)
        {
            _context = context;
        }
        public Clasa Create(Clasa clasa)
        {
            var result = _context.Add<Clasa>(clasa);
            _context.SaveChanges();
            return result.Entity;
        }
        public Clasa Get(int Id)
        {
            return _context.Clase.SingleOrDefault(x => x.Id == Id);
        }
        public List<Clasa> GetAll()
        {
            return _context.Clase.ToList();
        }
        public Clasa Update(Clasa clasa)
        {
            _context.Entry(clasa).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return clasa;
        }
        public Clasa Delete(Clasa clasa)
        {
            var result = _context.Remove(clasa);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
