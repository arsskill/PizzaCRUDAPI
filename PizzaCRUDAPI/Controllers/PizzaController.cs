using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaCRUDAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaCRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly PizzaRepository pizzaRepository;
        public PizzaController()
        {
            pizzaRepository = new PizzaRepository();
        }
        [HttpGet]
        public IEnumerable<Pizza> Get()
        {
            return pizzaRepository.GetAll();
        }
        [HttpGet("Byname")]
        public IEnumerable<Pizza> Get(string name)
        {
            return pizzaRepository.GetByName(name);
        }
        [HttpGet("ByActive")]
        public IEnumerable<Pizza> GetActive(string active)
        {
            return pizzaRepository.GetByName(active);
        }
        [HttpGet("ByNew")]
        public IEnumerable<Pizza> GetNew(string news)
        {
            return pizzaRepository.GetByName(news);
        }
        [HttpPost]
        public void Post([FromBody]Pizza piz)
        {
            if (ModelState.IsValid)
                pizzaRepository.Add(piz);
        }
        [HttpPut("{Name}")]
        public void Put(string name, [FromBody] Pizza piz)
        {
            piz.Name = name;
            if (ModelState.IsValid)
                pizzaRepository.Update(piz);
        }
        [HttpDelete]
        public void Delete(string name)
        {
            pizzaRepository.Delete(name);
        }

    }
}
