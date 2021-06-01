using FluentValidation;
using ProductManagement.Application.SupplierService.DTO;

namespace ProductManagement.Application.SupplierService.Validation
{
    public class SupplierValidation : AbstractValidator<SupplierDTO>
    {
        public SupplierValidation()
        {
            RuleFor(x => x.Name)
                    .NotEmpty().WithMessage("Tên Nhà Cung Cấp không được để trống")
                    .NotNull().WithMessage("Tên Nhà Cung Cấp không được để Null");
            RuleFor(x => x.Address)
                   .NotEmpty().WithMessage("Địa chỉ không được để trống")
                   .NotNull().WithMessage("Địa chỉ không được để Null");
        }
    }
}