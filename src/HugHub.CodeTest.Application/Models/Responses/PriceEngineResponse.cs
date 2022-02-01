namespace HugHub.CodeTest.Application.Models.Responses
{
    public class PriceEngineResponse
    {
        public decimal Price { get; set; }        
        public decimal Tax { get; set; }
        public string InsurerName { get; set; }
        public string ErrorMessage { get; set; }

    }
}
