using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Segregare.DTOs;
using Segregare.Models;
using Segregare.Repositories.IntrebareRepository;


namespace Segregare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntrebareController : ControllerBase
    {
        public IIntrebareRepository IIntrebareRepository { get; set; }

        public IntrebareController(IIntrebareRepository repository)
        {
            IIntrebareRepository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Intrebare>> Get()
        {
            return IIntrebareRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Intrebare> Get(int id)
        {
            return IIntrebareRepository.Get(id);
        }

        [HttpGet("tip/{Tip}")]
        public ActionResult<IEnumerable<Intrebare>> GetTip(string Tip)
        {
            return IIntrebareRepository.GetTip(Tip);
        }

        [HttpPost]
        public Intrebare Post(IntrebareDTO value)
        {
            Intrebare model = new Intrebare
            {
                Text = value.Text,
                Flavor = value.Flavor,
                Tip = value.Tip,
                Upload = value.Upload,
                Pentru = value.Pentru
            };
            return IIntrebareRepository.Create(model);
        }

        [HttpPut("{id}")]
        public Intrebare Put(int id, IntrebareDTO value)
        {
            Intrebare model = IIntrebareRepository.Get(id);
            if (value.Text != null)
            {
                model.Text = value.Text;
            }
            if (value.Flavor != null)
            {
                model.Flavor = value.Flavor;
            }
            if (value.Tip != null)
            {
                model.Tip = value.Tip;
            }

            model.Upload = value.Upload;
            
            if (value.Pentru != null)
            {
                model.Pentru = value.Pentru;
            }
         
            return IIntrebareRepository.Update(model);
        }

        [HttpDelete("{id}")]
        public Intrebare Delete(int id)
        {
            Intrebare model = IIntrebareRepository.Get(id);
            return IIntrebareRepository.Delete(model);
        }
    }
}
