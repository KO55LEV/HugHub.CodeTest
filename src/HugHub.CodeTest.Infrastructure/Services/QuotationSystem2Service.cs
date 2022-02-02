using HugHub.CodeTest.Infrastructure.Interfaces;
using HugHub.CodeTest.Infrastructure.Models.Configuration;
using Microsoft.Extensions.Options;
using System.Dynamic;

namespace HugHub.CodeTest.Infrastructure.Services
{
    public class QuotationSystem2Service : IQuotationSystem2Service
    {
        private readonly QuotationSystem2Settings _quotationSystem2Settings;
        //private readonly ExternalService2 _someExternalService2;

        public QuotationSystem2Service(IOptions<QuotationSystem2Settings> quotationSystem2Settings)
        {
            _quotationSystem2Settings = quotationSystem2Settings.Value;

            //Todo set Url and Port 
            //_someExternalService2.Url = _quotationSystem2Settings.QuotationSystem1Url;
            //_someExternalService2.Port = _quotationSystem2Settings.QuotationSystem1Port;
        }

        public dynamic GetPrice(dynamic request)
        {
            //makes a call to an external service - SNIP
            //var response = _someExternalService2.PostHttpRequest(requestData);

            dynamic response = new ExpandoObject();
            response.Price = 234.56M;
            response.HasPrice = true;
            response.Name = "qewtrywrh";
            response.Tax = 234.56M * 0.12M;

            return response;
        }
    }
}
