using HOTELMS.Context;
using HOTELMS.DTOS;
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

        public IActionResult Create(CustomerDto customerDto)
        {

            var customer = new Customer();
            customer.Id = customerDto.Id;
            customer.Surname = customerDto.Surname;
            customer.Name = customerDto.Name;
            customer.Salary = customerDto.Salary;
            customer.Email = customerDto.Email;
            customer.Address = customerDto.Address;

            _dbcontext.Customers.Add(customer);
            _dbcontext.SaveChanges();
            return Ok();

        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var dtos = new List<Customer>();
   

            var customers = _dbcontext.Customers.ToList();
            foreach (var customer in customers) 
            {
                var customerDto = new CustomerDto();
                customerDto.Id = customer.Id;
                customerDto.Surname=customer.Surname;
                customerDto.Name = customer.Name;
                customerDto.Salary = customer.Salary;
                customerDto.Email = customer.Email;
                dtos.Add(customer);
            }
            return Ok(dtos);

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {


            var customer=_dbcontext.Customers.Find(id);
            var customerDto = new CustomerDto();
            customerDto.Id = customer.Id;
            customerDto.Surname = customer.Surname;
            customerDto.Name = customer.Name;
            customerDto.Salary = customer.Salary;
            customerDto.Email = customer.Email;
            return Ok(customerDto);
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
    











