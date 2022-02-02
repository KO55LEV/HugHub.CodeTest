using HugHub.CodeTest.Application.Enums;
using HugHub.CodeTest.Application.Interfaces;
using HugHub.CodeTest.Application.Services.QuotationServices;
using HugHub.CodeTest.Infrastructure.Interfaces;

namespace HugHub.CodeTest.Application.Factories
{
    public class QuotationSystemFactory : IQuotationSystemFactory
    {
        //extend this if more new quotation system will be added. 
        private readonly IQuotationSystem1Service _quotationSystem1Service;
        private readonly IQuotationSystem2Service _quotationSystem2Service;
        private readonly IQuotationSystem3Service _quotationSystem3Service;

        public QuotationSystemFactory(
            IQuotationSystem1Service quotationSystem1Service,
            IQuotationSystem2Service quotationSystem2Service,
            IQuotationSystem3Service quotationSystem3Service
            )
        {
            _quotationSystem1Service = quotationSystem1Service;
            _quotationSystem2Service = quotationSystem2Service;
            _quotationSystem3Service = quotationSystem3Service;
        }

        public IQuotationService GetQuotationSystem(QuotationSystems quotationSystems)
        {
            switch (quotationSystems)
            {
                case QuotationSystems.QuotationSystem1:
                    return new QuotationSystem1(_quotationSystem1Service);
                case QuotationSystems.QuotationSystem2:
                    return new QuotationSystem2(_quotationSystem2Service);
                case QuotationSystems.QuotationSystem3:
                    return new QuotationSystem3(_quotationSystem3Service);
                default:
                    return new QuotationSystem3(_quotationSystem3Service);
            }
        }
    }
}
