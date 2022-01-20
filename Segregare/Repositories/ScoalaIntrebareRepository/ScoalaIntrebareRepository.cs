using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Segregare.Models;
using Segregare.Contexts;

namespace Segregare.Repositories.ScoalaIntrebareRepository
{
    public class ScoalaIntrebareRepository : IScoalaIntrebareRepository
    {
        public Context _context { get; set; }

        public ScoalaIntrebareRepository(Context context)
        {
            _context = context;
        }
        public ScoalaIntrebare Create(ScoalaIntrebare scoalaIntrebare)
        {
            var result = _context.Add<ScoalaIntrebare>(scoalaIntrebare);
            _context.SaveChanges();
            return result.Entity;
        }
        public ScoalaIntrebare Get(int Id)
        {
            return _context.ScoalaIntrebari.SingleOrDefault(x => x.Id == Id);
        }

        public ScoalaIntrebare GetSI(int idS, int idI)
        {
            return _context.ScoalaIntrebari.SingleOrDefault(x => x.ScoalaId == idS && x.IntrebareId == idI);
        }

        public List<ScoalaIntrebare> GetS(int idS)
        {
            return _context.ScoalaIntrebari.Where(x => x.ScoalaId == idS).ToList();
        }
        public List<ScoalaIntrebare> GetAll()
        {
            return _context.ScoalaIntrebari.ToList();
        }
        public ScoalaIntrebare Update(ScoalaIntrebare scoalaIntrebare)
        {
            _context.Entry(scoalaIntrebare).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return scoalaIntrebare;
        }
        public ScoalaIntrebare Delete(ScoalaIntrebare scoalaIntrebare)
        {
            var result = _context.Remove(scoalaIntrebare);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
