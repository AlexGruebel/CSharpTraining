using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using NorthwindService.Repositories;
using System.Threading.Tasks;
using NorthwindEntitiesLib;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace NorthwindService.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    { 
        private ICustomerRepository _rCustomer;
        public CustomersController(ICustomerRepository rCustomer){
            this._rCustomer = rCustomer;
        }


        //api/Customer/GetCustomerAsync
        [HttpGet("{id}", Name = "GetCustomer")]
        public async Task<IActionResult> GetCustomerAsync(string id)
        {
            Customer c = await this._rCustomer.GetCustomerAsync(id);
            if(c == null){
                return NotFound();
            }else{
                return new ObjectResult(c);
            }
        }

        [HttpGet]
        public async Task<IEnumerable<Customer>> GetCustomers(string country)
        {
            if(!string.IsNullOrWhiteSpace(country))
            {
                return (await this._rCustomer.RetrieveAllAsync()).Where(c => c.Country == country);
            }else
            {
                return await this._rCustomer.RetrieveAllAsync();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Customer c){
            if (c == null)
            {
                return BadRequest();
            }

            Customer added = await _rCustomer.CreateAsync(c);


            return CreatedAtRoute("GetCustomer", added.CustomerID.ToLower(), c);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Customer c)
        {
            id = id.ToUpper();
            c.CustomerID = c.CustomerID.ToUpper();
            if(c == null && c.CustomerID != id)
            {
                return BadRequest();
            }

            Customer exesting = await _rCustomer.GetCustomerAsync(id);
            if(exesting == null)
            {
                return NotFound();
            }

            await _rCustomer.UpdateAsync(id,c);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if(!(await _rCustomer.CheckIfUserExist(id))){
                return BadRequest();
            }

            var result = await _rCustomer.DeleteAsync(id);

            if(result){
                return new NoContentResult();
            }else{
                return BadRequest();
            }
        }   


    }
}