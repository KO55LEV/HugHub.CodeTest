using HugHub.CodeTest.Application.Interfaces;
using HugHub.CodeTest.Application.Models.Responses;
using HugHub.CodeTest.Domain.Models.Requests;
using HugHub.CodeTest.Infrastructure.Interfaces;
using System.Dynamic;

namespace HugHub.CodeTest.Application.Services.QuotationServices
{
    public class QuotationSystem3 : IQuotationService
    {
        private readonly IQuotationSystem3Service _quotationSystemService;

        public QuotationSystem3(IQuotationSystem3Service quotationSystemService)
        {
            _quotationSystemService = quotationSystemService;
        }

        public QuotationServiceResponse GetPrice(PriceRequest request)
        {
            var response = new QuotationServiceResponse();
            // here we may use Mapper class to map objects 

            dynamic systemRequest = new ExpandoObject();
            systemRequest.FirstName = request.RiskData.FirstName;
            systemRequest.Surname = request.RiskData.LastName;
            systemRequest.DOB = request.RiskData.DOB;
            systemRequest.Make = request.RiskData.Make;
            systemRequest.Amount = request.RiskData.Value;

            //todo add errror handling 
            var quotationSystemServiceResponse = _quotationSystemService.GetPrice(systemRequest);

            if (quotationSystemServiceResponse.IsSuccess)
            {
                response.Price = quotationSystemServiceResponse.Price;
                response.InsurerName = quotationSystemServiceResponse.Name;
                response.Tax = quotationSystemServiceResponse.Tax;
            }

            return response;
        }
    }
}
