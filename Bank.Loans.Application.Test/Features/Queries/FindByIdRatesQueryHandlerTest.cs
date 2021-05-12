using System.Threading;
using System.Threading.Tasks;
using Bank.Loans.Application.Features.Rates.Queries;
using Bank.Loans.Domain.Rates;
using FakeItEasy;
using Xunit;

namespace Bank.Loans.Application.Test.Features.Rates.Queries
{
    public class FindByIdRatesQueryHandlerTest
    {
        private Rate rateFake = new Rate(5);

        [Fact]
        public async Task Handle_SetExistingRate_ReturnRateInformation()
        {
            //Arrange
            var guid = rateFake.Id;
            FindByIdRatesQuery query = new FindByIdRatesQuery(guid);
            IRateRepository rateRepository = A.Fake<IRateRepository>();
            FindByIdRatesQueryHandler handler = new FindByIdRatesQueryHandler(rateRepository);

            A.CallTo(() => rateRepository.FindById(guid)).Returns(Task.FromResult(this.rateFake));

            //Act
            var result = await handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.True(result != null);
            Assert.True(result.Id == query.Id);
            Assert.Equal(result.AnnualInterestRate, this.rateFake.AnnualInterestRate);
        }
    }
}
