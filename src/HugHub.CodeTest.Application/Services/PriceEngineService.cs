using HugHub.CodeTest.Application.Interfaces;
using HugHub.CodeTest.Application.Models.Responses;
using HugHub.CodeTest.Domain.Models.Requests;

namespace HugHub.CodeTest.Application.Services
{
    public class PriceEngineService : IPriceEngine
    {
        public PriceEngineResponse GetPrice(PriceRequest request)
        {
            var response = new PriceEngineResponse() { Price = -1, Tax = 0 };
            var requestValidationFailed = false;

            //validation
            if (request.RiskData == null)
            {
                response.ErrorMessage = "Risk Data is missing";
                requestValidationFailed = true;
            }

            if (String.IsNullOrEmpty(request.RiskData?.FirstName))
            {
                response.ErrorMessage = "First name is required";
                requestValidationFailed = true;
            }

            if (String.IsNullOrEmpty(request.RiskData?.LastName))
            {
                response.ErrorMessage = "Surname is required";
                requestValidationFailed = true;
            }

            if (request.RiskData?.Value == 0)
            {
                response.errorMessage = "Value is required";
                requestValidationFailed = true;
            }

            if (requestValidationFailed) return response;

            //now call 3 external system and get the best price
            decimal price = 0;

            //system 1 requires DOB to be specified
            if (request.RiskData.DOB != null)
            {
                QuotationSystem1 system1 = new QuotationSystem1("http://quote-system-1.com", "1234");

                dynamic systemRequest1 = new ExpandoObject();
                systemRequest1.FirstName = request.RiskData.FirstName;
                systemRequest1.Surname = request.RiskData.LastName;
                systemRequest1.DOB = request.RiskData.DOB;
                systemRequest1.Make = request.RiskData.Make;
                systemRequest1.Amount = request.RiskData.Value;

                dynamic system1Response = system1.GetPrice(systemRequest1);
                if (system1Response.IsSuccess)
                {
                    price = system1Response.Price;
                    insurerName = system1Response.Name;
                    tax = system1Response.Tax;
                }
            }

            //system 2 only quotes for some makes
            if (request.RiskData.Make == "examplemake1" || request.RiskData.Make == "examplemake2" ||
                request.RiskData.Make == "examplemake3")
            {
                dynamic systemRequest2 = new ExpandoObject();
                systemRequest2.FirstName = request.RiskData.FirstName;
                systemRequest2.LastName = request.RiskData.LastName;
                systemRequest2.Make = request.RiskData.Make;
                systemRequest2.Value = request.RiskData.Value;

                QuotationSystem2 system2 = new QuotationSystem2("http://quote-system-2.com", "1235", systemRequest2);

                dynamic system2Response = system2.GetPrice();
                if (system2Response.HasPrice && system2Response.Price < price)
                {
                    price = system2Response.Price;
                    insurerName = system2Response.Name;
                    tax = system2Response.Tax;
                }
            }

            //system 3 is always called
            QuotationSystem3 system3 = new QuotationSystem3("http://quote-system-3.com", "100");
            dynamic systemRequest3 = new ExpandoObject();

            systemRequest3.FirstName = request.RiskData.FirstName;
            systemRequest3.Surname = request.RiskData.LastName;
            systemRequest3.DOB = request.RiskData.DOB;
            systemRequest3.Make = request.RiskData.Make;
            systemRequest3.Amount = request.RiskData.Value;

            var system3Response = system3.GetPrice(systemRequest3);
            if (system3Response.IsSuccess && system3Response.Price < price)
            {
                price = system3Response.Price;
                insurerName = system3Response.Name;
                tax = system3Response.Tax;
            }

            if (price == 0)
            {
                price = -1;
            }

            return price;
        }
    }
}
