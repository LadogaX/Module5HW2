using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class ExchangeRatesController : ControllerBase
{
    private static readonly string[] Exchanges = new[]
    {
        "UAH", "USD", "RUB", "EUR", "AMD"
    };

    private readonly ILogger<ExchangeRatesController> _logger;

    public ExchangeRatesController(ILogger<ExchangeRatesController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetExchangeRates")]
    public IEnumerable<ExchangeRates> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new ExchangeRates
            {
                Date = DateTime.Now.AddDays(index),
                Price = (float)Random.Shared.Next(1, 100),
                Exchange = Exchanges[Random.Shared.Next(Exchanges.Length)]
            })
            .ToArray();
    }
}