using MealOrder.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealOrder.Server.Services.Infrastruce
{
    public interface ISupplierService
    {
        public Task<List<SupplierDTO>> GetSuppliers();

        public Task<SupplierDTO> CreateSupplier(SupplierDTO supplier);

        public Task<SupplierDTO> UpdateSupplier(SupplierDTO supplier);

        public Task DeleteSupplier(int SupplierId);

        public Task<SupplierDTO> GetSupplierById(int Id);
    }
}
