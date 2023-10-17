using System;
using System.Collections.Generic;
using System.Linq;

// Clase de un vehículo
class Vehicle
{
    public string Model { get; set; }
    public string OwnerDNI { get; set; }
    public string LicensePlate { get; set; }
    public double Width { get; set; }
    public double Length { get; set; }

    // Constructor de vehículo con atributos aleatorios
    public Vehicle()
    {
        Random random = new Random();
        Model = "Model" + random.Next(1, 1000);
        OwnerDNI = "DNI" + random.Next(10000, 99999);
        LicensePlate = "Plate" + random.Next(100, 999);
        Width = random.Next(150, 250) / 100.0; // Entre 1.5 y 2 metros
        Length = random.Next(300, 600) / 100.0; // Entre 3 y 6 metros
    }
}

// Estacionamiento
class ParkingLot
{
    private List<Vehicle> regularParking = new List<Vehicle>();
    private List<Vehicle> quantumParking = new List<Vehicle>();

    public void ListAllVehicles()
    {
        Console.WriteLine("Vehículos en el estacionamiento regular:");
        foreach (var vehicle in regularParking)
        {
            Console.WriteLine($"Modelo: {vehicle.Model}, Propietario: {vehicle.OwnerDNI}, Matrícula: {vehicle.LicensePlate}");
        }

        Console.WriteLine("Vehículos en el estacionamiento cuántico:");
        foreach (var vehicle in quantumParking)
        {
            Console.WriteLine($"Modelo: {vehicle.Model}, Propietario: {vehicle.OwnerDNI}, Matrícula: {vehicle.LicensePlate}");
        }
    }

    public void AddVehicle(Vehicle vehicle)
    {
        // Verificar de lugar
        if (vehicle.Length <= 5.0 && vehicle.Width <= 2.0)
        {
            regularParking.Add(vehicle);
        }
        else
        {
            quantumParking.Add(vehicle);
        }
    }

    public void RemoveVehicleByLicensePlate(string licensePlate)
    {
        regularParking.RemoveAll(v => v.LicensePlate == licensePlate);
        quantumParking.RemoveAll(v => v.LicensePlate == licensePlate);
    }

    public void RemoveVehicleByOwnerDNI(string ownerDNI)
    {
        regularParking.RemoveAll(v => v.OwnerDNI == ownerDNI);
        quantumParking.RemoveAll(v => v.OwnerDNI == ownerDNI);
    }

    public void RemoveRandomVehicles(int count)
    {
        Random random = new Random();
        for (int i = 0; i < count; i++)
        {
            if (regularParking.Count > 0 || quantumParking.Count > 0)
            {
                int choice = random.Next(0, 2); // 0  regular, 1 cuántico
                if (choice == 0 && regularParking.Count > 0)
                {
                    regularParking.RemoveAt(random.Next(0, regularParking.Count));
                }
                else if (quantumParking.Count > 0)
                {
                    quantumParking.RemoveAt(random.Next(0, quantumParking.Count));
                }
            }
        }
    }

    public void OptimizeSpace()
    {
        // Mover vehículos que no ocupan el lugar correspondiente
        List<Vehicle> tempStorage = new List<Vehicle>();

        foreach (var vehicle in regularParking.ToList())
        {
            if (vehicle.Length > 5.0 || vehicle.Width > 2.0)
            {
                tempStorage.Add(vehicle);
                regularParking.Remove(vehicle);
            }
        }

        foreach (var vehicle in tempStorage)
        {
            AddVehicle(vehicle); // Intenta estacionarlos nuevamente
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ParkingLot parkingLot = new ParkingLot();
        
        // Generar vehículos aleatorios y agregarlos al estacionamiento
        for (int i = 0; i < 20; i++)
        {
            Vehicle vehicle = new Vehicle();
            parkingLot.AddVehicle(vehicle);
        }

        Console.WriteLine("Vehículos en el estacionamiento:");
        parkingLot.ListAllVehicles();

        Console.WriteLine("\nEliminando un vehículo por matrícula:");
        parkingLot.RemoveVehicleByLicensePlate("Plate123");

        Console.WriteLine("\nVehículos después de eliminar:");
        parkingLot.ListAllVehicles();

        Console.WriteLine("\nEliminando un vehículo por DNI del propietario:");
        parkingLot.RemoveVehicleByOwnerDNI("DNI456");

        Console.WriteLine("\nVehículos después de eliminar:");
        parkingLot.ListAllVehicles();

        Console.WriteLine("\nEliminando una cantidad aleatoria de vehículos:");
        parkingLot.RemoveRandomVehicles(5);

        Console.WriteLine("\nVehículos después de eliminar aleatoriamente:");
        parkingLot.ListAllVehicles();

        Console.WriteLine("\nOptimizando espacio en el estacionamiento:");
        parkingLot.OptimizeSpace();

        Console.WriteLine("\nVehículos después de la optimización:");
        parkingLot.ListAllVehicles();
    }
}