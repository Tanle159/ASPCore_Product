using AutoMapper;
using ProductManagement.Application.AuthService.DTO;
using ProductManagement.Application.CategoryService.DTO;
using ProductManagement.Application.ProductCategoryService.DTO;
using ProductManagement.Application.ProductDetailService.DTO;
using ProductManagement.Application.ProductsService.DTO;
using ProductManagement.Application.SupplierService.DTO;
using ProductManagement.Domain;
using System.Linq;

namespace ProductManagement.Application.Mapper
{
    public class MappingProduct : Profile
    {
        public MappingProduct()
        {
            // Mỗi DTO phải map với Entity tương xứng và ngược lại
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();

            CreateMap<ProductDetailDTO, ProductDetail>();
            CreateMap<ProductDetail, ProductDetailDTO>();

            CreateMap<ProductCategoryDTO, ProductCategory>();
            CreateMap<ProductCategory, ProductCategoryDTO>();

            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();

            CreateMap<SupplierDTO, Supplier>();
            CreateMap<Supplier, SupplierDTO>();

            CreateMap<ProductDataUpdate, Product>()
                .ForMember(pdu=>pdu.SupplierID, opt=>opt.MapFrom( (src, dist) => src.SupplierID == null ? dist.SupplierID : src.SupplierID));
            CreateMap<Product, ProductDataUpdate>();

            CreateMap<ProductDataUpdate, ProductDTO>();

            CreateMap<Product, ProductView>()
                .ForMember(pv => pv.categories, opt => opt.MapFrom(src => src.ProductCategories!=null ? src.ProductCategories.Select(t => new CategoryDTO { ID = t.CategoryID, Name = t.Category.Name }):null));

            CreateMap<UserSignUpResource, User>()
    .ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.Email));
        }
    }
}