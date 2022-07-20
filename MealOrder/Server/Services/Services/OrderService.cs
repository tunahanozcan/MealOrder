using AutoMapper;
using AutoMapper.QueryableExtensions;
using MealOrder.Server.Data.Models;
using MealOrder.Server.Services.Infrastruce;
using MealOrder.Shared.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealOrder.Server.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly MealOrderContext context;
        private readonly IMapper mapper;
        //private readonly IValidationService validationService;

        public OrderService(MealOrderContext Context, IMapper Mapper)
        {
            context = Context;
            mapper = Mapper;
        }

        public async Task<OrderDTO> CreateOrder(OrderDTO Order)
        {
            var dbOrder = mapper.Map<Data.Models.Orders>(Order);
            await context.AddAsync(dbOrder);
            await context.SaveChangesAsync();

            return mapper.Map<OrderDTO>(dbOrder);
        }

        public async Task<OrderItemsDTO> CreateOrderItem(OrderItemsDTO OrderItem)
        {
            var order = await context.Orders
               .Where(i => i.Id == OrderItem.OrderId)
               .Select(i => i.ExpireDate)
               .FirstOrDefaultAsync();

            if (order == null)
                throw new Exception("The main order not found");

            if (order <= DateTime.Now)
                throw new Exception("You cannot create sub order. It is expired !!!");


            var dbOrder = mapper.Map<Data.Models.OrderItems>(OrderItem);
            await context.AddAsync(dbOrder);
            await context.SaveChangesAsync();

            return mapper.Map<OrderItemsDTO>(dbOrder);
        }

        public async Task DeleteOrder(int OrderId)
        {
            var detailCount = await context.OrderItems.Where(i => i.OrderId == OrderId).CountAsync();


            if (detailCount > 0)
                throw new Exception($"There are {detailCount} sub items for the order you are trying to delete");

            var order = await context.Orders.FirstOrDefaultAsync(i => i.Id == OrderId);
            if (order == null)
                throw new Exception("Order not found");


            //if (!validationService.HasPermission(order.CreatedUserId))
            //    throw new Exception("You cannot change the order unless you created");



            context.Orders.Remove(order);

            await context.SaveChangesAsync();
        }

        public async Task DeleteOrderItem(int OrderItemId)
        {
            var orderItem = await context.OrderItems.FirstOrDefaultAsync(i => i.Id == OrderItemId);
            if (orderItem == null)
                throw new Exception("Sub order not found");

            context.OrderItems.Remove(orderItem);

            await context.SaveChangesAsync();
        }

        public async Task<OrderDTO> GetOrderById(int Id)
        {
            return await context.Orders.Where(i => i.Id == Id)
                      .ProjectTo<OrderDTO>(mapper.ConfigurationProvider)
                      .FirstOrDefaultAsync();
        }

        public async Task<List<OrderItemsDTO>> GetOrderItems(int OrderId)
        {
            return await context.OrderItems.Where(i => i.OrderId == OrderId)
                      .ProjectTo<OrderItemsDTO>(mapper.ConfigurationProvider)
                      .OrderBy(i => i.CreateDate)
                      .ToListAsync();
        }

        public async Task<OrderItemsDTO> GetOrderItemsById(int Id)
        {
            return await context.OrderItems.Include(i => i.Order).Where(i => i.Id == Id)
                     .ProjectTo<OrderItemsDTO>(mapper.ConfigurationProvider)
                     .FirstOrDefaultAsync();
        }

        public async Task<List<OrderDTO>> GetOrders(DateTime OrderDate)
        {
            var list = await context.Orders.Include(i => i.Supplier)
                      .Where(i => i.CreateDate.Date == OrderDate.Date)
                      .ProjectTo<OrderDTO>(mapper.ConfigurationProvider)
                      .OrderBy(i => i.CreateDate)
                      .ToListAsync();

            return list;
        }

        //public Task<List<OrderDTO>> GetOrdersByFilter(OrderListFilterModel Filter)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<OrderDTO> UpdateOrder(OrderDTO Order)
        {
            var dbOrder = await context.Orders.FirstOrDefaultAsync(i => i.Id == Order.Id);
            if (dbOrder == null)
                throw new Exception("Order not found");


            //if (!validationService.HasPermission(dbOrder.CreatedUserId))
            //    throw new Exception("You cannot change the order unless you created");

            mapper.Map(Order, dbOrder);
            await context.SaveChangesAsync();

            return mapper.Map<OrderDTO>(dbOrder);
        }

        public async Task<OrderItemsDTO> UpdateOrderItem(OrderItemsDTO OrderItem)
        {
            var dbOrder = await context.OrderItems.FirstOrDefaultAsync(i => i.Id == OrderItem.Id);
            if (dbOrder == null)
                throw new Exception("Order not found");

            mapper.Map(OrderItem, dbOrder);
            await context.SaveChangesAsync();

            return mapper.Map<OrderItemsDTO>(dbOrder);
        }
    }
}
