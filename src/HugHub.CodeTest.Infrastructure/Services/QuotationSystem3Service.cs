using HugHub.CodeTest.Infrastructure.Interfaces;
using HugHub.CodeTest.Infrastructure.Models.Configuration;
using System.Dynamic;

namespace HugHub.CodeTest.Infrastructure.Services
{
    public class QuotationSystem3Service : IQuotationSystemService
    {
        private readonly QuotationSystem3Settings _quotationSystem3Settings;
        //private readonly ExternalService3 _someExternalService3;

        public QuotationSystem1Service(IOptions<QuotationSystem3Settings> quotationSystem3Settings)
        {
            _quotationSystem3Settings = quotationSystem3Settings.Value;

            //Todo set Url and Port 
            //_someExternalService3.Url = _quotationSystem2Settings.QuotationSystem1Url;
            //_someExternalService3.Port = _quotationSystem2Settings.QuotationSystem1Port;
        }

        public dynamic GetPrice(dynamic request)
        {
            //makes a call to an external service - SNIP
            //var response = _someExternalService3.PostHttpRequest(requestData);

            dynamic response = new ExpandoObject();
            response.Price = 92.67M;
            response.IsSuccess = true;
            response.Name = "zxcvbnm";
            response.Tax = 92.67M * 0.12M;

            return response;
        }
    }
}
