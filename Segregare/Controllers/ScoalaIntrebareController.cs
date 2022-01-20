using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Segregare.DTOs;
using Segregare.Models;
using Segregare.Repositories.ScoalaIntrebareRepository;


namespace Segregare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoalaIntrebareController : ControllerBase
    {
        public IScoalaIntrebareRepository IScoalaIntrebareRepository { get; set; }
        public ScoalaIntrebareController(IScoalaIntrebareRepository repository)
        {
            IScoalaIntrebareRepository = repository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<ScoalaIntrebare>> Get()
        {
            return IScoalaIntrebareRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<ScoalaIntrebare> Get(int id)
        {
            return IScoalaIntrebareRepository.Get(id);
        }

        [HttpGet("{idS}/{idI}")]
        public ActionResult<ScoalaIntrebare> GetSI(int idS, int idI)
        {
            return IScoalaIntrebareRepository.GetSI(idS, idI);
        }

        [HttpGet("byIdS")]
        public ActionResult<IEnumerable<ScoalaIntrebare>> GetS(int idS)
        {
            return IScoalaIntrebareRepository.GetS(idS);
        }


      

        [HttpPost]
        public ScoalaIntrebare Post(ScoalaIntrebareDTO value)
        {
            ScoalaIntrebare model = new ScoalaIntrebare
            {
                ScoalaId = value.ScoalaId,
                IntrebareId = value.IntrebareId,
                Raspuns = value.Raspuns,
                Path = value.Path,
                Data = DateTime.Now.AddHours(3).ToString(),
                RaspunsC = value.RaspunsC,
                PathC = value.PathC,
                DataC = DateTime.Now.AddHours(3).ToString()
            };
            return IScoalaIntrebareRepository.Create(model);
        }

        [HttpPut("{id}")]
        public ScoalaIntrebare Put(int id, ScoalaIntrebareDTO value)
        {
            ScoalaIntrebare model = IScoalaIntrebareRepository.Get(id);
            if (value.ScoalaId != 0)
            {
                model.ScoalaId = value.ScoalaId;
            }
            if (value.IntrebareId != 0)
            {
                model.IntrebareId = value.IntrebareId;
            }
            if (value.Raspuns != null)
            {
                model.Raspuns = value.Raspuns;
            }
            if (value.Path != null)
            {
                model.Path = value.Path;
            }
            if (value.RaspunsC != null)
            {
                model.RaspunsC = value.RaspunsC;
            }
            if (value.PathC != null)
            {
                model.PathC = value.PathC;
            }


            model.Data = DateTime.Now.AddHours(3).ToString();
            model.DataC = DateTime.Now.AddHours(3).ToString();


            return IScoalaIntrebareRepository.Update(model);
        }

        [HttpDelete("{id}")]
        public ScoalaIntrebare Delete(int id)
        {
            ScoalaIntrebare model = IScoalaIntrebareRepository.Get(id);
            return IScoalaIntrebareRepository.Delete(model);
        }

    }
}
