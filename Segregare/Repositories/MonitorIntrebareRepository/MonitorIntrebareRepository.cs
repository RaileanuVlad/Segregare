using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Segregare.Models;
using Segregare.Contexts;

namespace Segregare.Repositories.MonitorIntrebareRepository
{
    public class MonitorIntrebareRepository: IMonitorIntrebareRepository
    {
        public Context _context { get; set; }

        public MonitorIntrebareRepository(Context context)
        {
            _context = context;
        }
        public MonitorIntrebare Create(MonitorIntrebare monitorIntrebare)
        {
            var result = _context.Add<MonitorIntrebare>(monitorIntrebare);
            _context.SaveChanges();
            return result.Entity;
        }
        public MonitorIntrebare Get(int Id)
        {
            return _context.MonitorIntrebari.SingleOrDefault(x => x.Id == Id);
        }
        public MonitorIntrebare GetMIUI(int idU, int idI)
        {
            return _context.MonitorIntrebari.SingleOrDefault(x => x.Unitate == idU && x.IntrebareId == idI);
        }
        public List<MonitorIntrebare> GetMIU(int IdU)
        {
            return _context.MonitorIntrebari.Where(x => x.Unitate == IdU).ToList();
        }
        public List<MonitorIntrebare> GetAll()
        {
            return _context.MonitorIntrebari.ToList();
        }
        public MonitorIntrebare Update(MonitorIntrebare monitorIntrebare)
        {
            _context.Entry(monitorIntrebare).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return monitorIntrebare;
        }
        public MonitorIntrebare Delete(MonitorIntrebare monitorIntrebare)
        {
            var result = _context.Remove(monitorIntrebare);
            _context.SaveChanges();
            return result.Entity;
        }
    }
}
