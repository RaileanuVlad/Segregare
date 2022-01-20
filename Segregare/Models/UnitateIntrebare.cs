using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Segregare.Models
{
    public class UnitateIntrebare
    {
        public int Id { get; set; }
        public int UnitateId { get; set; }
        public int IntrebareId { get; set; }
        public string Raspuns { get; set; }
        public string RaspunsC { get; set; }
        public string Path { get; set; }
        public string PathC { get; set; }
        public string Data { get; set; }
        public string DataC { get; set; }
        public virtual Unitate Unitate { get; set; }
        public virtual Intrebare Intrebare { get; set; }
    }
}
