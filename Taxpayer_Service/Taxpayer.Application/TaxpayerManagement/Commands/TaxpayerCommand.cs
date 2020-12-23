using MediatR;
using Taxpayer.Domain.Enums;

namespace Taxpayer.Application.TaxpayerManagement.Commands
{
   public class TaxpayerCommand :IRequest<Taxpayer.Domain.Models.Taxpayer>
    {
        public int ID { get; set; }


        public string FirstName { get; set; }


        public string SecondaryName { get; set; }


        public string Phone { get; set; }


        public string Address { get; set; }


        public string Email { get; set; }

        public LanguageTypes Language { get; set; }
    }
}
