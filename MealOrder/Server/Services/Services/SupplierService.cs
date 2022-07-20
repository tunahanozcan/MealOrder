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
    public class SupplierService : ISupplierService
    {
        private readonly MealOrderContext context;
        private readonly IMapper mapper;

        public SupplierService(MealOrderContext Context, IMapper Mapper)
        {
            context = Context;
            mapper = Mapper;
        }
        public async Task<SupplierDTO> CreateSupplier(SupplierDTO supplier)
        {
            var dbSupplier = mapper.Map<Suppliers>(supplier);
            await context.AddAsync(dbSupplier);
            await context.SaveChangesAsync();

            return mapper.Map<SupplierDTO>(dbSupplier);
        }

        public async Task DeleteSupplier(int SupplierId)
        {
            var Supplier = await context.Suppliers.FirstOrDefaultAsync(i => i.Id == SupplierId);
            if (Supplier == null)
                throw new Exception("Supplier not found");

            int orderCount = await context.Suppliers.Include(i => i.Orders).Select(i => i.Orders.Count).FirstOrDefaultAsync();

            if (orderCount > 0)
                throw new Exception($"There are {orderCount} sub order for the order you are trying to delete");

            context.Suppliers.Remove(Supplier);
            await context.SaveChangesAsync();
        }

        public async Task<SupplierDTO> GetSupplierById(int Id)
        {
            return await context.Suppliers.Where(i => i.Id == Id)
                      .ProjectTo<SupplierDTO>(mapper.ConfigurationProvider)
                      .FirstOrDefaultAsync();
        }

        public async Task<List<SupplierDTO>> GetSuppliers()
        {
            var list = await context.Suppliers//.Where(i => i.IsActive)
                     .ProjectTo<SupplierDTO>(mapper.ConfigurationProvider)
                     .OrderBy(i => i.CreateDate)
                     .ToListAsync();

            return list;
        }

        public async Task<SupplierDTO> UpdateSupplier(SupplierDTO supplier)
        {
            var dbSupplier = await context.Suppliers.FirstOrDefaultAsync(i => i.Id == supplier.Id);
            if (dbSupplier == null)
                throw new Exception("Supplier not found");

            mapper.Map(supplier, dbSupplier);
            await context.SaveChangesAsync();

            return mapper.Map<SupplierDTO>(dbSupplier);
        }
    }
}
