using FluentValidation;

namespace Taxpayer.Application.TaxpayerManagement.Commands
{
    public class TaxpayerCommandValidator : AbstractValidator<TaxpayerCommand>
    {
        public TaxpayerCommandValidator()
        {
            RuleFor(x => x.FirstName).NotNull().NotEmpty().WithMessage("Please enter a valid First Name");
            RuleFor(x => x.SecondaryName).NotNull().NotEmpty().WithMessage("Please enter a valid Secondary Name");

            RuleFor(x => x.Address).NotNull().NotEmpty().WithMessage("Please enter a valid Address");

            RuleFor(x=>x.Phone).NotNull().NotEmpty().WithMessage("Please enter a valid Phone");

            RuleFor(x=>x.Language).NotNull().NotEmpty().IsInEnum().WithMessage("Please enter a valid Language");

            RuleFor(x => x.Email).NotNull().NotEmpty().EmailAddress().WithMessage("Please enter a valid Email");
        }
    }
}
