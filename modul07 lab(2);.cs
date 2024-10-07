using System;
using System.Collections.Generic;
using System.Threading;

public interface IObserver
{
    void Update(float temp);
}

public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void UnregisterObserver(IObserver observer);
    void NotifyObservers();
}

public class WeatherStation : ISubject
{
    private List<IObserver> observers;
    private float temp;

    public WeatherStation()
    {
        observers = new List<IObserver>();
    }

    public void SetTemperature(float temp)
    {
        this.temp = temp;
        NotifyObservers();
    }

    public void NotifyObservers()
    {
        foreach (IObserver observer in observers)
        {
            observer.Update(this.temp);
        }
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void UnregisterObserver(IObserver observer)
    {
        observers.Remove(observer);
    }
}

public class WeatherDisplay : IObserver
{
    public void Update(float temp)
    {
        Console.WriteLine("Temperature changed to {0}", temp);
    }
}

class Program
{
    static void Main(string[] args)
    {
        WeatherStation station = new WeatherStation();
        WeatherDisplay display = new WeatherDisplay();

        station.RegisterObserver(display);

        Random rnd = new Random();
        while (true)
        {
            station.SetTemperature((float)rnd.Next(-30, 50));
            Thread.Sleep(3000);  
        }
    }
}
