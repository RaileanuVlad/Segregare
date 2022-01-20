using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Segregare.Models;
using Segregare.Contexts;

namespace Segregare.Repositories.IntrebareRepository
{
    public class IntrebareRepository: IIntrebareRepository
    {
        public Context _context { get; set; }

        public IntrebareRepository(Context context)
        {
            _context = context;
        }
        public Intrebare Create(Intrebare intrebare)
        {
            var result = _context.Add<Intrebare>(intrebare);
            _context.SaveChanges();
            return result.Entity;
        }
        public Intrebare Get(int Id)
        {
            return _context.Intrebari.SingleOrDefault(x => x.Id == Id);
        }

        public List<Intrebare> GetTip(string Tip)
        {
            return _context.Intrebari.Where(x => x.Tip == Tip).ToList();
        }
        public List<Intrebare> GetAll()
        {
            return _context.Intrebari.ToList();
        }
        public Intrebare Update(Intrebare intrebare)
        {
            _context.Entry(intrebare).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return intrebare;
        }
        public Intrebare Delete(Intrebare intrebare)
        {
            var result = _context.Remove(intrebare);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
