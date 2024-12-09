using System;

public class Converter
{
    private double _usdRate;
    private double _eurRate;
    private double _plnRate;

    public Converter(double usd, double eur, double pln)
    {
        _usdRate = usd;
        _eurRate = eur;
        _plnRate = pln;
    }

    public double ConvertToForeignCurrency(double amount, string currency)
    {
        return currency switch
        {
            "USD" => amount / _usdRate,
            "EUR" => amount / _eurRate,
            "PLN" => amount / _plnRate,
            _ => throw new ArgumentException("Invalid currency"),
        };
    }

    public double ConvertToHryvnia(double amount, string currency)
    {
        return currency switch
        {
            "USD" => amount * _usdRate,
            "EUR" => amount * _eurRate,
            "PLN" => amount * _plnRate,
            _ => throw new ArgumentException("Invalid currency"),
        };
    }
}

class Program
{
    static void Main()
    {
        Converter converter = new Converter(36.5, 40.0, 8.5);

        Console.WriteLine("Choose operation: 1 - Convert UAH to foreign currency, 2 - Convert foreign currency to UAH");
        int choice = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            Console.Write("Enter amount in UAH: ");
            double amount = double.Parse(Console.ReadLine());
            Console.Write("Enter currency (USD, EUR, PLN): ");
            string currency = Console.ReadLine();

            double convertedAmount = converter.ConvertToForeignCurrency(amount, currency);
            Console.WriteLine($"Converted amount: {convertedAmount} {currency}");
        }
        else if (choice == 2)
        {
            Console.Write("Enter amount in foreign currency: ");
            double amount = double.Parse(Console.ReadLine());
            Console.Write("Enter currency (USD, EUR, PLN): ");
            string currency = Console.ReadLine();

            double convertedAmount = converter.ConvertToHryvnia(amount, currency);
            Console.WriteLine($"Converted amount: {convertedAmount} UAH");
        }
        else
        {
            Console.WriteLine("Invalid choice");
        }
    }
}
