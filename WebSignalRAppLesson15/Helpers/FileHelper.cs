using System.Text.Json;
using WebSignalRAppLesson15.Entities;

namespace WebSignalRAppLesson15.Helpers;
public static class FileHelper
{
    private static readonly string filePath = "data.json";

    // read the JSON and return the cars list :
    public static List<Car> Read()
    {
        string json = File.ReadAllText(filePath);
        var cars = JsonSerializer.Deserialize<List<Car>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });
        return cars;
    }

    // write the updated cars list back to the file :
    public static void Write(List<Car> cars)
    {
        string json = JsonSerializer.Serialize(cars, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }

    // update a car's price based on its name :
    public static void UpdateCarPrice(string carName, double newPrice)
    {
        // read current data from file :
        List<Car> cars = Read();

        // find the car and update its price :
        Car carToUpdate = cars.FirstOrDefault(car => car.Name == carName);
        if (carToUpdate != null)
        {
            carToUpdate.CurrentPrice += newPrice;
        }

        // write updated data back to the file :
        Write(cars);
    }

    // getting current price of car : 
    public static double GetCurrentPrice(string carName) {
        // read current data from file :
        List<Car> cars = Read();

        // find the car and update its price :
        Car car = cars.FirstOrDefault(car => car.Name == carName);
        return car.CurrentPrice;
    }

    // getting begin price of car :
    public static double GetBeginPrice(string carName) {
        // read current data from file :
        List<Car> cars = Read();

        // find the car and update its price :
        Car car = cars.FirstOrDefault(car => car.Name == carName);
        return car.BeginPrice;
    }
}
