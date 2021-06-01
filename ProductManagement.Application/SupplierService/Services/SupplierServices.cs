using Application.BaseService;
using ProductManagement.Application.SupplierService.DTO;
using ProductManagement.Common.StatusActions;
using ProductManagement.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductManagement.Application.SupplierService.Services
{
   
        public class SupplierServices : BaseServices<Supplier, SupplierDTO>, ISupplierServices
        {
            public SupplierServices(IServiceProvider serviceProvider) : base(serviceProvider)
            {
                //this._logger = logger;
            }

            public async Task<StatusActionBase> AddSupplier(SupplierDTO supplierDTO)
            {

                try
                {

                    var result = await CreateEntityAsync(supplierDTO);

                    return new CreateDataStatus<SupplierDTO>(result);
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            public async Task<StatusActionBase> DeleteSupplier(int key)
            {
                try
                {
                    //call delete form baseService
                    var result = await DeleteAsync(key);
                    //return status
                    return new DeleteDataStatus();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }

            public async Task<StatusActionBase> EditSupplier(SupplierDTO supplierDTO, int key)
            {
                try
                {

                    await UpdateEntityAsync(supplierDTO, key);
                    return new ActionStatus();
                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }
            }

            public async Task<StatusActionBase> GetAllSupplier()
            {
                try
                {
                    var result = await GetAllEntityAsync();
                    return new GetDataStatus<IEnumerable<SupplierDTO>>(result);
                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }
            }

            public async Task<StatusActionBase> GetSupplierById(int key)
            {
                try
                {
                    var result = await GetById(key);
                    return new GetDataStatus<SupplierDTO>(result);
                }
                catch (Exception e)
                {

                    throw new Exception(e.Message);
                }
            }
        }
    }

