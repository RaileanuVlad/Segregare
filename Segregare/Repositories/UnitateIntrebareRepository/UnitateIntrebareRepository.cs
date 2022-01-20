using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Segregare.Models;
using Segregare.Contexts;

namespace Segregare.Repositories.UnitateIntrebareRepository
{
    public class UnitateIntrebareRepository : IUnitateIntrebareRepository
    {
        public Context _context { get; set; }

        public UnitateIntrebareRepository (Context context)
        {
            _context = context;
        }
        public UnitateIntrebare Create(UnitateIntrebare unitateIntrebare)
        {
            var result = _context.Add<UnitateIntrebare>(unitateIntrebare);
            _context.SaveChanges();
            return result.Entity;
        }
        public UnitateIntrebare Get(int Id)
        {
            return _context.UnitateIntrebari.SingleOrDefault(x => x.Id == Id);
        }

        public UnitateIntrebare GetUI(int idU, int idI)
        {
            return _context.UnitateIntrebari.SingleOrDefault(x => x.UnitateId == idU && x.IntrebareId == idI);
        }

        public List<UnitateIntrebare> GetU(int idU)
        {
            return _context.UnitateIntrebari.Where(x => x.UnitateId == idU).ToList();
        }
        public List<UnitateIntrebare> GetAll()
        {
            return _context.UnitateIntrebari.ToList();
        }
        public UnitateIntrebare Update(UnitateIntrebare unitateIntrebare)
        {
            _context.Entry(unitateIntrebare).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return unitateIntrebare;
        }
        public UnitateIntrebare Delete(UnitateIntrebare unitateIntrebare)
        {
            var result = _context.Remove(unitateIntrebare);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
