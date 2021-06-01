using FluentValidation;
using ProductManagement.Application.ProductDetailService.DTO;


namespace ProductManagement.Application.ProductDetailService.Validation
{
    public class ProductDetailValidation : AbstractValidator<ProductDetailDTO>
    {
        public ProductDetailValidation()
        {
            RuleFor(x => x.Details)
                    .NotEmpty().WithMessage("Tên Sản Phẩm không được để trống")
                    .NotNull().WithMessage("Tên Sản Phẩm không được để Null");
        }
    }
}