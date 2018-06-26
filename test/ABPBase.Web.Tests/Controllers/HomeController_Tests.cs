using System.Threading.Tasks;
using ABPBase.Web.Controllers;
using Shouldly;
using Xunit;

namespace ABPBase.Web.Tests.Controllers
{
    public class HomeController_Tests: ABPBaseWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}
