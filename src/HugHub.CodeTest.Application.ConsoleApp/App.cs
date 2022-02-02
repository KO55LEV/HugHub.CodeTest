using HugHub.CodeTest.Application.Interfaces;
using HugHub.CodeTest.Domain.Models;
using HugHub.CodeTest.Domain.Models.Requests;

public class App
{
    private IPriceEngine _priceEngine;
    public App(IPriceEngine priceEngine)
    {
        _priceEngine = priceEngine;
    }

    public async Task Run(string[] args)
    {
        var request = new PriceRequest()
        {
            RiskData = new RiskData() //hardcoded here, but would normally be from user input above
            {
                DOB = DateTime.Parse("1980-01-01"),
                FirstName = "John",
                LastName = "Smith",
                Make = "Cool New Phone",
                Value = 500
            }
        };

        var response = _priceEngine.GetPrice(request);

        if (response.ErrorMessage.Length > 0)
        {
            Console.WriteLine($"There was an error - {response.ErrorMessage}");
        }
        else
        {
            Console.WriteLine($"You price is {response.Price}, from insurer: {response.InsurerName}. This includes tax of {response.Tax}");
        }

        Console.WriteLine("Press any key to exit");
        Console.ReadKey();

        await Task.CompletedTask;
    }
}