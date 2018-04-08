# EzBtc.Api
A .Net Standard client for the ezBtc cryptocurrency API. 


[![nuget](https://img.shields.io/nuget/v/EzBtc.Api.svg)](https://www.nuget.org/packages/EzBtc.Api/)

**This is a beta version, meaning the API is feature complete, but may contain bugs.**

Contribute to this project by sending some XɃT my way: 1D8e1MuzW7a7NMvZSAjASJsMd1UonxjFUa 

Or show your support by using my referral link to create your account: 
https://www.ezbtc.ca/register?referral_code=15rx99hj2aeio


## Installation via NuGet
```
Install-Package EzBtc.Api
```

## Example usage

```csharp
using EzBtc.Api;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello ezBtc!");

            using (var client = new EzBtcClient())
            {
                try
                {
                    // Get ticker info.
                    var ticker = client.GetTickerAsync("xbtcad").GetAwaiter().GetResult();

                    Console.WriteLine("Volume = " + ticker.Volume);
                    Console.WriteLine("Last = " + ticker.Last);
                    Console.WriteLine("Low = " + ticker.Low);
                    Console.WriteLine("High = " + ticker.High);

                    // Get order book info.
                    var book = client.GetOrderBookAsync().GetAwaiter().GetResult();

                    foreach (var entry in book.Bids)
                    {
                        Console.WriteLine("Bid {0} for {1}.", entry.Amount, entry.Rate);
                    }

                    foreach (var entry in book.Asks)
                    {
                        Console.WriteLine("Ask {0} for {1}.", entry.Amount, entry.Rate);
                    }


                    // Get completed trades.
                    var trades = client.GetTransactionsAsync().GetAwaiter().GetResult();

                    foreach (var trade in trades)
                    {
                        Console.WriteLine("ID = {0}, Type = {1}, Amount = {2}, Rate = {3}", trade.TradeId, trade.Type, trade.Amount, trade.Rate);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.ReadKey();
        }
    }
}
```