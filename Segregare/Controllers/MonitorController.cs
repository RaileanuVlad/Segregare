using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Segregare.DTOs;
using Segregare.Models;
using Segregare.Repositories.MonitorRepository;
using Segregare.Helpers;
using Segregare.Repositories.ScoalaRepository;

namespace Segregare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitorController : ControllerBase
    {
        public IMonitorRepository IMonitorRepository { get; set; }

        public MonitorController(IMonitorRepository monitorRepository)
        {
            IMonitorRepository = monitorRepository;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Monitor>> Get()
        {
            return IMonitorRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Monitor> Get(int id)
        {
            return IMonitorRepository.Get(id);
        }

        [HttpPost]
        public Monitor Post(MonitorDTO value)
        {
            Monitor model = new Monitor
            {
                Email = value.Email,
                Parola = value.Parola,
                Judet = value.Judet
            };
            return IMonitorRepository.Create(model);
        }

        [HttpPost("authenticatem")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = IMonitorRepository.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [HttpPut("{id}")]
        public Monitor Put(int id, MonitorDTO value)    
        {
            Monitor model = IMonitorRepository.Get(id);
            if (value.Email != null)
            {
                model.Email = value.Email;
            }
            if (value.Parola != null)
            {
                model.Parola = value.Parola;
            }
            if (value.Judet != null)
            {
                model.Judet = value.Judet;
            }
            return IMonitorRepository.Update(model);
        }

        [HttpDelete("{id}")]
        public Monitor Delete(int id)
        {
            Monitor model = IMonitorRepository.Get(id);
            return IMonitorRepository.Delete(model);
        }
    }
}
