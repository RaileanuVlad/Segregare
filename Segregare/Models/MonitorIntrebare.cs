using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Segregare.Models
{
    public class MonitorIntrebare
    {
        public int Id { get; set; }
        public int MonitorId { get; set; }
        public int IntrebareId { get; set; }
        public string Raspuns { get; set; }
        public string Raspuns2 { get; set; }
        public string Raspuns3 { get; set; }
        public string Raspuns4 { get; set; }
        public string Path { get; set; }
        public string Data { get; set; }
        public int Unitate { get; set; }
        public virtual Monitor Monitor { get; set; }
        public virtual Intrebare Intrebare { get; set; }
    }
}
