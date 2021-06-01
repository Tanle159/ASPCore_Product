using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.Application.SupplierService.DTO;
using ProductManagement.Application.SupplierService.Services;
using ProductManagement.Common.StatusActions;

using System.Threading.Tasks;

namespace ProductManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierServices supplierServices;
        public SupplierController(ISupplierServices supplierServices)
        {
            this.supplierServices = supplierServices;
        }

        [HttpGet("getallsup")]
        [AllowAnonymous]
        public async Task<StatusActionBase> UserGetAll()
           => await this.supplierServices.GetAllSupplier();

        [HttpGet("getsup/{id}")]
        [AllowAnonymous]
        public async Task<StatusActionBase> UserGetId(int key)
           => await this.supplierServices.GetSupplierById(key);

        [HttpPost("AddSup")]
        [AllowAnonymous]
        public async Task<StatusActionBase> AddSupplier(SupplierDTO supplierDTO)
            => await this.supplierServices.AddSupplier(supplierDTO);

        [HttpDelete("{id}")]
        [AllowAnonymous]
        public async Task<StatusActionBase> DeleteSupplier(int id)
            => await this.supplierServices.DeleteSupplier(id);


        [HttpPut("UpdateSup")]
        public async Task<StatusActionBase> UpdateSupplier([FromBody] SupplierDTO supplierDTO)
        {
            return await this.supplierServices.EditSupplier(supplierDTO, supplierDTO.ID);

        }
    }
}
