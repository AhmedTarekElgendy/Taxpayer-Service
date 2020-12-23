using FluentValidation;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Taxpayer.Application.Common;
using AutoMapper;

namespace Taxpayer.Application.TaxpayerManagement.Commands
{
    public class TaxpayerCommandHandler : IRequestHandler<TaxpayerCommand, Taxpayer.Domain.Models.Taxpayer>
    {
        private readonly Taxpayer_DBContext dBContext;
        private readonly IMapper mapper;

        public TaxpayerCommandHandler(Taxpayer_DBContext dBContext, IMapper mapper)
        {
            this.dBContext = dBContext;
            this.mapper = mapper;
        }
        public Task<Domain.Models.Taxpayer> Handle(TaxpayerCommand request, CancellationToken cancellationToken)
        {
            var exitingtax = dBContext.Taxpayer.Where(x => x.Email == request.Email).SingleOrDefault();

            if (exitingtax != null)
            {
                var ex = new ValidationException("Taxpayer already existed");
                throw ex;
            }
            var newtax = mapper.Map<Taxpayer.Domain.Models.Taxpayer>(request);
            dBContext.Taxpayer.Add(newtax);
            dBContext.SaveChanges();
            return Task.FromResult(newtax);
        }
    }
}
