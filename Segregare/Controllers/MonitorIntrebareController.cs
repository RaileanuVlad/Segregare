using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Segregare.DTOs;
using Segregare.Models;
using Segregare.Repositories.MonitorIntrebareRepository;


namespace Segregare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitorIntrebareController : ControllerBase
    {
        public IMonitorIntrebareRepository IMonitorIntrebareRepository { get; set; }
        public MonitorIntrebareController(IMonitorIntrebareRepository repository)
        {
            IMonitorIntrebareRepository = repository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<MonitorIntrebare>> Get()
        {
            return IMonitorIntrebareRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<MonitorIntrebare> Get(int id)
        {
            return IMonitorIntrebareRepository.Get(id);
        }

        [HttpGet("{idU}/{idI}")]
        public ActionResult<MonitorIntrebare> GetMIUI(int idU, int idI)
        {
            return IMonitorIntrebareRepository.GetMIUI(idU, idI);
        }

        [HttpGet("byIdU")]
        public ActionResult<IEnumerable<MonitorIntrebare>> GetMIU(int idU)
        {
            return IMonitorIntrebareRepository.GetMIU(idU);
        }

       


        [HttpPost]
        public MonitorIntrebare Post(MonitorIntrebareDTO value)
        {
            MonitorIntrebare model = new MonitorIntrebare
            {
                MonitorId = value.MonitorId,
                IntrebareId = value.IntrebareId,
                Raspuns = value.Raspuns,
                Raspuns2 = value.Raspuns2,
                Raspuns3 = value.Raspuns3,
                Raspuns4 = value.Raspuns4,
                Unitate = value.Unitate,
                Data = DateTime.Now.AddHours(3).ToString()
            };
            return IMonitorIntrebareRepository.Create(model);
        }

        [HttpPut("{id}")]
        public MonitorIntrebare Put(int id, MonitorIntrebareDTO value)
        {
            MonitorIntrebare model = IMonitorIntrebareRepository.Get(id);
            if (value.MonitorId != 0)
            {
                model.MonitorId = value.MonitorId;
            }
            if (value.IntrebareId != 0)
            {
                model.IntrebareId = value.IntrebareId;
            }
            if (value.Raspuns != null)
            {
                model.Raspuns = value.Raspuns;
            }
            if (value.Raspuns2 != null)
            {
                model.Raspuns2 = value.Raspuns2;
            }
            if (value.Raspuns3 != null)
            {
                model.Raspuns3 = value.Raspuns3;
            }
            if (value.Raspuns4 != null)
            {
                model.Raspuns4 = value.Raspuns4;
            }
            if (value.Unitate != 0)
            {
                model.Unitate = value.Unitate;
            }
            model.Data = DateTime.Now.AddHours(3).ToString();
            return IMonitorIntrebareRepository.Update(model);
        }

        [HttpDelete("{id}")]
        public MonitorIntrebare Delete(int id)
        {
            MonitorIntrebare model = IMonitorIntrebareRepository.Get(id);
            return IMonitorIntrebareRepository.Delete(model);
        }
    }
}
