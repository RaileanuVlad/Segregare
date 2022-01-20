using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Segregare.Models;
using Segregare.Contexts;

namespace Segregare.Repositories.UnitateRepository
{
    public class UnitateRepository: IUnitateRepository
    {
        public Context _context { get; set; }

        public UnitateRepository(Context context)
        {
            _context = context;
        }
        public Unitate Create(Unitate unitate)
        {
            var result = _context.Add<Unitate>(unitate);
            _context.SaveChanges();
            return result.Entity;
        }
        public Unitate Get(int Id)
        {
            return _context.Unitati.SingleOrDefault(x => x.Id == Id);
        }
        public List<Unitate> GetAll()
        {
            return _context.Unitati.ToList();
        }
        public Unitate Update(Unitate unitate)
        {
            _context.Entry(unitate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return unitate;
        }
        public Unitate Delete(Unitate unitate)
        {
            var result = _context.Remove(unitate);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
