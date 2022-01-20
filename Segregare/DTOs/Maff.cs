using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Segregare.DTOs
{
    public class Maff
    {
        public int IdMaff { get; set; }
        public string NumeScoala { get; set; }
        public string NumeU { get; set; }
        public string JudetS { get; set; }
        public string LocalitateS { get; set; }
        public string LocalitateU { get; set; }
        public string StatutU { get; set; }
        public int ScoalaId { get; set; }
        public bool ExistaClasa15 { get; set; }
        public int RomiScoala { get; set; }
        public int ParintiScoala { get; set; }
        public int DizabilitatiScoala { get; set; }
        public string Raspuns38 { get; set; }
        public string Raspuns39 { get; set; }
        public string Raspuns40 { get; set; }
        public string Raspuns41 { get; set; }
        public string Raspuns46 { get; set; }
        public string Raspuns47 { get; set; }
        public double RomiP { get; set; }
        public double RomiLocalitate { get; set; }
        public List<string> BadClasaNume { get; set; }
        public List<int> BadClasaId { get; set; }
        public int Total { get; set; }
        public int Romi { get; set; }
        public int Dizabilitati { get; set; }
        public int Parinti { get; set; }
        public int Burse { get; set; }
        public int Repetenti { get; set; }
        public int Online { get; set; }
        public int Remediala { get; set; }
        public int TotalC { get; set; }
        public int RomiC { get; set; }
        public int DizabilitatiC { get; set; }
        public int ParintiC { get; set; }
        public int BurseC { get; set; }
        public int RepetentiC { get; set; }
        public int OnlineC { get; set; }
        public int RemedialaC { get; set; }
        public string Alerta1 { get; set; }
        public string Alerta2 { get; set; }
        public string Alerta3 { get; set; }
        public string Alerta4 { get; set; }
        public string Alerta5 { get; set; }
        public string Alerta6 { get; set; }
        public string Alerta7 { get; set; }
        public string Alerta8 { get; set; }
        public string Alerta9 { get; set; }
        public string Alerta10 { get; set; }
        public string Alerta11 { get; set; }
        public string NrDep { get; set; }
        public string NrDepC { get; set; }

    }
}
