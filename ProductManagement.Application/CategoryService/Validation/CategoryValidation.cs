using FluentValidation;
using ProductManagement.Application.CategoryService.DTO;
using ProductManagement.Application.ProductsService.DTO;

namespace ProductManagement.Application.CategoryService.Validation
{
    public class CategoryValidation : AbstractValidator<CategoryDTO>
    {
        public CategoryValidation()
        {
            RuleFor(x => x.Name)
                   .NotEmpty().WithMessage("Tên Sản Phẩm không được để trống")
                   .NotNull().WithMessage("Tên Sản Phẩm không được để Null");
        }
    }
}