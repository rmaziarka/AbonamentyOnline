using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abon.BusinessLogic.Services.Portal;
using Abon.Database.Model.Portal;
using Abon.Dto.Portal.Home;
using Tests.Core;
using Xunit;
using Xunit.Extensions;

namespace Abon.BusinessLogic.Tests.Services.Portal
{
    public class OffersServiceTest
    {
        private IQueryable<Offer> _offers;

        public OffersServiceTest()
        {
            var list = new List<Offer>()
                       {
                           new Offer(){Category = new Category() {Left = 2, Right = 3}},
                           new Offer(){Category = new Category() {Left = 4, Right = 5}},
                           new Offer(){Category = new Category() {Left = 6, Right = 7}},
                           new Offer(){Category = new Category() {Left = 1, Right = 8}},
                       };


            _offers = list.AsQueryable();
        }


        [Theory, PropertyData("CategoryFilterData")]
        public void it_should_filter_categories_between_left_and_right_including_borders(int left, int right, int count)
        {

            var offerService = new OffersService(new MockUnitOfWork());

            var offers = offerService.FilterByCategories(_offers, left, right);

            Assert.Equal(count,offers.Count());
        }


        public static IEnumerable<object[]> CategoryFilterData
        {
            get
            {
                return new[]
                       {
                           new object[] {1, 8, 4},
                           new object[] {1, 2, 0},
                           new object[] {0, 1, 0},
                           new object[] {2, 3, 1},
                       };
            }
        }
    }
}