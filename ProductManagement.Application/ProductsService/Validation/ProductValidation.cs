using FluentValidation;
using ProductManagement.Application.ProductsService.DTO;
using System.Text.RegularExpressions;

namespace ProductManagement.Application.ProductsService.Validation
{
    public class ProductValidation : AbstractValidator<ProductDTO>
    {
        public ProductValidation()
        {
            RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Tên Sản Phẩm không được để trống")
                    .NotNull().WithMessage("Tên Sản Phẩm không được để Null");
            RuleFor(x => x.Description)
                .NotNull().WithMessage("Mô tả không được để null");
            RuleFor(x => x.Rating)
                .NotNull().WithMessage("Rating không được để null");
            RuleFor(x => x.Price)
                .NotNull().WithMessage("Price không được để null")
                .NotEmpty().WithMessage("Price không được để trống");
                //.Must(NumberRegex).WithMessage("Price là số không phải là ký tự");
               //.Must(p=>p.GetType()!=typeof(double)).WithMessage("Price là số không phải là ký tự");
        }

        private static bool NumberRegex(double price)
        {
            var type =price.GetType();
            if (type == typeof(string))
                return false;
            var validNumber = new Regex(@" -? d * (?:\d *\.\d *) ? $");
            if (validNumber.IsMatch(price.ToString()))
                return true;
            return false;
        }
  
    }
}