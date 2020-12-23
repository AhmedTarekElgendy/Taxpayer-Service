using NUnit.Framework;
using RestSharp;
using Newtonsoft.Json.Linq;
using System;
using Taxpayer.Application.TaxpayerManagement.Commands;
using Newtonsoft.Json;

namespace Taxpayer.IntegrationTest.Commands
{
    [TestFixture]
    public class CreateTaxpayerCommand
    {
        #region Initialize
        RestClient restClient;
        RestRequest restRequest;
        IRestResponse restResponse;
        Random random ;
        #endregion

        [Test]
        public void CreateValidTaxpayerIntegrationTest()
        {
            restClient = new RestClient("https://localhost:44307/api/taxpayer");

            restRequest = new RestRequest(Method.POST);

             random = new Random();
            var command = new TaxpayerCommand()
            {
                FirstName = "No"+random.Next(1,9),
                SecondaryName = "Esmat",
                Phone = "+201111789766",
                Address = "Elda2ery",
                Email = random.Next(1, 9)+"ne@yahoo.com",
                Language = Domain.Enums.LanguageTypes.English
            };

            restRequest.AddJsonBody(command);

            restResponse = restClient.Execute(restRequest);

            Assert.That(restResponse.Content, Is.Not.Null);
            JObject jObject = JObject.Parse(restResponse.Content);
            try
            {
                Domain.Models.Taxpayer taxpayer = jObject.ToObject<Domain.Models.Taxpayer>();
            }
            catch (Exception ex)
            {
                Assert.That(ex, Is.Not.Null);
            }
        }

        [Test]
        public void CreateInvalidTaxpayerwithnullFirstNameIntegrationTest()
        {
            restClient = new RestClient("https://localhost:44307/api/taxpayer");

            restRequest = new RestRequest(Method.POST);

            random = new Random();
            var command = new TaxpayerCommand()
            {
                FirstName = null,
                SecondaryName = "Esmat",
                Phone = "+201111789766",
                Address = "Elda2ery",
                Email = random.Next(1, 9) + "ne@yahoo.com",
                Language = Domain.Enums.LanguageTypes.English
            };

            restRequest = new RestRequest(Method.POST);

            restRequest.AddJsonBody(command);

            restResponse = restClient.Execute(restRequest);
            Assert.That(restResponse.Content, Is.Not.Null);
            Assert.IsNotNull(restResponse.Content.Contains("Secondary Name"));
        }

        [Test]
        public void CreateInvalidTaxpayerwithnullSecondaryNameIntegrationTest()
        {
            restClient = new RestClient("https://localhost:44307/api/taxpayer");

            restRequest = new RestRequest(Method.POST);

            random = new Random();

            var command = new TaxpayerCommand()
            {
                FirstName = "Ali"+ random.Next(1, 9),
                SecondaryName = null,
                Phone = "+201111789766",
                Address = "Elda2ery",
                Email = random.Next(1, 9) + "ne@yahoo.com",
                Language = Domain.Enums.LanguageTypes.English
            };

            restRequest = new RestRequest(Method.POST);

            restRequest.AddJsonBody(command);

            restResponse = restClient.Execute(restRequest);
            Assert.That(restResponse.Content, Is.Not.Null);
            Assert.IsNotNull(restResponse.Content.Contains("Secondary Name"));
        }

        //rest of TCs wil be the same
    }
}
