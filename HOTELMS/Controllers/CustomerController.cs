using HOTELMS.Context;
using HOTELMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HOTELMS.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly HOTELMSDbContext _dbcontext;
        

        public CustomerController(HOTELMSDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }



        [HttpPost]

        public IActionResult Create(Customer customer)
        {

            _dbcontext.Customers.Add(customer);
            _dbcontext.SaveChanges();
            return Ok();

        }

        [HttpGet]
        public IActionResult GetAll()
        {

            var customers = _dbcontext.Customers.ToList();
            return Ok(customers);

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer=_dbcontext.Customers.Find(id);
            return Ok(customer);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var customer = _dbcontext.Customers.Find(id);
            if (customer != null) {
            
            _dbcontext.Remove(customer);

                _dbcontext.SaveChanges();
               
            }
            return Ok();

        }
    }
}
    











