using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PQS.FSChalenge2.DTOs;
using PQS.FSChalenge2.Models;

namespace PQS.FSChalenge2.Controllers
{
    //[Produces("aplicattion/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersItemsController : ControllerBase
    {
        private readonly PQSFSChalengedbContext _context;
        public OrdersItemsController(PQSFSChalengedbContext context)
        {
            _context = context;
        }

        ////GET: api/OrdersItems
        //[HttpGet]
        //public IEnumerable<OrdersItemsDTO> GetOrdersItems()
        //{
        //    return Mapper.Map<IEnumerable<OrdersItemsDTO>>(_context.OrdersItems);
        //}

        //GET: api/OrdersItems/OrderId/1
        [HttpGet("OrderId/{orderId}")]
        public IEnumerable<OrdersItemsDTO> GetOrdersItems([FromRoute] int orderId)
        {
            return Mapper.Map<IEnumerable<OrdersItemsDTO>>(_context.OrdersItems.Where(o => o.OrderId == orderId));
        }

    }
}
