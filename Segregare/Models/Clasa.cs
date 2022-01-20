using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Segregare.Models
{
    public class Clasa
    {
        public int Id { get; set; }
        public string Cifra { get; set; }
        public string Litera { get; set; }
        public string Total { get; set; }
        public string Romi { get; set; }
        public string Dizabilitati { get; set; }
        public string Parinti { get; set; }
        public string Burse { get; set; }
        public string Repetenti { get; set; }
        public string Online { get; set; }
        public string Remediala { get; set; }

        public string Total2b { get; set; }
        public string Romi2b { get; set; }
        public string Dizabilitati2b { get; set; }
        public string Parinti2b { get; set; }
        public string Burse2b { get; set; }
        public string Repetenti2b { get; set; }
        public string Online2b { get; set; }
        public string Remediala2b { get; set; }
        public string Cladire { get; set; }
        public string Predare { get; set; }
        public bool Mixt { get; set; }
        public string Ani { get; set; }
        public string Data { get; set; }

        public string CifraC { get; set; }
        public string LiteraC { get; set; }
        public string TotalC { get; set; }
        public string RomiC { get; set; }
        public string RomiE { get; set; }
        public string DizabilitatiC { get; set; }
        public string ParintiC { get; set; }
        public string BurseC { get; set; }
        public string RepetentiC { get; set; }
        public string OnlineC { get; set; }
        public string RemedialaC { get; set; }

        public string Total2bC { get; set; }
        public string Romi2bC { get; set; }
        public string Dizabilitati2bC { get; set; }
        public string Parinti2bC { get; set; }
        public string Burse2bC { get; set; }
        public string Repetenti2bC { get; set; }
        public string Online2bC { get; set; }
        public string Remediala2bC { get; set; }
        public string CladireC { get; set; }
        public string PredareC { get; set; }
        public bool MixtC { get; set; }
        public string AniC { get; set; }
        public string DataC { get; set; }
        public string Moderator { get; set; }
        public int UnitateId { get; set; }
        public virtual Unitate Unitate { get; set; }
    }
}
