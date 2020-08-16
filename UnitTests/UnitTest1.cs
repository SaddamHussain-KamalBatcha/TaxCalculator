using Moq;
using Repository;
using System;
using System.IO;
using Contract.Interface;
using Xunit;
using Domain.Services;
using Shouldly;

namespace UnitTests
{
    public class TaxUnitTest
    {
        private readonly Mock<ITaxRepository> _taxRepositoryMock;
        private readonly  ITaxProducerService _taxProducerService;

        public TaxUnitTest()
        {
            _taxRepositoryMock = new Mock<ITaxRepository>();
            _taxProducerService = new TaxProducerService(_taxRepositoryMock.Object);
        }

        [Fact]
        public void GetTaxRate_NotFound_ThrowException()
        {
            //Arrange
         
            _taxRepositoryMock.Setup(x => x.GetTaxRate("cophenhegan", "2019-01-01")).Returns(0);

            // Act & Assert
            var result = Should.Throw<InvalidDataException>(() => _taxProducerService.GetTaxRate("", ""));
        }

        [Fact]
        public void GetTaxRate_ValidData_ReturnResult()
        {
            //Arrange
            _taxRepositoryMock.Setup(x => x.GetTaxRate("cophenhegan", "2019-01-01")).Returns(2);

            // Act 
            var result =  _taxProducerService.GetTaxRate("cophenhegan", "2019-01-01");

            //Assert
            result.ShouldBe(2);
        }
    }
}
