using MediatR;
using System.Collections.Generic;

namespace Taxpayer.Application.TaxpayerManagement.Queries
{
    public class TaxpayerQuery : IRequest<List<Taxpayer.Domain.Models.Taxpayer>>
    {
    }
}
