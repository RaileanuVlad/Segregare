using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Segregare.Models
{
    public class Scoala
    {
        public int Id { get; set; }
        public string Judet { get; set; }
        public string Mediu { get; set; }
        public string Nume { get; set; }
        public string Sirues { get; set; }
        public string Director { get; set; }
        public string FurnizorDate { get; set; }
        public string NrFurnizor { get; set; }
        public string Total { get; set; }
        public string Romi { get; set; }
        public string Dizabilitati { get; set; }
        public string Parinti { get; set; }
        public string Burse { get; set; }
        public string Repetenti { get; set; }
        public string Online { get; set; }
        public string Remediala { get; set; }
        public string Explicatie { get; set; }
        public string Checked { get; set; }
        public string Semnatura { get; set; }
        public string NrInreg { get; set; }
        public string SiruesC { get; set; }
        public string DirectorC { get; set; }
        public string FurnizorDateC { get; set; }
        public string NrFurnizorC { get; set; }
        public string TotalC { get; set; }
        public string RomiC { get; set; }
        public string RomiE { get; set; }
        public string DizabilitatiC { get; set; }
        public string ParintiC { get; set; }
        public string BurseC { get; set; }
        public string RepetentiC { get; set; }
        public string OnlineC { get; set; }
        public string RemedialaC { get; set; }
        public string ExplicatieC { get; set; }
        public string CheckedC { get; set; }
        public string SemnaturaC { get; set; }
        public string NrInregC { get; set; }
        public string NrIntr { get; set; }
        public string DataIntr { get; set; }
        public string Email { get; set; }
        public string Parola { get; set; }
        public List <Unitate> Unitate { get; set; }
        public List<ScoalaIntrebare> ScoalaIntrebare { get; set; }
    }
}
