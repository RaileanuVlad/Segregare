using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Segregare.Models
{
    public class Intrebare
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Flavor { get; set; }
        public string Tip { get; set; }
        public bool Upload { get; set; }
        public string Pentru { get; set; }
        public List<ScoalaIntrebare> ScoalaIntrebare { get; set; }
        public List<MonitorIntrebare> MonitorIntrebare { get; set; }
    }
}
