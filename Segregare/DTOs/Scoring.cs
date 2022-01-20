using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Segregare.DTOs
{
    public class Scoring
    {
        public int IdScoring { get; set; }
        public string NumeScoala { get; set; }
        public string JudetS { get; set; }
        public string LocalitateS { get; set; }



        public string NumeU { get; set; }
        public string StatutU { get; set; }
        public double RomiUnitateP { get; set; }
        public double DizabilitatiUnitateP { get; set; }
        public double ParintiUnitateP { get; set; }
        public double BurseUnitateP { get; set; }

        public List<double> TotalCladire { get; set; }
        public List<double> RomiCladire { get; set; }
        public List<double> DizabilitatiCladire { get; set; }
        public List<double> ParintiCladire { get; set; }
        public List<double> BurseCladire { get; set; }

        public List<double> RomiScorCladire { get; set; }
        public List<double> DizabilitatiScorCladire { get; set; }
        public List<double> ParintiScorCladire { get; set; }
        public List<double> BurseScorCladire { get; set; }

        public int RomiScorCladireIndex { get; set; }
        public int DizabilitatiScorCladireIndex { get; set; }
        public int ParintiScorCladireIndex { get; set; }
        public int BurseScorCladireIndex { get; set; }


        public List<double> TotalNivel { get; set; }
        public List<double> RomiNivel { get; set; }
        public List<double> DizabilitatiNivel { get; set; }
        public List<double> ParintiNivel { get; set; }
        public List<double> BurseNivel { get; set; }
        public List<double> RepetentiNivel { get; set; }
        public List<double> OnlineNivel { get; set; }
        public List<double> RemedialaNivel { get; set; }

        public List<double> RomiScorNivel { get; set; }
        public List<double> DizabilitatiScorNivel { get; set; }
        public List<double> ParintiScorNivel { get; set; }
        public List<double> BurseScorNivel { get; set; }
        public List<double> RepetentiScorNivel { get; set; }
        public List<double> OnlineScorNivel { get; set; }
        public List<double> RemedialaScorNivel { get; set; }

        public List<double> RomiScorNivelValue { get; set; }
        public List<double> DizabilitatiScorNivelValue { get; set; }
        public List<double> ParintiScorNivelValue { get; set; }
        public List<double> BurseScorNivelValue { get; set; }
        public List<double> RepetentiScorNivelValue { get; set; }
        public List<double> OnlineScorNivelValue { get; set; }
        public List<double> RemedialaScorNivelValue { get; set; }

        public List<string> RomiScorNivelIndex { get; set; }
        public List<string> DizabilitatiScorNivelIndex { get; set; }
        public List<string> ParintiScorNivelIndex { get; set; }
        public List<string> BurseScorNivelIndex { get; set; }
        public List<string> RepetentiScorNivelIndex { get; set; }
        public List<string> OnlineScorNivelIndex { get; set; }
        public List<string> RemedialaScorNivelIndex { get; set; }


        public List<double> TotalScor2b { get; set; }
        public List<double> RomiScor2b { get; set; }
        public List<double> DizabilitatiScor2b { get; set; }
        public List<double> ParintiScor2b { get; set; }
        public List<double> BurseScor2b { get; set; }

        public List<double> TotalScor2bValue { get; set; }
        public List<double> RomiScor2bValue { get; set; }
        public List<double> DizabilitatiScor2bValue { get; set; }
        public List<double> ParintiScor2bValue { get; set; }
        public List<double> BurseScor2bValue { get; set; }

        public List<string> TotalScor2bIndex { get; set; }
        public List<string> RomiScor2bIndex { get; set; }
        public List<string> DizabilitatiScor2bIndex { get; set; }
        public List<string> ParintiScor2bIndex { get; set; }
        public List<string> BurseScor2bIndex { get; set; }




        public double ScorA1 { get; set; }
        public double ScorA2 { get; set; }
        public double ScorA3 { get; set; }
        public double ScorA4 { get; set; }
        public double ScorA5 { get; set; }
        public double ScorB1 { get; set; }
        public double ScorB2 { get; set; }
        public double ScorB3 { get; set; }
        public double ScorB4 { get; set; }
        public double ScorB5 { get; set; }
        public double ScorC1 { get; set; }
        public double ScorC2 { get; set; }
        public double ScorC3 { get; set; }
        public double ScorC4 { get; set; }
        public double ScorC5 { get; set; }
        public double ScorC6 { get; set; }
        public double ScorC7 { get; set; }
        public double ScorC8 { get; set; }
        public double ScorC9 { get; set; }
        public double ScorC10 { get; set; }
        public double ScorD1 { get; set; }
        public double ScorD2 { get; set; }
        public double ScorD3 { get; set; }
        public string NrDep { get; set; }
        public string NrDepC { get; set; }
        public int ScoalaId { get; set; }

        public int tempWOW { get; set; }
    }
}
