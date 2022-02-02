using HugHub.CodeTest.Application.Enums;
using HugHub.CodeTest.Application.Interfaces;
using HugHub.CodeTest.Application.Models.Responses;
using HugHub.CodeTest.Domain.Models.Requests;

namespace HugHub.CodeTest.Application.Services
{
    public class PriceEngineService : IPriceEngine
    {

        private readonly IQuotationSystemFactory _quotationSystemFactory;

        public PriceEngineService(IQuotationSystemFactory quotationSystemFactory)
        {
            _quotationSystemFactory = quotationSystemFactory;
        }

        public PriceEngineResponse? GetPrice(PriceRequest request)
        {
            var response = new PriceEngineResponse();

            //For proper validation we may use https://fluentvalidation.net/ 
            var validateRequest = ValidateRequest(request);

            if (!validateRequest.Validated)
            {
                response.ErrorMessage = string.Join(",", validateRequest.ErrorMessages); 
                return response;
            }
            
            var quotationSystemsResponses = new List<PriceEngineResponse>();

            //get all quotation system responses  
            foreach (QuotationSystems quotationSystem in Enum.GetValues(typeof(QuotationSystems)))
            {
                var system = _quotationSystemFactory.GetQuotationSystem(quotationSystem);
                var systemResponse = system.GetPrice(request);
                if (systemResponse != null)
                {
                    //TODO  map properly PriceEngineResponse > PriceEngineResponse using Mapper
                    quotationSystemsResponses.Add(new PriceEngineResponse
                    {
                        Price = systemResponse.Price,
                        InsurerName = systemResponse.InsurerName,
                        Tax = systemResponse.Tax,
                        ErrorMessage = ""  //TODO we could use this to catch error from service, we will need to put then in try catch system.GetPrice(request); etc
                    });
                }
            }

            var bestPriceResponse = quotationSystemsResponses.MinBy(x => x.Price);

            return bestPriceResponse;
        }


        public PriceEngineValidateRequestResponse ValidateRequest(PriceRequest request)
        {
            var validationResponse = new PriceEngineValidateRequestResponse()
            {
                Validated = true,
                ErrorMessages = new List<string>()
            };

            if (request.RiskData == null)
            {
                validationResponse.ErrorMessages.Add("Risk Data is missing");
                validationResponse.Validated = true;
            }

            if (String.IsNullOrEmpty(request.RiskData?.FirstName))
            {
                validationResponse.ErrorMessages.Add("First name is required");
                validationResponse.Validated = true;
            }

            if (String.IsNullOrEmpty(request.RiskData?.LastName))
            {
                validationResponse.ErrorMessages.Add("Surname is required");
                validationResponse.Validated = true;
            }

            if (request.RiskData?.Value == 0)
            {
                validationResponse.ErrorMessages.Add("Value is required");
                validationResponse.Validated = true;
            }

            return validationResponse;
        }
    }
}
