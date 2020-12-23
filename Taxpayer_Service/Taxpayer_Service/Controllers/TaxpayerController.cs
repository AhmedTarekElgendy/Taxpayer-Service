using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Taxpayer.Application.TaxpayerManagement.Queries;
using Taxpayer.Application.TaxpayerManagement.Commands;
using Microsoft.AspNetCore.Cors;

namespace Taxpayer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxpayerController : ControllerBase
    {
        private readonly IMediator mediator;

        public TaxpayerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetAllTapayers()
        {
            var command = new TaxpayerQuery();
            var response = mediator.Send(command);
            return Ok(response.Result);
        }

        [HttpPost]
        public IActionResult CreateTaxpayer(TaxpayerCommand taxpayer)
        {
            var result = mediator.Send(taxpayer);

            return Ok(result.Result);
        }
    }
}
