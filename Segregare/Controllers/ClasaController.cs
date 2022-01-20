using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Segregare.Models;
using Segregare.DTOs;
using Segregare.Repositories.ClasaRepository;



namespace Segregare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClasaController : ControllerBase
    {
        public IClasaRepository IClasaRepository { get; set; }
        public ClasaController(IClasaRepository clasaRepository)
        {
            IClasaRepository = clasaRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Clasa>> Get()
        {
            return IClasaRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Clasa> Get(int id)
        {
            return IClasaRepository.Get(id);
        }

        [HttpPost]
        public Clasa Post(ClasaDTO value)
        {
            Clasa model = new Clasa
            {
                Cifra = value.Cifra,
                Litera = value.Litera,
                Total = value.Total,
                Romi = value.Romi,
                Dizabilitati = value.Dizabilitati,
                Parinti = value.Parinti,
                Burse = value.Burse,
                Repetenti = value.Repetenti,
                Online = value.Online,
                Remediala = value.Remediala,
                Total2b = value.Total2b,
                Romi2b = value.Romi2b,
                Dizabilitati2b = value.Dizabilitati2b,
                Parinti2b = value.Parinti2b,
                Burse2b = value.Burse2b,
                Repetenti2b = value.Repetenti2b,
                Online2b = value.Online2b,
                Remediala2b = value.Remediala2b,
                Cladire = value.Cladire,
                Predare = value.Predare,
                Mixt = value.Mixt,
                Ani = value.Ani,
                CifraC = value.CifraC,
                LiteraC = value.LiteraC,
                TotalC = value.TotalC,
                RomiC = value.RomiC,
                RomiE = value.RomiE,
                DizabilitatiC = value.DizabilitatiC,
                ParintiC = value.ParintiC,
                BurseC = value.BurseC,
                RepetentiC = value.RepetentiC,
                OnlineC = value.OnlineC,
                RemedialaC = value.RemedialaC,
                Total2bC = value.Total2bC,
                Romi2bC = value.Romi2bC,
                Dizabilitati2bC = value.Dizabilitati2bC,
                Parinti2bC = value.Parinti2bC,
                Burse2bC = value.Burse2bC,
                Repetenti2bC = value.Repetenti2bC,
                Online2bC = value.Online2bC,
                Remediala2bC = value.Remediala2bC,
                CladireC = value.CladireC,
                PredareC = value.PredareC,
                MixtC = value.MixtC,
                AniC = value.AniC,
                Moderator = value.Moderator,
                UnitateId = value.UnitateId
            };
            if (value.DataC != null)
                model.DataC = DateTime.Now.AddHours(3).ToString();
            else
            {
                model.Data = DateTime.Now.AddHours(3).ToString();
            }

            return IClasaRepository.Create(model);
        }

        [HttpPut("{id}")]
        public Clasa Put(int id, ClasaDTO value)
        {
            Clasa model = IClasaRepository.Get(id);
            if (value.Cifra != null)
            {
                model.Cifra = value.Cifra;
            }
            if (value.Litera != null)
            {
                model.Litera = value.Litera;
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
            if (value.Total2b != null)
            {
                model.Total2b = value.Total2b;
            }
            if (value.Romi2b != null)
            {
                model.Romi2b = value.Romi2b;
            }
            if (value.Dizabilitati2b != null)
            {
                model.Dizabilitati2b = value.Dizabilitati2b;
            }
            if (value.Parinti2b != null)
            {
                model.Parinti2b = value.Parinti2b;
            }
            if (value.Online2b != null)
            {
                model.Online2b = value.Online2b;
            }
            if (value.Burse2b != null)
            {
                model.Burse2b = value.Burse2b;
            }
            if (value.Repetenti2b != null)
            {
                model.Repetenti2b = value.Repetenti2b;
            }
            if (value.Remediala2b != null)
            {
                model.Remediala2b = value.Remediala2b;
            }
            if (value.Cladire != null)
            {
                model.Cladire = value.Cladire;
            }
            if (value.Predare != null)
            {
                model.Predare = value.Predare;
            }
            model.Mixt = value.Mixt;
            if (value.Ani != null)
            {
                model.Ani = value.Ani;
            }


            if (value.CifraC != null)
            {
                model.CifraC = value.CifraC;
            }
            if (value.LiteraC != null)
            {
                model.LiteraC = value.LiteraC;
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
            if (value.Total2bC != null)
            {
                model.Total2bC = value.Total2bC;
            }
            if (value.Romi2bC != null)
            {
                model.Romi2bC = value.Romi2bC;
            }
            if (value.Dizabilitati2bC != null)
            {
                model.Dizabilitati2bC = value.Dizabilitati2bC;
            }
            if (value.Parinti2bC != null)
            {
                model.Parinti2bC = value.Parinti2bC;
            }
            if (value.Online2bC != null)
            {
                model.Online2bC = value.Online2bC;
            }
            if (value.Burse2bC != null)
            {
                model.Burse2bC = value.Burse2bC;
            }
            if (value.Repetenti2bC != null)
            {
                model.Repetenti2bC = value.Repetenti2bC;
            }
            if (value.Remediala2bC != null)
            {
                model.Remediala2bC = value.Remediala2bC;
            }
            if (value.CladireC != null)
            {
                model.CladireC = value.CladireC;
            }
            if (value.PredareC != null)
            {
                model.PredareC = value.PredareC;
            }
            model.MixtC = value.MixtC;
            if (value.AniC != null)
            {
                model.AniC = value.AniC;
            }

            if (value.Moderator != null)
            {
                model.Moderator = value.Moderator;
            }


            if (value.DataC != null)
                model.DataC = DateTime.Now.AddHours(3).ToString();
            else
            {
                model.Data = DateTime.Now.AddHours(3).ToString();
            }


            if (value.UnitateId != 0)
            {
                model.UnitateId = value.UnitateId;
            }
            return IClasaRepository.Update(model);
        }

        [HttpDelete("{id}")]
        public Clasa Delete(int id)
        {
            Clasa model = IClasaRepository.Get(id);
            return IClasaRepository.Delete(model);
        }
    }
}
