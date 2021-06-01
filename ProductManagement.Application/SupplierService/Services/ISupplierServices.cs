using ProductManagement.Application.SupplierService.DTO;
using ProductManagement.Common.StatusActions;
using System.Threading.Tasks;

namespace ProductManagement.Application.SupplierService.Services
{
  
        public interface ISupplierServices
        {
        Task<StatusActionBase> AddSupplier(SupplierDTO supplierDTO);
        Task<StatusActionBase> DeleteSupplier(int key);
        Task<StatusActionBase> EditSupplier(SupplierDTO supplierDTO, int key);
         Task<StatusActionBase> GetAllSupplier();
        Task<StatusActionBase> GetSupplierById(int key);


        }
    
}
