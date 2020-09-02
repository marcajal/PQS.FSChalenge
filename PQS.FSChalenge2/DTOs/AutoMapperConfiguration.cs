using AutoMapper;
using PQS.FSChalenge2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PQS.FSChalenge2.DTOs
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                //cfg.CreateMap<Orders, OrdersDTO>().ForMember(o => o.OrderId, x => x.Ignore());
                cfg.CreateMap<Orders, OrdersDTO>().ReverseMap();
                cfg.CreateMap<OrdersItems, OrdersItemsDTO>().ReverseMap();
                cfg.ValidateInlineMaps = false;
            });
        }
    }
}
