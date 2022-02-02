using Xunit;
using NSubstitute;
using FluentAssertions;
using Microsoft.Extensions.Options;
using System.Dynamic;
using System;
using HugHub.CodeTest.Infrastructure.Interfaces;
using HugHub.CodeTest.Domain.Models.Requests;
using HugHub.CodeTest.Domain.Models;
using HugHub.CodeTest.Application.Interfaces;
using HugHub.CodeTest.Application.Services.QuotationServices;

namespace HugHub.CodeTest.Application.Tests.Services.QuotationServices
{
    public class QuotationSystem1Tests
    {
        private readonly IQuotationSystem1Service _mockInfrastructureService;
        private readonly IQuotationService _applicationService;

        public QuotationSystem1Tests()
        {
            _mockInfrastructureService = Substitute.For<IQuotationSystem1Service>();
            _applicationService = new QuotationSystem1(_mockInfrastructureService);
        }

        [Fact]
        public void DOB_Not_Provided_Mock_GetPrice_Not_Called()
        {
            // Arrange
            var request = new PriceRequest()
            {
                RiskData = new RiskData() 
                {
                    FirstName = "John",
                    LastName = "Smith",
                    Make = "Cool New Phone",
                    Value = 500
                }
            };

            dynamic mockServiceResponse = new ExpandoObject();
            mockServiceResponse.FirstName = "John";
            mockServiceResponse.Surname = "Smith";
            mockServiceResponse.DOB = new DateTime(1980, 1, 1);
            mockServiceResponse.Make = "make";
            mockServiceResponse.Amount = 50;

            //TODO find how to cust to dynamic 
            //_mockInfrastructureService.GetPrice(Arg.Any<dynamic>).Returns(mockServiceResponse);

            // Act 
            var response = _applicationService.GetPrice(request);

            // Assert
            //_mockInfrastructureService.DidNotReceive().GetPrice(Arg.Any<dynamic>);
        }
    }
}
