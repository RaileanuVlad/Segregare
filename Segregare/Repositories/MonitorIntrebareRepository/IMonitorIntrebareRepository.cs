using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Segregare.Models;

namespace Segregare.Repositories.MonitorIntrebareRepository
{
    public interface IMonitorIntrebareRepository
    {
        List<MonitorIntrebare> GetAll();
        MonitorIntrebare Get(int Id);
        MonitorIntrebare GetMIUI(int idU, int idI);
        List<MonitorIntrebare> GetMIU(int idU);
        MonitorIntrebare Create(MonitorIntrebare monitorIntrebare);
        MonitorIntrebare Update(MonitorIntrebare monitorIntrebare);
        MonitorIntrebare Delete(MonitorIntrebare monitorIntrebare);
    }
}
