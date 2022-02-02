using HugHub.CodeTest.Application.Interfaces;
using HugHub.CodeTest.Application.Models.Responses;
using HugHub.CodeTest.Domain.Models.Requests;
using HugHub.CodeTest.Infrastructure.Interfaces;
using System.Dynamic;

namespace HugHub.CodeTest.Application.Services.QuotationServices
{
    public class QuotationSystem2 : IQuotationService
    {
        private readonly IQuotationSystem2Service _quotationSystemService;

        //this could be moved to the settings and injected to constructor or loaded from DB etc  
        private static readonly string[] AllowedMakes = { "examplemake1", "examplemake2", "examplemake3" };

        public QuotationSystem2(IQuotationSystem2Service quotationSystemService)
        {
            _quotationSystemService = quotationSystemService;
        }

        public QuotationServiceResponse GetPrice(PriceRequest request)
        {
            var response = new QuotationServiceResponse();

            if (AllowedMakes.Any(request.RiskData.Make.Contains))
            {
                // here we may use Mapper class to map objects 

                dynamic systemRequest = new ExpandoObject();
                systemRequest.FirstName = request.RiskData.FirstName;
                systemRequest.LastName = request.RiskData.LastName;
                systemRequest.Make = request.RiskData.Make;
                systemRequest.Value = request.RiskData.Value;

                //todo add errror handling 
                var quotationSystemServiceResponse = _quotationSystemService.GetPrice(systemRequest);

                if (quotationSystemServiceResponse.HasPrice)
                {
                    response.Price = quotationSystemServiceResponse.Price;
                    response.InsurerName = quotationSystemServiceResponse.Name;
                    response.Tax = quotationSystemServiceResponse.Tax;
                }
            }

            return response;
        }
    }
}
