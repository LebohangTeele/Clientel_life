using DB_API.Models;
using DB_API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;

namespace DB_API.Controllers
{
    public class CoffeeController : ApiController
    {
        private readonly IRepository<Coffee, int> coffeeRepository;
        public CoffeeController(IRepository<Coffee, int> coffee)
        {
            coffeeRepository = coffee;
        }

        // GET: api/Coffee
        public IEnumerable<Coffee> GetAll()
        {
            var result = coffeeRepository.GetAll();
            if (result == null)
            {
                return null;
            }

            return result;
        }

        // GET: api/Coffee/5
        public IEnumerable<Coffee> Get(int id)
        {
            var result = coffeeRepository.GetbyId(id);
            if (result == null)
            {
                return null;
            }
            return result;
        }

        // POST: api/Coffee
        public bool Post([FromBody] Coffee model)
        {
            var result = coffeeRepository.Insert(model);
            if (result == null)
            {
                return false;
            }
            return true;
        }

        // PUT: api/Coffee/5
        public bool Put([FromBody] Coffee model)
        {
            var result = coffeeRepository.Edit(model);
            if (result == null)
            {
                return false;
            }
            return true;
        }

        // DELETE: api/Coffee/5
        public bool Delete(int id)
        {
            var result = coffeeRepository.Delete(id);
            if (result == false)
            {
                return false;
            }
            return true;
        }
    }
}
