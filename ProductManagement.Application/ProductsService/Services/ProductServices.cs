using Application.BaseService;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductManagement.Application.ProductsService.DTO;
using ProductManagement.Application.ProductsService.StatusAction;
using ProductManagement.Application.ProductsService.Validation;
using ProductManagement.Common.Errors;
using ProductManagement.Common.Helpers;
using ProductManagement.Common.StatusActions;
using ProductManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProductManagement.Application.ProductsService.Services
{
    public class ProductServices : BaseServices<Product, ProductDTO>, IProductServices
    {
        private readonly ILogger<ProductServices> logger;

        public ProductServices(IServiceProvider serviceProvider, ILogger<ProductServices> logger) : base(serviceProvider)
        {
            this.logger = logger;
        }

        public async Task<StatusActionBase> AddProduct(ProductDTO productDTO)
        {
            logger.LogInformation("AddProduct");
            var validator = new ProductValidation();
            ValidationResult results = validator.Validate(productDTO);
           
            if (results.IsValid)
            {
                using (var uow = NewDbContext())
                {
                    var repo = uow.Repository<Product>();

                    var entity = base._mapper.Map<ProductDTO, Product>(productDTO);

                    var db = uow.GetDbContext();
                    
                    entity.ProductDetail = new ProductDetail();

                    if (productDTO.ProductDetail != null)
                        entity.ProductDetail.Details = productDTO.ProductDetail.Details;
                    

                    entity = await repo.InsertAsync(entity);

                    await uow.SaveChangeAsync();

                    db.Entry(entity).Collection(t => t.ProductCategories).Query().Include(y => y.Category).Load();
                    db.Entry(entity).Reference(t => t.Supplier).Load();

                    return new CreateDataStatus<ProductView>(base._mapper.Map<Product, ProductView>(entity)); ;
                }

            }
            else
                throw new InvalidParameters(results.ToString());
        }

        public async Task<StatusActionBase> DeleteProduct(int key)
        {
            logger.LogInformation("DeleteProduct");
            await DeleteAsync(key);
            return new DeleteDataStatus();
        }



        public async Task<StatusActionBase> GetAllProduct()
        {
            logger.LogInformation("GetAllProduct");
            using (var uow = NewDbContext())
            {
                var repo = uow.Repository<Product>();
                var ds = await repo.GetAllAsync();
                var result = base._mapper.Map<IEnumerable<Product>, IEnumerable<ProductView>>(ds);
                return new GetDataStatus<IEnumerable<ProductView>>(result);
            }

        }

        public async Task<StatusActionBase> GetProductById(int id)
        {
            logger.LogInformation("GetProductById");
            using (var uow = NewDbContext())
            {
                var repo = uow.Repository<Product>();
                var ds = await repo.GetByIdAsync(id);
                if (ds == null)
                    throw new NotFoundError();

                var result = base._mapper.Map<Product, ProductView>(ds);
                return new GetDataStatus<ProductView>(result);
            }
        }
        public async Task<StatusActionBase> UpdatePrice(double? price, int id)
        {
            logger.LogInformation("UpdatePrice");
            if (price == null)
                throw new InvalidParameters("Vui lòng điền giá !!!!!!");
            using (var uow = NewDbContext())
            {
                var repo = uow.GetProductRepository();
                await repo.UpdatePrice((double)price, id);

                var resultSaveChange = await uow.SaveChangeAsync();

                if (resultSaveChange == false)
                    throw new SaveChangeError();
                return new UpdateDataStatus();
            }

        }
        public async Task<StatusActionBase> EditProductData(ProductDataUpdate productUpdated)
        {
            logger.LogInformation("EditProductData");
            using (var unitOfWork = NewDbContext())
            {

                var repoSupplier = unitOfWork.Repository<Supplier>();
                var repoPC = unitOfWork.Repository<ProductCategory>();
                var repo = unitOfWork.Repository<Product>();


                var product = await repo.GetByIdAsync(productUpdated.ID);

                if (product == null)
                    throw new InvalidParameters("Mã sản phẩm không tồn tại");

                product = _mapper.Map(productUpdated, product);

                if (productUpdated.Detail != null)
                {
                    product.ProductDetail.Details = productUpdated.Detail;
                }



                // Update relationship
                // if product category is not in productUpdated.CategoryIds then remove that one
                if (productUpdated.CategoryIds != null && productUpdated.CategoryIds.Count > 0)
                {
                    foreach (var pc in product.ProductCategories)
                    {

                        if (!productUpdated.CategoryIds.Any(x => x == pc.CategoryID))
                        {
                            product.ProductCategories.Remove(pc);
                        }
                    }

                    // if product category Id in productUpdated.CategoryIds not in product.ProductCategories then remove that one
                    foreach (var ci in productUpdated.CategoryIds)
                    {
                        if (!product.ProductCategories.Any(x => x.CategoryID == ci))
                        {
                            product.ProductCategories.Add(new ProductCategory { ProductID = product.ID, CategoryID = ci });
                        }
                    }
                }


                product = repo.Update(product);

                var resultSaveChange = await unitOfWork.SaveChangeAsync();

                if (resultSaveChange == false)
                    throw new SaveChangeError();

                var db = unitOfWork.GetDbContext();
                db.Entry(product).Collection(t => t.ProductCategories).Query().Include(y => y.Category).Load();
                db.Entry(product).Reference(t => t.Supplier).Load();

                unitOfWork.CommitTransaction();

                return new UpdateProductStatus<ProductView>(base._mapper.Map<ProductView>(product));
            }
        }

        public async Task<StatusActionBase> GetByQuery(string name, List<int> categories, double? priceFrom, double? priceTo, int? page, int? size)
        {
            logger.LogInformation("GetByQuery");
            var defaultPage = 1;
            var defaultSize = 10;
            if (page != null)
            {
                if (page <= 0)
                    throw new InvalidParameters("Số trang phải lớn hơn hoặc bằng 1");
                defaultPage = (int)page;
            }
            if (size != null)
            {
                if (size <= 0)
                    throw new InvalidParameters("Số lượng cần lấy phải lớn hơn hoặc bằng 1");
                defaultSize = (int)size;
            }

            if (priceFrom < 0)
                throw new InvalidParameters("Gía sản phẩm phải lớn hơn 0");

            if (priceTo < 0)
                throw new InvalidParameters("Gía sản phẩm phải lớn hơn 0");

            if (priceFrom > priceTo)
                throw new InvalidParameters("Giá từ phải nhỏ hơn giá đến");

            using (var uow = NewDbContext())
            {
                var repo = uow.Repository<Product>();

                var query = repo.GetByQuery();

                if (name.CheckExists())
                    query = query.Where(x => x.Name.Contains(name));

                if (priceFrom != null)
                    query = query.Where(x => x.Price >= (double)priceFrom);

                if (priceTo != null)
                    query = query.Where(x => x.Price <= (double)priceTo);

                if (categories != null && categories.Count > 0)
                    query = query.Where(x => x.ProductCategories != null && x.ProductCategories.Any(z => categories.Contains(z.CategoryID)));

                query = query.Skip((defaultPage - 1) * defaultSize).Take(defaultSize);

                query = query.Include("ProductCategories").Include("Supplier").Include("ProductDetail").Include("ProductCategories.Category");

                var ds = base._mapper.Map<IEnumerable<Product>, IEnumerable<ProductView>>(await query.ToListAsync());

                return new GetDataStatus<IEnumerable<ProductView>>(ds);
            }
        }
    }
}
