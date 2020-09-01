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
                //cfg.CreateMap<Orders, OrdersDTO>().ReverseMap();
                cfg.CreateMap<Orders, OrdersDTO>().ReverseMap();
                //.ForMember(x => x.Parts, opt => opt.Ignore());
                cfg.CreateMap<OrdersItems, OrdersItemsDTO>().ReverseMap();
                cfg.ValidateInlineMaps = false;
            });
        }

    
        private void AddOrUpdateOrdersItems(OrdersDTO dto, Orders country)
        {
            foreach (var oItems in dto.OrdersItems)
            {
                if (oItems.OrderId == 0)
                {
                    country.OrdersItems.Add(Mapper.Map<OrdersItems>(oItems));
                }
                else
                {
                    Mapper.Map(oItems, country.OrdersItems.SingleOrDefault(c => c.OrderId == oItems.OrderId));
                }
            }
        }
    }
}
