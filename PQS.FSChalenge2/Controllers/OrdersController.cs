using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PQS.FSChalenge2.Models;
using PQS.FSChalenge2.DTOs;
using AutoMapper;
using System.Net.PeerToPeer.Collaboration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PQS.FSChalenge2.Controllers
{
    //[Produces("aplicattion/json")]marce
    [Route("api/Orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly PQSFSChalengedbContext _context;
        public OrdersController(PQSFSChalengedbContext context)
        {
            _context = context;
        }
        
        //GET: api/orders/status/{status}
        [HttpGet("status/{status}")]
        public IEnumerable<OrdersDTO> GetOrdersStatus([FromRoute] int status)
        {
            var orders = Mapper.Map<IEnumerable<OrdersDTO>>(_context.Orders.Where(o => o.Status == status).ToList());
            return orders;
        }

        //POST: api/orders/
        [HttpPost("{orderId}")]
        public async Task<ActionResult> PostOrders([FromRoute] int orderId)
        {
            //var order = Mapper.Map<IEnumerable<OrdersDTO>>(_context.Orders.Where(o => o.OrderId== orderId));
            var order = Mapper.Map<IEnumerable<OrdersDTO>>(_context.Orders.Where(o => o.OrderId == orderId)).ToList();
                order[0].Status = 1;

            if (order != null)
            {
                _context.Entry(Mapper.Map<Orders>(order)).State = EntityState.Modified;
            }
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(orderId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return NoContent();
        }


        //GET: api/orders/1
        [HttpGet("{orderId}")]
        public async Task<ActionResult> GetOrders([FromRoute] int orderId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var order = await _context.Orders.SingleOrDefaultAsync(o => o.OrderId == orderId);

            if (order == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<OrdersDTO>(order));
        }

        //PUT: api/orders/1
        [HttpPut("{orderId}")]
        public async Task<ActionResult> PutOrders([FromRoute] int orderId, [FromBody] OrdersDTO order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(Mapper.Map<Orders>(order)).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(orderId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return NoContent();
        }

        //DELETE: api/orders/1
        //[HttpDelete]
        [HttpDelete("{orderId}")]
        public async Task<ActionResult> DeleteOrders([FromRoute] int orderId)
        {
            //var order = Mapper.Map<IEnumerable<OrdersDTO>>(_context.Orders.Where(o => o.OrderId== orderId));
            var order = Mapper.Map<IEnumerable<OrdersDTO>>(_context.Orders.Where(o => o.OrderId == orderId)).ToList();
            order[0].Status = -1;

            if (order != null)
            {
                _context.Entry(Mapper.Map<Orders>(order)).State = EntityState.Modified;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(orderId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return NoContent();

        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(o => o.OrderId == id);
        }
    }
}
