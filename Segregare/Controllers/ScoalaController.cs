using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Segregare.DTOs;
using Segregare.Models;
using Segregare.Helpers;
using Segregare.Repositories.ScoalaRepository;
using Segregare.Repositories.UnitateRepository;
using Segregare.Repositories.ClasaRepository;
using Segregare.Repositories.UnitateIntrebareRepository;
using Segregare.Repositories.ScoalaIntrebareRepository;

namespace Segregare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoalaController : ControllerBase
    {
        public IScoalaRepository IScoalaRepository { get; set; }
        public IUnitateRepository IUnitateRepository { get; set; }
        public IUnitateIntrebareRepository IUnitateIntrebareRepository { get; set; }
        public IScoalaIntrebareRepository IScoalaIntrebareRepository { get; set; }
        public IClasaRepository IClasaRepository { get; set; }
        public ScoalaController(IScoalaRepository scoalaRepository, IUnitateRepository unitateRepository, IUnitateIntrebareRepository unitateIntrebareRepository, IScoalaIntrebareRepository scoalaIntrebareRepository, IClasaRepository clasaRepository)
        {
            IScoalaRepository = scoalaRepository;
            IUnitateRepository = unitateRepository;
            IUnitateIntrebareRepository = unitateIntrebareRepository;
            IScoalaIntrebareRepository = scoalaIntrebareRepository;
            IClasaRepository = clasaRepository;
        }
        [HttpGet]
        public List<ScoalaDetailsDTO> Get()
        {
            IEnumerable<Scoala> MyScoli = IScoalaRepository.GetAll();
            IEnumerable<Unitate> AllUnitati = IUnitateRepository.GetAll();
            IEnumerable<UnitateIntrebare> AllUnitateIntrebari = IUnitateIntrebareRepository.GetAll();
            IEnumerable<Clasa> AllClase = IClasaRepository.GetAll();

            List<ScoalaDetailsDTO> MyScoliDetailsDTO = new List<ScoalaDetailsDTO>();

            foreach(Scoala MyScoala in MyScoli)
            {
                switch (MyScoala.Judet)
                {
                    case "B":
                        MyScoala.Judet = "Bucuresti";
                        break;
                    case "BT":
                        MyScoala.Judet = "Botosani";
                        break;
                    case "BV":
                        MyScoala.Judet = "Brasov";
                        break;
                    case "CJ":
                        MyScoala.Judet = "Cluj";
                        break;
                    case "CT":
                        MyScoala.Judet = "Constanta";
                        break;
                    case "IL":
                        MyScoala.Judet = "Ialomita";
                        break;
                    case "IS":
                        MyScoala.Judet = "Iasi";
                        break;
                    case "MM":
                        MyScoala.Judet = "Maramures";
                        break;
                    case "MS":
                        MyScoala.Judet = "Mures";
                        break;
                    case "PH":
                        MyScoala.Judet = "Prahova";
                        break;
                    case "SV":
                        MyScoala.Judet = "Suceava";
                        break;
                    default:
                        break;
                }
                double TotalU = 0;
                double TotalUC = 0;
                double UComplet = 0;
                double UMax = 12;
                double CComplet = 0;
                double CMax = 9;
                double UCompletC = 0;
                double UMaxC = 12;
                double CCompletC = 0;
                double CMaxC = 9;
                List<double> UProcs = new List<double>();
                List<double> CProcs = new List<double>();
                List<double> UProcsC = new List<double>();
                List<double> CProcsC = new List<double>();
                ScoalaDetailsDTO MyScoalaDetailsDTO = new ScoalaDetailsDTO()
                {
                    Id = MyScoala.Id,
                    Judet = MyScoala.Judet,
                    Mediu = MyScoala.Mediu,
                    Nume = MyScoala.Nume,
                    Sirues = MyScoala.Sirues,
                    Director = MyScoala.Director,
                    FurnizorDate = MyScoala.FurnizorDate,
                    NrFurnizor = MyScoala.NrFurnizor,
                    Total = MyScoala.Total,
                    Romi = MyScoala.Romi,
                    Dizabilitati = MyScoala.Dizabilitati,
                    Parinti = MyScoala.Parinti,
                    Burse = MyScoala.Burse,
                    Repetenti = MyScoala.Repetenti,
                    Online = MyScoala.Online,
                    Remediala = MyScoala.Remediala,
                    Explicatie = MyScoala.Explicatie,
                    Checked = MyScoala.Checked,
                    Semnatura = MyScoala.Semnatura,
                    NrInreg = MyScoala.NrInreg,
                    SiruesC = MyScoala.SiruesC,
                    DirectorC = MyScoala.DirectorC,
                    FurnizorDateC = MyScoala.FurnizorDateC,
                    NrFurnizorC = MyScoala.NrFurnizorC,
                    TotalC = MyScoala.TotalC,
                    RomiC = MyScoala.RomiC,
                    RomiE = MyScoala.RomiE,
                    DizabilitatiC = MyScoala.DizabilitatiC,
                    ParintiC = MyScoala.ParintiC,
                    BurseC = MyScoala.BurseC,
                    RepetentiC = MyScoala.RepetentiC,
                    OnlineC = MyScoala.OnlineC,
                    RemedialaC = MyScoala.RemedialaC,
                    ExplicatieC = MyScoala.ExplicatieC,
                    CheckedC = MyScoala.CheckedC,
                    SemnaturaC = MyScoala.SemnaturaC,
                    NrInregC = MyScoala.NrInregC,
                    NrIntr = MyScoala.NrIntr,
                    DataIntr = MyScoala.DataIntr,
                    Email = MyScoala.Email,
                    Parola = MyScoala.Parola
                };
                
                if (MyScoala.Sirues != null) UComplet++;
                if (MyScoala.Director != null) UComplet++;
                if (MyScoala.FurnizorDate != null) UComplet++;
                if (MyScoala.NrFurnizor != null) UComplet++;
                if (MyScoala.Total != null) UComplet++;
                if (MyScoala.Romi != null) UComplet++;
                if (MyScoala.Dizabilitati != null) UComplet++;
                if (MyScoala.Parinti != null) UComplet++;
                if (MyScoala.Burse != null) UComplet++;
                if (MyScoala.Repetenti != null) UComplet++;
                if (MyScoala.Online != null) UComplet++;
                if (MyScoala.Remediala != null) UComplet++;

                if (MyScoala.SiruesC != null) UCompletC++;
                if (MyScoala.DirectorC != null) UCompletC++;
                if (MyScoala.FurnizorDateC != null) UCompletC++;
                if (MyScoala.NrFurnizorC != null) UCompletC++;
                if (MyScoala.TotalC != null) UCompletC++;
                if (MyScoala.RomiC != null) UCompletC++;
                if (MyScoala.DizabilitatiC != null) UCompletC++;
                if (MyScoala.ParintiC != null) UCompletC++;
                if (MyScoala.BurseC != null) UCompletC++;
                if (MyScoala.RepetentiC != null) UCompletC++;
                if (MyScoala.OnlineC != null) UCompletC++;
                if (MyScoala.RemedialaC != null) UCompletC++;

                UProcs.Add(UComplet / UMax * 100);
                UProcsC.Add(UCompletC / UMaxC * 100);

                IEnumerable<Unitate> MyUnitati = AllUnitati.Where(x => x.ScoalaId == MyScoala.Id);
                if (MyUnitati != null)
                {
                    List<string> NumeUnitateList = new List<string>();
                    List<int> IdUnitateList = new List<int>();
                    List<string> ModeratorUnitateList = new List<string>();
                    foreach (Unitate MyUnitate in MyUnitati)
                    {
                        if (MyUnitate.Total != null) TotalU += Int32.Parse(MyUnitate.Total);
                        if (MyUnitate.TotalC != null) TotalUC += Int32.Parse(MyUnitate.TotalC);
                        UComplet = 0;
                        UCompletC = 0;
                        UMax = 1;
                        UMaxC = 1;
                        NumeUnitateList.Add(MyUnitate.Nume);
                        IdUnitateList.Add(MyUnitate.Id);
                        ModeratorUnitateList.Add(MyUnitate.Moderator);
                        if (UProcs.Count() < 2)
                        {
                            MyScoalaDetailsDTO.Localitate = MyUnitate.Localitate;
                            MyScoalaDetailsDTO.Strada = MyUnitate.Strada;
                            MyScoalaDetailsDTO.NrStrada = MyUnitate.NrStrada;
                            IEnumerable<UnitateIntrebare> MyIntrebari = AllUnitateIntrebari.Where(x => x.UnitateId == MyUnitate.Id);
                            if (MyIntrebari.Count() > 0)
                            {
                                UMax = MyIntrebari.Count();
                                UMaxC = MyIntrebari.Count();
                                foreach (UnitateIntrebare MyIntrebare in MyIntrebari)
                                {
                                    if (MyIntrebare.Raspuns != null && MyIntrebare.Raspuns != "" && MyIntrebare.Raspuns != " ") UComplet += 1;
                                    if (MyIntrebare.RaspunsC != null && MyIntrebare.RaspunsC != "" && MyIntrebare.RaspunsC != " ") UCompletC += 1;
                                }
                               
                            }
                            UProcs.Add(UComplet / UMax * 100);
                            UProcsC.Add(UCompletC / UMaxC * 100);
                        }

                        CComplet = 0;
                        CCompletC = 0;
                        CMax = 9;
                        CMaxC = 9;

                        if (MyUnitate.Moderator != "2")
                        {
                            if (MyUnitate.Total != null) CComplet++;
                            if (MyUnitate.Romi != null) CComplet++;
                            if (MyUnitate.Dizabilitati != null) CComplet++;
                            if (MyUnitate.Parinti != null) CComplet++;
                            if (MyUnitate.Burse != null) CComplet++;
                            if (MyUnitate.Repetenti != null) CComplet++;
                            if (MyUnitate.Online != null) CComplet++;
                            if (MyUnitate.Remediala != null) CComplet++;
                            if (MyUnitate.NrCladiri != 0) CComplet++;
                            CProcs.Add(CComplet / CMax * 100);
                        }

                        if (MyUnitate.Moderator == "2")
                        {
                            if (MyUnitate.TotalC != null) CCompletC++;
                            if (MyUnitate.RomiC != null) CCompletC++;
                            if (MyUnitate.DizabilitatiC != null) CCompletC++;
                            if (MyUnitate.ParintiC != null) CCompletC++;
                            if (MyUnitate.BurseC != null) CCompletC++;
                            if (MyUnitate.RepetentiC != null) CCompletC++;
                            if (MyUnitate.OnlineC != null) CCompletC++;
                            if (MyUnitate.RemedialaC != null) CCompletC++;
                            if (MyUnitate.NrCladiriC != 0) CCompletC++;
                            CProcsC.Add(CCompletC / CMaxC * 100);
                        }


                        CComplet = 0;
                        CCompletC = 0;
                        CMax = 1;
                        CMaxC = 1;

                        IEnumerable<Clasa> MyClase = AllClase.Where(x => x.UnitateId == MyUnitate.Id);
                        if (MyClase.Count() > 0)
                        {
                            CMax = 0;
                            CMaxC = 0;
                            foreach (Clasa MyClasa in MyClase)
                            {

                                if (MyClasa.Moderator != "2")
                                {
                                    CComplet += 1;
                                    if (MyClasa.Total != null) CComplet += 1;
                                    if (MyClasa.Romi != null) CComplet += 1;
                                    if (MyClasa.Dizabilitati != null) CComplet += 1;
                                    if (MyClasa.Parinti != null) CComplet += 1;
                                    if (MyClasa.Burse != null) CComplet += 1;
                                    if (MyClasa.Repetenti != null) CComplet += 1;
                                    if (MyClasa.Online != null) CComplet += 1;
                                    if (MyClasa.Remediala != null) CComplet += 1;
                                    if (MyClasa.Total2b != null) CComplet += 1;
                                    if (MyClasa.Romi2b != null) CComplet += 1;
                                    if (MyClasa.Dizabilitati2b != null) CComplet += 1;
                                    if (MyClasa.Parinti2b != null) CComplet += 1;
                                    if (MyClasa.Burse2b != null) CComplet += 1;
                                    if (MyClasa.Repetenti2b != null) CComplet += 1;
                                    if (MyClasa.Online2b != null) CComplet += 1;
                                    if (MyClasa.Remediala2b != null) CComplet += 1;
                                    if (MyClasa.Predare != null) CComplet += 1;
                                    CMax += 18;
                                }

                                if (MyClasa.Moderator == "2")
                                {
                                    CCompletC += 1;
                                    if (MyClasa.TotalC != null) CCompletC += 1;
                                    if (MyClasa.RomiC != null) CCompletC += 1;
                                    if (MyClasa.DizabilitatiC != null) CCompletC += 1;
                                    if (MyClasa.ParintiC != null) CCompletC += 1;
                                    if (MyClasa.BurseC != null) CCompletC += 1;
                                    if (MyClasa.RepetentiC != null) CCompletC += 1;
                                    if (MyClasa.OnlineC != null) CCompletC += 1;
                                    if (MyClasa.RemedialaC != null) CCompletC += 1;
                                    if (MyClasa.Total2bC != null) CCompletC += 1;
                                    if (MyClasa.Romi2bC != null) CCompletC += 1;
                                    if (MyClasa.Dizabilitati2bC != null) CCompletC += 1;
                                    if (MyClasa.Parinti2bC != null) CCompletC += 1;
                                    if (MyClasa.Burse2bC != null) CCompletC += 1;
                                    if (MyClasa.Repetenti2bC != null) CCompletC += 1;
                                    if (MyClasa.Online2bC != null) CCompletC += 1;
                                    if (MyClasa.Remediala2bC != null) CCompletC += 1;
                                    if (MyClasa.PredareC != null) CCompletC += 1;
                                    CMaxC += 18;
                                }
                                
                                
                            }
                        }
                        if (MyUnitate.Moderator != "2") CProcs.Add(CComplet / CMax * 100);
                        if (CComplet == 0 || CCompletC != 0) CProcsC.Add(CCompletC / CMaxC * 100);

                    }

                    MyScoalaDetailsDTO.UProcent = Math.Round(UProcs.Average(), 2, MidpointRounding.AwayFromZero);
                    MyScoalaDetailsDTO.CProcent = Math.Round(CProcs.Average(), 2, MidpointRounding.AwayFromZero);
                    MyScoalaDetailsDTO.UProcentC = Math.Round(UProcsC.Average(), 2, MidpointRounding.AwayFromZero);
                    if (CProcsC.Count() > 0) MyScoalaDetailsDTO.CProcentC = Math.Round(CProcsC.Average(), 2, MidpointRounding.AwayFromZero);
                    else MyScoalaDetailsDTO.CProcentC = 100;

                    MyScoalaDetailsDTO.UnitateNume = NumeUnitateList;
                    MyScoalaDetailsDTO.UnitateId = IdUnitateList;
                    MyScoalaDetailsDTO.UnitateModerator = ModeratorUnitateList;
                    MyScoalaDetailsDTO.Checked = TotalU.ToString();
                    MyScoalaDetailsDTO.CheckedC = TotalUC.ToString();
                }
                MyScoliDetailsDTO.Add(MyScoalaDetailsDTO);
            }
            return MyScoliDetailsDTO;
        }

        [HttpGet("organizare")]
        public List<Organizare> GetOrganizare()
        {
            IEnumerable<Scoala> MyScoli = IScoalaRepository.GetAll();
            IEnumerable<Unitate> AllUnitati = IUnitateRepository.GetAll();
            IEnumerable<ScoalaIntrebare> AllScoalaIntrebari = IScoalaIntrebareRepository.GetAll();

            List<Organizare> MyOrganizari = new List<Organizare>();

            foreach (Scoala MyScoala in MyScoli)
            {
                switch (MyScoala.Judet)
                {
                    case "B":
                        MyScoala.Judet = "Bucuresti";
                        break;
                    case "BT":
                        MyScoala.Judet = "Botosani";
                        break;
                    case "BV":
                        MyScoala.Judet = "Brasov";
                        break;
                    case "CJ":
                        MyScoala.Judet = "Cluj";
                        break;
                    case "CT":
                        MyScoala.Judet = "Constanta";
                        break;
                    case "IL":
                        MyScoala.Judet = "Ialomita";
                        break;
                    case "IS":
                        MyScoala.Judet = "Iasi";
                        break;
                    case "MM":
                        MyScoala.Judet = "Maramures";
                        break;
                    case "MS":
                        MyScoala.Judet = "Mures";
                        break;
                    case "PH":
                        MyScoala.Judet = "Prahova";
                        break;
                    case "SV":
                        MyScoala.Judet = "Suceava";
                        break;
                    default:
                        break;
                }

                Organizare MyOrganizare = new Organizare()
                {
                    Id = MyScoala.Id,
                    Judet = MyScoala.Judet,
                    Mediu = MyScoala.Mediu,
                    Nume = MyScoala.Nume,
                    Sirues = MyScoala.Sirues,
                    Director = MyScoala.Director,
                    FurnizorDate = MyScoala.FurnizorDate,
                    NrFurnizor = MyScoala.NrFurnizor,
                    Explicatie = MyScoala.Explicatie,
                    NrInreg = MyScoala.NrInreg,
                    NrInregC = MyScoala.NrInregC,
                    
                };

                

                List<Unitate> MyUnitati = AllUnitati.Where(x => x.ScoalaId == MyScoala.Id).ToList();
                if (MyUnitati != null)
                {
                    MyOrganizare.Localitate = MyUnitati[0].Localitate;
                    MyOrganizare.Strada = MyUnitati[0].Strada;
                    MyOrganizare.NrStrada = MyUnitati[0].NrStrada;
                }

                List<ScoalaIntrebare> MyScoalaIntrebari = AllScoalaIntrebari.Where(x => x.ScoalaId == MyScoala.Id).ToList();

                if (MyScoalaIntrebari.Count() > 0)
                {
                    ScoalaIntrebare temp = null;
                    if (MyScoalaIntrebari.Where(x => x.IntrebareId == 71).FirstOrDefault() == null) MyOrganizare.Raspuns71 = null;
                    else MyOrganizare.Raspuns71 = MyScoalaIntrebari.Where(x => x.IntrebareId == 71).FirstOrDefault().RaspunsC;

                    if (MyScoalaIntrebari.Where(x => x.IntrebareId == 71).FirstOrDefault() == null) MyOrganizare.Upload71 = null;
                    else MyOrganizare.Upload71 = MyScoalaIntrebari.Where(x => x.IntrebareId == 71).FirstOrDefault().PathC;

                    if (MyScoalaIntrebari.Where(x => x.IntrebareId == 72).FirstOrDefault() == null) MyOrganizare.Raspuns72 = null;
                    else MyOrganizare.Raspuns72 = MyScoalaIntrebari.Where(x => x.IntrebareId == 72).FirstOrDefault().RaspunsC;

                    if (MyScoalaIntrebari.Where(x => x.IntrebareId == 73).FirstOrDefault() == null) MyOrganizare.Raspuns73 = null;
                    else MyOrganizare.Raspuns73 = MyScoalaIntrebari.Where(x => x.IntrebareId == 73).FirstOrDefault().RaspunsC;


                    temp = MyScoalaIntrebari.Where(x => x.IntrebareId == 5).FirstOrDefault();
                    if (temp != null) MyOrganizare.Raspuns5 = temp.RaspunsC; else MyOrganizare.Raspuns5 = null;

                    temp = MyScoalaIntrebari.Where(x => x.IntrebareId == 6).FirstOrDefault();
                    if (temp != null) MyOrganizare.Raspuns6 = temp.RaspunsC; else MyOrganizare.Raspuns6 = null;

                    temp = MyScoalaIntrebari.Where(x => x.IntrebareId == 7).FirstOrDefault();
                    if (temp != null) MyOrganizare.Raspuns7 = temp.RaspunsC; else MyOrganizare.Raspuns7 = null;

                    temp = MyScoalaIntrebari.Where(x => x.IntrebareId == 8).FirstOrDefault();
                    if (temp != null) MyOrganizare.Raspuns8 = temp.RaspunsC; else MyOrganizare.Raspuns8 = null;

                    temp = MyScoalaIntrebari.Where(x => x.IntrebareId == 9).FirstOrDefault();
                    if (temp != null) MyOrganizare.Raspuns9 = temp.RaspunsC; else MyOrganizare.Raspuns9 = null;

                    temp = MyScoalaIntrebari.Where(x => x.IntrebareId == 10).FirstOrDefault();
                    if (temp != null) MyOrganizare.Raspuns10 = temp.RaspunsC; else MyOrganizare.Raspuns10 = null;

                    temp = MyScoalaIntrebari.Where(x => x.IntrebareId == 11).FirstOrDefault();
                    if (temp != null) MyOrganizare.Raspuns11 = temp.RaspunsC; else MyOrganizare.Raspuns11 = null;

                    temp = MyScoalaIntrebari.Where(x => x.IntrebareId == 13).FirstOrDefault();
                    if (temp != null) MyOrganizare.Raspuns13 = temp.RaspunsC; else MyOrganizare.Raspuns13 = null;

                    temp = MyScoalaIntrebari.Where(x => x.IntrebareId == 14).FirstOrDefault();
                    if (temp != null) MyOrganizare.Raspuns14 = temp.RaspunsC; else MyOrganizare.Raspuns14 = null;

                    temp = MyScoalaIntrebari.Where(x => x.IntrebareId == 15).FirstOrDefault();
                    if (temp != null) MyOrganizare.Raspuns15 = temp.RaspunsC; else MyOrganizare.Raspuns15 = null;

                    temp = MyScoalaIntrebari.Where(x => x.IntrebareId == 16).FirstOrDefault();
                    if (temp != null) MyOrganizare.Raspuns16 = temp.RaspunsC; else MyOrganizare.Raspuns16 = null;

                    temp = MyScoalaIntrebari.Where(x => x.IntrebareId == 17).FirstOrDefault();
                    if (temp != null) MyOrganizare.Raspuns17 = temp.RaspunsC; else MyOrganizare.Raspuns17 = null;

                    temp = MyScoalaIntrebari.Where(x => x.IntrebareId == 18).FirstOrDefault();
                    if (temp != null) MyOrganizare.Raspuns18 = temp.RaspunsC; else MyOrganizare.Raspuns18 = null;

                    temp = MyScoalaIntrebari.Where(x => x.IntrebareId == 19).FirstOrDefault();
                    if (temp != null) MyOrganizare.Raspuns19 = temp.RaspunsC; else MyOrganizare.Raspuns19 = null;

                    temp = MyScoalaIntrebari.Where(x => x.IntrebareId == 20).FirstOrDefault();
                    if (temp != null) MyOrganizare.Raspuns20 = temp.RaspunsC; else MyOrganizare.Raspuns20 = null;

                    temp = MyScoalaIntrebari.Where(x => x.IntrebareId == 21).FirstOrDefault();
                    if (temp != null) MyOrganizare.Raspuns21 = temp.RaspunsC; else MyOrganizare.Raspuns21 = null;

                    temp = MyScoalaIntrebari.Where(x => x.IntrebareId == 22).FirstOrDefault();
                    if (temp != null) MyOrganizare.Raspuns22 = temp.RaspunsC; else MyOrganizare.Raspuns22 = null;

                    temp = MyScoalaIntrebari.Where(x => x.IntrebareId == 23).FirstOrDefault();
                    if (temp != null) MyOrganizare.Raspuns23 = temp.RaspunsC; else MyOrganizare.Raspuns23 = null;

                    temp = MyScoalaIntrebari.Where(x => x.IntrebareId == 24).FirstOrDefault();
                    if (temp != null) MyOrganizare.Raspuns24 = temp.RaspunsC; else MyOrganizare.Raspuns24 = null;

                    temp = MyScoalaIntrebari.Where(x => x.IntrebareId == 28).FirstOrDefault();
                    if (temp != null) MyOrganizare.Raspuns28 = temp.RaspunsC; else MyOrganizare.Raspuns28 = null;

                    temp = MyScoalaIntrebari.Where(x => x.IntrebareId == 29).FirstOrDefault();
                    if (temp != null) MyOrganizare.Raspuns29 = temp.RaspunsC; else MyOrganizare.Raspuns29 = null;

                    temp = MyScoalaIntrebari.Where(x => x.IntrebareId == 30).FirstOrDefault();
                    if (temp != null) MyOrganizare.Raspuns30 = temp.RaspunsC; else MyOrganizare.Raspuns30 = null;

                    temp = MyScoalaIntrebari.Where(x => x.IntrebareId == 30).FirstOrDefault();
                    if (temp != null) MyOrganizare.Upload30 = temp.PathC; else MyOrganizare.Upload30 = null;

                    temp = MyScoalaIntrebari.Where(x => x.IntrebareId == 31).FirstOrDefault();
                    if (temp != null) MyOrganizare.Raspuns31 = temp.RaspunsC; else MyOrganizare.Raspuns31 = null;

                    temp = MyScoalaIntrebari.Where(x => x.IntrebareId == 32).FirstOrDefault();
                    if (temp != null) MyOrganizare.Raspuns32 = temp.RaspunsC; else MyOrganizare.Raspuns32 = null;

                    temp = MyScoalaIntrebari.Where(x => x.IntrebareId == 33).FirstOrDefault();
                    if (temp != null) MyOrganizare.Raspuns33 = temp.RaspunsC; else MyOrganizare.Raspuns33 = null;

                    temp = MyScoalaIntrebari.Where(x => x.IntrebareId == 34).FirstOrDefault();
                    if (temp != null) MyOrganizare.Raspuns34 = temp.RaspunsC; else MyOrganizare.Raspuns34 = null;

                }

                


                MyOrganizari.Add(MyOrganizare);
            }
            return MyOrganizari;
        }

        [HttpGet("{id}")]
        public ScoalaDetailsDTO Get(int id)
        {
            double UComplet = 0;
            double UCompletC = 0;
            double UMax = 12;
            double UMaxC = 12;
            double CComplet = 0;
            double CCompletC = 0;
            double CMax = 9;
            double CMaxC = 9;
            double TotalU = 0;
            double TotalUC = 0;
            List<double> UProcs = new List<double>();
            List<double> UProcsC = new List<double>();
            List<double> CProcs = new List<double>();
            List<double> CProcsC = new List<double>();

            Scoala Scoala = IScoalaRepository.Get(id);
            ScoalaDetailsDTO MyScoala = new ScoalaDetailsDTO()
            {
                Judet = Scoala.Judet,
                Mediu = Scoala.Mediu,
                Nume = Scoala.Nume,
                Sirues = Scoala.Sirues,
                Director = Scoala.Director,
                FurnizorDate = Scoala.FurnizorDate,
                NrFurnizor = Scoala.NrFurnizor,
                Total = Scoala.Total,
                Romi = Scoala.Romi,
                Dizabilitati = Scoala.Dizabilitati,
                Parinti = Scoala.Parinti,
                Burse = Scoala.Burse,
                Repetenti = Scoala.Repetenti,
                Online = Scoala.Online,
                Remediala = Scoala.Remediala,
                Explicatie = Scoala.Explicatie,
                Checked = Scoala.Checked,
                Semnatura = Scoala.Semnatura,
                NrInreg = Scoala.NrInreg,
                SiruesC = Scoala.SiruesC,
                DirectorC = Scoala.DirectorC,
                FurnizorDateC = Scoala.FurnizorDateC,
                NrFurnizorC = Scoala.NrFurnizorC,
                TotalC = Scoala.TotalC,
                RomiC = Scoala.RomiC,
                RomiE = Scoala.RomiE,
                DizabilitatiC = Scoala.DizabilitatiC,
                ParintiC = Scoala.ParintiC,
                BurseC = Scoala.BurseC,
                RepetentiC = Scoala.RepetentiC,
                OnlineC = Scoala.OnlineC,
                RemedialaC = Scoala.RemedialaC,
                ExplicatieC = Scoala.ExplicatieC,
                CheckedC = Scoala.CheckedC,
                SemnaturaC = Scoala.SemnaturaC,
                NrInregC = Scoala.NrInregC,
                NrIntr = Scoala.NrIntr,
                DataIntr = Scoala.DataIntr,
                Email = Scoala.Email,
                Parola = Scoala.Parola
            };

            if (Scoala.Sirues != null) UComplet++;
            if (Scoala.Director != null) UComplet++;
            if (Scoala.FurnizorDate != null) UComplet++;
            if (Scoala.NrFurnizor != null) UComplet++;
            if (Scoala.Total != null) UComplet++;
            if (Scoala.Romi != null) UComplet++;
            if (Scoala.Dizabilitati != null) UComplet++;
            if (Scoala.Parinti != null) UComplet++;
            if (Scoala.Burse != null) UComplet++;
            if (Scoala.Repetenti != null) UComplet++;
            if (Scoala.Online != null) UComplet++;
            if (Scoala.Remediala != null) UComplet++;

            if (Scoala.SiruesC != null) UCompletC++;
            if (Scoala.DirectorC != null) UCompletC++;
            if (Scoala.FurnizorDateC != null) UCompletC++;
            if (Scoala.NrFurnizorC != null) UCompletC++;
            if (Scoala.TotalC != null) UCompletC++;
            if (Scoala.RomiC != null) UCompletC++;
            if (Scoala.DizabilitatiC != null) UCompletC++;
            if (Scoala.ParintiC != null) UCompletC++;
            if (Scoala.BurseC != null) UCompletC++;
            if (Scoala.RepetentiC != null) UCompletC++;
            if (Scoala.OnlineC != null) UCompletC++;
            if (Scoala.RemedialaC != null) UCompletC++;

            UProcs.Add(UComplet / UMax * 100);
            UProcsC.Add(UCompletC / UMaxC * 100);
            IEnumerable<Unitate> MyUnitati = IUnitateRepository.GetAll().Where(x => x.ScoalaId == Scoala.Id);
            if (MyUnitati != null)
            {
                List<string> NumeUnitateList = new List<string>();
                List<int> IdUnitateList = new List<int>();
                List<string> ModeratorUnitateList = new List<string>();
                foreach (Unitate MyUnitate in MyUnitati)
                {
                    if (MyUnitate.Total != null) TotalU += Int32.Parse(MyUnitate.Total);
                    if (MyUnitate.TotalC != null) TotalUC += Int32.Parse(MyUnitate.TotalC);
                    UComplet = 0;
                    UCompletC = 0;
                    UMax = 1;
                    UMaxC = 1;
                    NumeUnitateList.Add(MyUnitate.Nume);
                    IdUnitateList.Add(MyUnitate.Id);
                    ModeratorUnitateList.Add(MyUnitate.Moderator);
                    if (UProcs.Count() < 2)
                    {
                        MyScoala.Localitate = MyUnitate.Localitate;
                        MyScoala.Strada = MyUnitate.Strada;
                        MyScoala.NrStrada = MyUnitate.NrStrada;
                        IEnumerable<UnitateIntrebare> MyIntrebari = IUnitateIntrebareRepository.GetAll().Where(x => x.UnitateId == MyUnitate.Id);
                        if (MyIntrebari.Count() > 0)
                        {
                            UMax = MyIntrebari.Count();
                            UMaxC = MyIntrebari.Count();
                            foreach (UnitateIntrebare MyIntrebare in MyIntrebari)
                            {
                                if (MyIntrebare.Raspuns != null && MyIntrebare.Raspuns != "" && MyIntrebare.Raspuns != " ") UComplet += 1;
                                if (MyIntrebare.RaspunsC != null && MyIntrebare.RaspunsC != "" && MyIntrebare.RaspunsC != " ") UCompletC += 1;
                            }

                        }
                        UProcs.Add(UComplet / UMax * 100);
                        UProcsC.Add(UCompletC / UMaxC * 100);
                    }

                    CComplet = 0;
                    CCompletC = 0;
                    CMax = 9;
                    CMaxC = 9;



                    if (MyUnitate.Moderator != "2")
                    {
                        if (MyUnitate.Total != null) CComplet++;
                        if (MyUnitate.Romi != null) CComplet++;
                        if (MyUnitate.Dizabilitati != null) CComplet++;
                        if (MyUnitate.Parinti != null) CComplet++;
                        if (MyUnitate.Burse != null) CComplet++;
                        if (MyUnitate.Repetenti != null) CComplet++;
                        if (MyUnitate.Online != null) CComplet++;
                        if (MyUnitate.Remediala != null) CComplet++;
                        if (MyUnitate.NrCladiri != 0) CComplet++;
                        CProcs.Add(CComplet / CMax * 100);
                    }

                    if (MyUnitate.Moderator == "2")
                    {
                        if (MyUnitate.TotalC != null) CCompletC++;
                        if (MyUnitate.RomiC != null) CCompletC++;
                        if (MyUnitate.DizabilitatiC != null) CCompletC++;
                        if (MyUnitate.ParintiC != null) CCompletC++;
                        if (MyUnitate.BurseC != null) CCompletC++;
                        if (MyUnitate.RepetentiC != null) CCompletC++;
                        if (MyUnitate.OnlineC != null) CCompletC++;
                        if (MyUnitate.RemedialaC != null) CCompletC++;
                        if (MyUnitate.NrCladiriC != 0) CCompletC++;
                        CProcsC.Add(CCompletC / CMaxC * 100);
                    }


                    CComplet = 0;
                    CCompletC = 0;
                    CMax = 1;
                    CMaxC = 1;

                    IEnumerable<Clasa> MyClase = IClasaRepository.GetAll().Where(x => x.UnitateId == MyUnitate.Id);
                    if (MyClase.Count() > 0)
                    {
                        CMax = 0;
                        CMaxC = 0;
                        foreach (Clasa MyClasa in MyClase)
                        {

                            if (MyClasa.Moderator != "2")
                            {
                                CComplet += 1;
                                if (MyClasa.Total != null) CComplet += 1;
                                if (MyClasa.Romi != null) CComplet += 1;
                                if (MyClasa.Dizabilitati != null) CComplet += 1;
                                if (MyClasa.Parinti != null) CComplet += 1;
                                if (MyClasa.Burse != null) CComplet += 1;
                                if (MyClasa.Repetenti != null) CComplet += 1;
                                if (MyClasa.Online != null) CComplet += 1;
                                if (MyClasa.Remediala != null) CComplet += 1;
                                if (MyClasa.Total2b != null) CComplet += 1;
                                if (MyClasa.Romi2b != null) CComplet += 1;
                                if (MyClasa.Dizabilitati2b != null) CComplet += 1;
                                if (MyClasa.Parinti2b != null) CComplet += 1;
                                if (MyClasa.Burse2b != null) CComplet += 1;
                                if (MyClasa.Repetenti2b != null) CComplet += 1;
                                if (MyClasa.Online2b != null) CComplet += 1;
                                if (MyClasa.Remediala2b != null) CComplet += 1;
                                if (MyClasa.Predare != null) CComplet += 1;
                                CMax += 18;
                            }

                            if (MyClasa.Moderator == "2")
                            {
                                CCompletC += 1;
                                if (MyClasa.TotalC != null) CCompletC += 1;
                                if (MyClasa.RomiC != null) CCompletC += 1;
                                if (MyClasa.DizabilitatiC != null) CCompletC += 1;
                                if (MyClasa.ParintiC != null) CCompletC += 1;
                                if (MyClasa.BurseC != null) CCompletC += 1;
                                if (MyClasa.RepetentiC != null) CCompletC += 1;
                                if (MyClasa.OnlineC != null) CCompletC += 1;
                                if (MyClasa.RemedialaC != null) CCompletC += 1;
                                if (MyClasa.Total2bC != null) CCompletC += 1;
                                if (MyClasa.Romi2bC != null) CCompletC += 1;
                                if (MyClasa.Dizabilitati2bC != null) CCompletC += 1;
                                if (MyClasa.Parinti2bC != null) CCompletC += 1;
                                if (MyClasa.Burse2bC != null) CCompletC += 1;
                                if (MyClasa.Repetenti2bC != null) CCompletC += 1;
                                if (MyClasa.Online2bC != null) CCompletC += 1;
                                if (MyClasa.Remediala2bC != null) CCompletC += 1;
                                if (MyClasa.PredareC != null) CCompletC += 1;
                                CMaxC += 18;
                            }

                        }
                    }
                    if (MyUnitate.Moderator != "2") CProcs.Add(CComplet / CMax * 100);
                    if (CComplet == 0 || CCompletC != 0) CProcsC.Add(CCompletC / CMaxC * 100);


                }

                MyScoala.UProcent = Math.Round(UProcs.Average(), 2, MidpointRounding.AwayFromZero);
                MyScoala.CProcent = Math.Round(CProcs.Average(), 2, MidpointRounding.AwayFromZero);

                MyScoala.UProcentC = Math.Round(UProcsC.Average(), 2, MidpointRounding.AwayFromZero);

                if (CProcsC.Count() > 0) MyScoala.CProcentC = Math.Round(CProcsC.Average(), 2, MidpointRounding.AwayFromZero);
                else MyScoala.CProcentC = 100;


                MyScoala.UnitateNume = NumeUnitateList;
                MyScoala.UnitateId = IdUnitateList;
                MyScoala.UnitateModerator = ModeratorUnitateList;
                MyScoala.Checked = TotalU.ToString();
                MyScoala.CheckedC = TotalUC.ToString();
            }
            return MyScoala;
        }

        [HttpGet("progres")]
        public Progres GetP()
        {
            IEnumerable<Scoala> MyScoli = IScoalaRepository.GetAll();

            Progres dateProgres = new Progres();

            dateProgres.TBucuresti = MyScoli.Where(x => x.Judet == "B").Count();
            dateProgres.PBucuresti = MyScoli.Where(x => x.Judet == "B" && x.NrInreg != null).Count();

            dateProgres.TBotosani = MyScoli.Where(x => x.Judet == "BT").Count();
            dateProgres.PBotosani = MyScoli.Where(x => x.Judet == "BT" && x.NrInreg != null).Count();

            dateProgres.TBrasov = MyScoli.Where(x => x.Judet == "BV").Count();
            dateProgres.PBrasov = MyScoli.Where(x => x.Judet == "BV" && x.NrInreg != null).Count();

            dateProgres.TCluj = MyScoli.Where(x => x.Judet == "CJ").Count();
            dateProgres.PCluj = MyScoli.Where(x => x.Judet == "CJ" && x.NrInreg != null).Count();

            dateProgres.TConstanta = MyScoli.Where(x => x.Judet == "CT").Count();
            dateProgres.PConstanta = MyScoli.Where(x => x.Judet == "CT" && x.NrInreg != null).Count();

            dateProgres.TIalomita = MyScoli.Where(x => x.Judet == "IL").Count();
            dateProgres.PIalomita = MyScoli.Where(x => x.Judet == "IL" && x.NrInreg != null).Count();

            dateProgres.TIasi = MyScoli.Where(x => x.Judet == "IS").Count();
            dateProgres.PIasi = MyScoli.Where(x => x.Judet == "IS" && x.NrInreg != null).Count();

            dateProgres.TMaramures = MyScoli.Where(x => x.Judet == "MM").Count();
            dateProgres.PMaramures = MyScoli.Where(x => x.Judet == "MM" && x.NrInreg != null).Count();

            dateProgres.TMures = MyScoli.Where(x => x.Judet == "MS").Count();
            dateProgres.PMures = MyScoli.Where(x => x.Judet == "MS" && x.NrInreg != null).Count();

            dateProgres.TPrahova = MyScoli.Where(x => x.Judet == "PH").Count();
            dateProgres.PPrahova = MyScoli.Where(x => x.Judet == "PH" && x.NrInreg != null).Count();
            
            dateProgres.TSuceava = MyScoli.Where(x => x.Judet == "SV").Count();
            dateProgres.PSuceava = MyScoli.Where(x => x.Judet == "SV" && x.NrInreg != null).Count();

            return dateProgres;
        }

        [HttpPost]
        public Scoala Post(ScoalaDTO value)
        {
            Scoala model = new Scoala
            {
                Judet = value.Judet,
                Mediu = value.Mediu,
                Nume = value.Nume,
                Sirues = value.Sirues,
                Director = value.Director,
                FurnizorDate = value.FurnizorDate,
                NrFurnizor = value.NrFurnizor,
                Total = value.Total,
                Romi = value.Romi,
                Dizabilitati = value.Dizabilitati,
                Parinti = value.Parinti,
                Burse = value.Burse,
                Repetenti = value.Repetenti,
                Online = value.Online,
                Remediala = value.Remediala,
                Explicatie = value.Explicatie,
                Checked = value.Checked,
                Semnatura = value.Semnatura,
                NrInreg = value.NrInreg,
                SiruesC = value.SiruesC,
                DirectorC = value.DirectorC,
                FurnizorDateC = value.FurnizorDateC,
                NrFurnizorC = value.NrFurnizorC,
                TotalC = value.TotalC,
                RomiC = value.RomiC,
                RomiE = value.RomiE,
                DizabilitatiC = value.DizabilitatiC,
                ParintiC = value.ParintiC,
                BurseC = value.BurseC,
                RepetentiC = value.RepetentiC,
                OnlineC = value.OnlineC,
                RemedialaC = value.RemedialaC,
                ExplicatieC = value.ExplicatieC,
                CheckedC = value.CheckedC,
                SemnaturaC = value.SemnaturaC,
                NrInregC = value.NrInregC,
                NrIntr = value.NrIntr,
                DataIntr = value.DataIntr,
                Email = value.Email,
                Parola = value.Parola
            };
            return IScoalaRepository.Create(model);
            
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = IScoalaRepository.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [HttpPut("{id}")]
        public Scoala Put(int id, ScoalaDTO value)
        {
            Scoala model = IScoalaRepository.Get(id);
            if (value.Judet != null)
            {
                model.Judet = value.Judet;
            }
            if (value.Mediu != null)
            {
                model.Mediu = value.Mediu;
            }
            if (value.Nume != null)
            {
                model.Nume = value.Nume;
            }
            if (value.Sirues != null)
            {
                model.Sirues = value.Sirues;
            }
            if (value.Director != null)
            {
                model.Director = value.Director;
            }
            if (value.FurnizorDate != null)
            {
                model.FurnizorDate = value.FurnizorDate;
            }
            if (value.NrFurnizor != null)
            {
                model.NrFurnizor = value.NrFurnizor;
            }
            if (value.Total != null)
            {
                model.Total = value.Total;
            }
            if (value.Romi != null)
            {
                model.Romi = value.Romi;
            }
            if (value.Dizabilitati != null)
            {
                model.Dizabilitati = value.Dizabilitati;
            }
            if (value.Parinti != null)
            {
                model.Parinti = value.Parinti;
            }
            if (value.Online != null)
            {
                model.Online = value.Online;
            }
            if (value.Burse != null)
            {
                model.Burse = value.Burse;
            }
            if (value.Repetenti != null)
            {
                model.Repetenti = value.Repetenti;
            }
            if (value.Remediala != null)
            {
                model.Remediala = value.Remediala;
            }
            if (value.Explicatie != null)
            {
                model.Explicatie = value.Explicatie;
            }
            if (value.Checked != null)
            {
                model.Checked = value.Checked;
            }
            if (value.Semnatura != null)
            {
                model.Semnatura = value.Semnatura;
            }
            if (value.NrInreg != null)
            {
                model.NrInreg = value.NrInreg;
            }
            if (value.SiruesC != null)
            {
                model.SiruesC = value.SiruesC;
            }
            if (value.DirectorC != null)
            {
                model.DirectorC = value.DirectorC;
            }
            if (value.FurnizorDateC != null)
            {
                model.FurnizorDateC = value.FurnizorDateC;
            }
            if (value.NrFurnizorC != null)
            {
                model.NrFurnizorC = value.NrFurnizorC;
            }
            if (value.TotalC != null)
            {
                model.TotalC = value.TotalC;
            }
            if (value.RomiC != null)
            {
                model.RomiC = value.RomiC;
            }
            if (value.RomiE != null)
            {
                model.RomiE = value.RomiE;
            }
            if (value.DizabilitatiC != null)
            {
                model.DizabilitatiC = value.DizabilitatiC;
            }
            if (value.ParintiC != null)
            {
                model.ParintiC = value.ParintiC;
            }
            if (value.OnlineC != null)
            {
                model.OnlineC = value.OnlineC;
            }
            if (value.BurseC != null)
            {
                model.BurseC = value.BurseC;
            }
            if (value.RepetentiC != null)
            {
                model.RepetentiC = value.RepetentiC;
            }
            if (value.RemedialaC != null)
            {
                model.RemedialaC = value.RemedialaC;
            }
            if (value.ExplicatieC != null)
            {
                model.ExplicatieC = value.ExplicatieC;
            }
            if (value.CheckedC != null)
            {
                model.CheckedC = value.CheckedC;
            }
            if (value.SemnaturaC != null)
            {
                model.SemnaturaC = value.SemnaturaC;
            }
            if (value.NrInregC != null)
            {
                model.NrInregC = value.NrInregC;
            }
            if (value.NrIntr != null)
            {
                model.NrIntr = value.NrIntr;
            }
            if (value.DataIntr != null)
            {
                model.DataIntr = value.DataIntr;
            }
            if (value.Email != null)
            {
                model.Email = value.Email;
            }
            if (value.Parola != null)
            {
                model.Parola = value.Parola;
            }
            return IScoalaRepository.Update(model);
        }

        [HttpDelete("{id}")]
        public Scoala Delete(int id)
        {
            Scoala model = IScoalaRepository.Get(id);
            return IScoalaRepository.Delete(model);
        }
    }
}
