using NUnit.Framework;
using Taxpayer.Application.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Taxpayer.Application.TaxpayerManagement.Commands;
using AutoMapper;
using Taxpayer_Service;
using Mcs.Invoices.Services.Testing.Rest;

namespace Taxpayer.UnitTest.Commands
{
    [TestFixture]
    public class CreateTaxpayer 
    {
        #region Initialize
        Taxpayer_DBContext DBContext;
        int i = 0;
        IMapper mapper;
        #endregion

        public CreateTaxpayer()
        {
            DbContextOptions<Taxpayer_DBContext> options = new DbContextOptions<Taxpayer_DBContext>();

            DBContext = new Taxpayer_DBContext(options);
        }

        [Test]
        public void CreateValidTaxpayer()
        {
            var command = new TaxpayerCommand()
            {
                FirstName = "Sayed",
                SecondaryName = "Ali",
                Address = "Haram",
                Language = Domain.Enums.LanguageTypes.English,
                Email = "sayed@yahoo.com",
                Phone = "+201111789766"
            };
            var Handler = new TaxpayerCommandHandler(DBContext,mapper);
            var response = Handler.Handle(command, CancellationToken.None);

            Assert.That(response.Result, Is.Not.Null);

        }
        [Test]
        public void CreateInValidTaxpayerwithnullFirstName()
        {
            var command = new TaxpayerCommand()
            {
                FirstName = null,
                SecondaryName = "Ali",
                Address = "Haram",
                Language = Domain.Enums.LanguageTypes.English,
                Email = "sayed@yahoo.com",
                Phone = "+201111789766"
            };
            var Handler = new TaxpayerCommandHandler(DBContext, mapper);
            var response = Handler.Handle(command, CancellationToken.None);

            StringAssert.Contains(response.Exception.InnerException.ToString(), "Validation");

        }

        [Test]
        public void CreateInValidTaxpayerwithnullSecondaryName()
        {
            var command = new TaxpayerCommand()
            {
                FirstName = "Sayed",
                SecondaryName = null,
                Address = "Haram",
                Language = Domain.Enums.LanguageTypes.English,
                Email = "sayed@yahoo.com",
                Phone = "+201111789766"
            };
            var Handler = new TaxpayerCommandHandler(DBContext, mapper);
            var response = Handler.Handle(command, CancellationToken.None);

            StringAssert.Contains(response.Exception.InnerException.ToString(), "Validation");

        }

        [Test]
        public void CreateInValidTaxpayerwithnullAddress()
        {
            var command = new TaxpayerCommand()
            {
                FirstName = "Sayed",
                SecondaryName = "Ali",
                Address = null,
                Language = Domain.Enums.LanguageTypes.English,
                Email = "sayed@yahoo.com",
                Phone = "+201111789766"
            };
            var Handler = new TaxpayerCommandHandler(DBContext, mapper);
            var response = Handler.Handle(command, CancellationToken.None);

            StringAssert.Contains(response.Exception.InnerException.ToString(), "Validation");

        }
    }
}
