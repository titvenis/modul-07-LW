using System;

public interface IShippingStrategy
{
    double CalculateShipping(double distance, double weight);
}

public class StandardShippingStrategy : IShippingStrategy
{
    public double CalculateShipping(double distance, double weight)
    {
        return weight + distance;
    }
}

public class ExpressShipping : IShippingStrategy
{
    public double CalculateShipping(double distance, double weight)
    {
        return weight * 0.75 + distance * 0.2 + 20;
    }
}

public class InternationalShipping : IShippingStrategy
{
    public double CalculateShipping(double distance, double weight)
    {
        return weight + distance * 0.5 + 15;
    }
}

public class DeliveryContext
{
    private readonly IShippingStrategy _shipping;

    public DeliveryContext(IShippingStrategy shipping)
    {
        _shipping = shipping;
    }

    public double CalculateCost(double distance, double weight)
    {
        return _shipping.CalculateShipping(distance, weight);
    }
}

class Program
{
    static void Main(string[] args)
    {
        DeliveryContext delivery = null;
        int typeDelivery = 1;

        if (typeDelivery == 1)
        {
            delivery = new DeliveryContext(new StandardShippingStrategy());
        }

        Console.WriteLine("Weight(kg):");
        double weight = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Distance (km):");
        double distance = Convert.ToDouble(Console.ReadLine());

        double cost = delivery.CalculateCost(distance, weight);
        Console.WriteLine($"Cost: {cost:C}");
    }
}
