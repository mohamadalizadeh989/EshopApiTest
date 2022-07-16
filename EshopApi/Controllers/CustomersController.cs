using EshopApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EshopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly EshopApi_DBContext _context;

        public CustomersController(EshopApi_DBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetCustomer()
        {
            var result = new ObjectResult(_context.Customer)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
            Request.HttpContext.Response.Headers.Add("X-Count",_context.Customer.Count().ToString());
            Request.HttpContext.Response.Headers.Add("X-Name","Mohamad Alizadeh");
            return result;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer([FromRoute] int id)
        {
            if (CustomerExist(id))
            {
                var customer = await _context.Customer.SingleOrDefaultAsync(c => c.CustomerId == id);
                return Ok(customer);
            }
            else
            {
                return NotFound();
            }
        }

        private bool CustomerExist(int id)
        {
            return _context.Customer.Any(c => c.CustomerId == id);
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer([FromRoute] int id, [FromBody] Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
