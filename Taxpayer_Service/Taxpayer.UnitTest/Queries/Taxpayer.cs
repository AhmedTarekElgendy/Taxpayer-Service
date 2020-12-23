using NUnit.Framework;
using Taxpayer.Application.TaxpayerManagement.Queries;
using Taxpayer.Application.Common;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Taxpayer.UnitTest.Queries
{
    [TestFixture]
    public class Taxpayer  
    {
        #region Initialize
        Taxpayer_DBContext DBContext;
        int i = 0;
        #endregion

        public Taxpayer()
        {
            DbContextOptions<Taxpayer_DBContext> options = new DbContextOptions<Taxpayer_DBContext>();
                
            DBContext = new Taxpayer_DBContext(options);
            SeedDbcontextwithdata();
        }



        private void SeedDbcontextwithdata()
        {
            DBContext.Taxpayer.AddRange(new Domain.Models.Taxpayer()
            {
                ID = 1,
                FirstName = "Mohamed",
                SecondaryName = "Sayed",
                Address = "Nasr City",
                Language = Domain.Enums.LanguageTypes.English,
                Email = "m.sayed@yahoo.com",
                Phone = "+201111789766"
            },
            new Domain.Models.Taxpayer()
            {
                ID = 2,
                FirstName = "Sayed",
                SecondaryName = "Ali",
                Address = "Haram",
                Language = Domain.Enums.LanguageTypes.English,
                Email = "sayed@yahoo.com",
                Phone = "+201111789766"
            });

            DBContext.SaveChanges();
        }

        [Test]
        public void TestGetAllTaxpayers()
        {
            var query = new TaxpayerQuery();
            var Handler = new TaxpayerQueryHandler(DBContext);
            var response = Handler.Handle(query, CancellationToken.None);

            Assert.That(response, Is.Not.Null);
            foreach (var item in DBContext.Taxpayer)
            {
                Assert.That(response.Result[i].ID, Is.EqualTo(item.ID));
                Assert.IsInstanceOf<Domain.Models.Taxpayer>(response.Result[i]);
                i++;
            }
        }


    }
}
