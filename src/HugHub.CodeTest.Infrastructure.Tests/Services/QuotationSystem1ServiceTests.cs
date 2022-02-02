using Xunit;
using NSubstitute;
using FluentAssertions;
using Microsoft.Extensions.Options;
using HugHub.CodeTest.Infrastructure.Models.Configuration;
using HugHub.CodeTest.Infrastructure.Services;
using HugHub.CodeTest.Infrastructure.Interfaces;
using System.Dynamic;
using System;

namespace HugHub.CodeTest.Infrastructure.Tests
{
    public class QuotationSystem1ServiceTests
    {

        private readonly IQuotationSystem1Service _quotationSystem1Service;

        public QuotationSystem1ServiceTests()
        {
            var serviceConfig = new QuotationSystem1Settings()
            {
                QuotationSystem1Url = "https://service1",
                QuotationSystem1Port = "123"
            };

            var options = Substitute.For<IOptions<QuotationSystem1Settings>>();
            options.Value.Returns(serviceConfig);
            _quotationSystem1Service  = new QuotationSystem1Service(options);
        }


        [Fact]
        public void GetPrice_Success_Returned_Result()
        {
            // Arrange
            dynamic request = new ExpandoObject();
            request.FirstName = "John";
            request.Surname = "Smith";
            request.DOB = new DateTime(1980, 1, 1);
            request.Make = "make";
            request.Amount = 50;
            // Act 

            var response = _quotationSystem1Service.GetPrice(request);
            bool IsSuccess = response.IsSuccess;

            // Assert
            IsSuccess.Should().Be(true);

        }

        [Fact]
        public void Price_Should_Be_Returned()
        {
            // Arrange
            dynamic request = new ExpandoObject();
            request.FirstName = "John";
            request.Surname = "Smith";
            request.DOB = new DateTime(1980,1,1);
            request.Make = "make";
            request.Amount = 50;
            // Act 

            var response = _quotationSystem1Service.GetPrice(request);
            decimal price = response.Price;

            // Assert
            price.Should().Be(123.45M);

        }
    }
}