using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Taxpayer.Application.Common;

namespace Taxpayer.Application.TaxpayerManagement.Queries
{
    public class TaxpayerQueryHandler : IRequestHandler<TaxpayerQuery, List<Taxpayer.Domain.Models.Taxpayer>>
    {
        private readonly Taxpayer_DBContext dBContext;

        public TaxpayerQueryHandler(Taxpayer_DBContext _DBContext)
        {
            dBContext = _DBContext;
        }
        public Task<List<Domain.Models.Taxpayer>> Handle(TaxpayerQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(dBContext.Taxpayer.ToList());
        }
    }
}
