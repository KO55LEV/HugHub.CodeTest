using HugHub.CodeTest.Infrastructure.Interfaces;
using HugHub.CodeTest.Infrastructure.Models.Configuration;
using System.Dynamic;


namespace HugHub.CodeTest.Infrastructure.Services
{
    public class QuotationSystem1Service : IQuotationSystemService
    {
        private readonly QuotationSystem1Settings _quotationSystem1Settings;
        //private readonly ExternalService _someExternalService;

        public QuotationSystem1Service(IOptions<QuotationSystem1Settings> quotationSystem1Settings)
        {
            _quotationSystem1Settings = quotationSystem1Settings.Value;

            //Todo set Url and Port 
            //_someExternalService.Url = _quotationSystem1Settings.QuotationSystem1Url;
            //_someExternalService.Port = _quotationSystem1Settings.QuotationSystem1Port;
        }

        public dynamic GetPrice(dynamic request)
        {
            //makes a call to an external service - SNIP
            //var response = _someExternalService.PostHttpRequest(requestData);

            dynamic response = new ExpandoObject();
            response.Price = 123.45M;
            response.IsSuccess = true;
            response.Name = "Test Name";
            response.Tax = 123.45M * 0.12M;

            return response;
        }
    }
}
