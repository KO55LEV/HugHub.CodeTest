using HugHub.CodeTest.Application.Models.Responses;
using HugHub.CodeTest.Domain.Models.Requests;

namespace HugHub.CodeTest.Application.Interfaces
{
    public interface IQuotationService
    {
        public QuotationServiceResponse GetPrice(PriceRequest request);
    }
}
