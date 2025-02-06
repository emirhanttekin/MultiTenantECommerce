using FluentValidation;
using MultiTenantECommerce.Application.DTOs;

namespace MultiTenantECommerce.Application.Validations
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ürün adı zorunludur.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Fiyat 0'dan büyük olmalıdır.");
            RuleFor(x => x.Stock).GreaterThanOrEqualTo(0).WithMessage("Stok 0'dan küçük olamaz.");
        }
    }
}
