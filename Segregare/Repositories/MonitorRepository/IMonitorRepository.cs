using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Segregare.Helpers;
using Segregare.Models;

namespace Segregare.Repositories.MonitorRepository
{
    public interface IMonitorRepository
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        List<Monitor> GetAll();
        Monitor Get(int Id);
        Monitor Create(Monitor monitor);
        Monitor Update(Monitor monitor);
        Monitor Delete(Monitor monitor);
    }
}
