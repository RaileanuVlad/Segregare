using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Segregare.DTOs;
using Segregare.Models;
using Segregare.Repositories.UnitateIntrebareRepository;



namespace Segregare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitateIntrebareController : ControllerBase
    {

        public IUnitateIntrebareRepository IUnitateIntrebareRepository { get; set; }
        public UnitateIntrebareController(IUnitateIntrebareRepository repository)
        {
            IUnitateIntrebareRepository = repository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<UnitateIntrebare>> Get()
        {
            return IUnitateIntrebareRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<UnitateIntrebare> Get(int id)
        {
            return IUnitateIntrebareRepository.Get(id);
        }

        [HttpGet("{idU}/{idI}")]
        public ActionResult<UnitateIntrebare> GetUI(int idU, int idI)
        {
            return IUnitateIntrebareRepository.GetUI(idU, idI);
        }

        [HttpGet("byIdU")]
        public ActionResult<IEnumerable<UnitateIntrebare>> GetU(int idU)
        {
            return IUnitateIntrebareRepository.GetU(idU);
        }


        [HttpPost]
        public UnitateIntrebare Post(UnitateIntrebareDTO value)
        {
            UnitateIntrebare model = new UnitateIntrebare
            {
                UnitateId = value.UnitateId,
                IntrebareId = value.IntrebareId,
                Raspuns = value.Raspuns,
                Path = value.Path,
                Data = DateTime.Now.AddHours(3).ToString(),
                RaspunsC = value.RaspunsC,
                PathC = value.PathC,
                DataC = DateTime.Now.AddHours(3).ToString()
            };
            return IUnitateIntrebareRepository.Create(model);
        }

        [HttpPut("{id}")]
        public UnitateIntrebare Put(int id, UnitateIntrebareDTO value)
        {
            UnitateIntrebare model = IUnitateIntrebareRepository.Get(id);
            if (value.UnitateId != 0)
            {
                model.UnitateId = value.UnitateId;
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
            return IUnitateIntrebareRepository.Update(model);
        }

        [HttpDelete("{id}")]
        public UnitateIntrebare Delete(int id)
        {
            UnitateIntrebare model = IUnitateIntrebareRepository.Get(id);
            return IUnitateIntrebareRepository.Delete(model);
        }
    }
}
