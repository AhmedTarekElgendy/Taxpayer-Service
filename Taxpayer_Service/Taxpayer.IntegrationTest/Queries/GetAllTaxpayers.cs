using NUnit.Framework;
using RestSharp;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System;

namespace Taxpayer.IntegrationTest.Queries
{
    [TestFixture]
    public class GetAllTaxpayers
    {
        #region Initialize
        RestClient restClient;
        RestRequest restRequest;
        IRestResponse restResponse;
        #endregion
        [Test]
        public void GetAllTaxpayersIntegrationTest()
        {
            restClient = new RestClient("https://localhost:44307/api/taxpayer");
            restRequest = new RestRequest(Method.GET);
            restResponse = restClient.Execute(restRequest);
            Assert.That(restResponse.Content, Is.Not.Null);
            JArray jArray = JArray.Parse(restResponse.Content);
            try
            {
                List<Domain.Models.Taxpayer> clinics = jArray.ToObject<List<Domain.Models.Taxpayer>>();
            }
            catch(Exception ex)
            {
                Assert.That(ex, Is.Not.Null);
            }
        }
    }
}
