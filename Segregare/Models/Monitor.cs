using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Segregare.Models
{
    public class Monitor
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }
        public string Judet { get; set; }
        public List<MonitorIntrebare> MonitorIntrebare { get; set; }
    }
}
