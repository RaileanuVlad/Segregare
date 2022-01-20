using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Segregare.DTOs
{
    public class UnitateDetailsDTO
    {
        public string Localitate { get; set; }
        public string Nume { get; set; }
        public string Statut { get; set; }
        public string Strada { get; set; }
        public string NrStrada { get; set; }
        public string CodPostal { get; set; }
        public string Telefon { get; set; }
        public string Fax { get; set; }
        public string Nivel { get; set; }
        public string Total { get; set; }
        public string Romi { get; set; }
        public string Dizabilitati { get; set; }
        public string Parinti { get; set; }
        public string Burse { get; set; }
        public string Repetenti { get; set; }
        public string Online { get; set; }
        public string Remediala { get; set; }
        public int NrCladiri { get; set; }
        public string NivelC { get; set; }
        public string TotalC { get; set; }
        public string RomiC { get; set; }
        public string RomiE { get; set; }
        public string DizabilitatiC { get; set; }
        public string ParintiC { get; set; }
        public string BurseC { get; set; }
        public string RepetentiC { get; set; }
        public string OnlineC { get; set; }
        public string RemedialaC { get; set; }
        public int NrCladiriC { get; set; }
        public int ScoalaId { get; set; }
        public string PathChestionar { get; set; }
        public string Moderator { get; set; }
        public List<string> ClasaNume { get; set; }
        public List<string> ClasaNume1 { get; set; }
        public List<string> ClasaNume2 { get; set; }
        public List<string> ClasaNumeC { get; set; }
        public List<string> ClasaNume1C { get; set; }
        public List<string> ClasaNume2C { get; set; }
        public List<int> ClasaId { get; set; }
        public List<int> ClasaId1 { get; set; }
        public List<int> ClasaId2 { get; set; }
        public List<string> ClasaCount { get; set; }
        public List<string> ClasaCount1 { get; set; }
        public List<string> ClasaCount2 { get; set; }
        public List<string> ClasaModerator { get; set; }
    }
}
