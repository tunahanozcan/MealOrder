using MealOrder.Server.Services.Infrastruce;
using MealOrder.Shared.DTO;
using MealOrder.Shared.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MealOrder.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService supplierService;

        public SupplierController(ISupplierService SupplierService)
        {
            supplierService = SupplierService;
        }



        [HttpGet("SupplierById/{Id}")]
        public async Task<ServiceResponse<SupplierDTO>> GetSupplierById(int Id)
        {
            return new ServiceResponse<SupplierDTO>()
            {
                Value = await supplierService.GetSupplierById(Id)
            };
        }


        [HttpGet("Suppliers")]
        public async Task<ServiceResponse<List<SupplierDTO>>> GetSuppliers()
        {
            return new ServiceResponse<List<SupplierDTO>>()
            {
                Value = await supplierService.GetSuppliers()
            };
        }


        [HttpPost("CreateSupplier")]
        public async Task<ServiceResponse<SupplierDTO>> CreateSupplier(SupplierDTO Supplier)
        {
            return new ServiceResponse<SupplierDTO>()
            {
                Value = await supplierService.CreateSupplier(Supplier)
            };
        }


        [HttpPost("UpdateSupplier")]
        public async Task<ServiceResponse<SupplierDTO>> UpdateSupplier(SupplierDTO Supplier)
        {
            return new ServiceResponse<SupplierDTO>()
            {
                Value = await supplierService.UpdateSupplier(Supplier)
            };
        }


        [HttpPost("DeleteSupplier")]
        public async Task<BaseResponse> DeleteSupplier([FromBody] int SupplierId)
        {
            await supplierService.DeleteSupplier(SupplierId);
            return new BaseResponse();
        }
    }
}
