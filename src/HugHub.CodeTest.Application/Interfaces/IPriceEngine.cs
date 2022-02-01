using HugHub.CodeTest.Application.Models.Responses;
using HugHub.CodeTest.Domain.Models.Requests;

namespace HugHub.CodeTest.Application.Interfaces
{
    public interface IPriceEngine
    {
        public PriceEngineResponse GetPrice(PriceRequest request)
    }
}
