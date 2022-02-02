using HugHub.CodeTest.Application.Enums;

namespace HugHub.CodeTest.Application.Interfaces
{
    public interface IQuotationSystemFactory
    {
        public IQuotationService GetQuotationSystem(QuotationSystems quotationSystems);
    }
}
