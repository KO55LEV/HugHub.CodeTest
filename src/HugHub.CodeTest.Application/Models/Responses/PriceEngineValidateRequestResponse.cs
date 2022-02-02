namespace HugHub.CodeTest.Application.Models.Responses
{
    public class PriceEngineValidateRequestResponse
    {
        public bool Validated { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
