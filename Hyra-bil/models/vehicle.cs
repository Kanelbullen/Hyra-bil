using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyra_bil.models
{
    public abstract class Vehicle
    {
        public string RegistrationNumber { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public int Year { get; set; }
        public bool IsRented { get; set; }

        public Vehicle(string registrationNumber, string model, string brand, int year)
        {
            RegistrationNumber = registrationNumber;
            Model = model;
            Brand = brand;
            Year = year;
            IsRented = false;
        }

        public abstract string GetVehicleInfo();
    }

    public class Car : Vehicle
    {
        public int Mileage { get; set; }

        public Car(string registrationNumber, string model, string brand, int year, int mileage)
            : base(registrationNumber, model, brand, year)
        {
            Mileage = mileage;
        }

        public override string GetVehicleInfo()
        {
            return $"Car - {Brand} {Model} ({Year}), Mileage: {Mileage} km, Rented: {IsRented}";
        }
    }

    public class Truck : Vehicle
    {
        public int LoadCapacity { get; set; }

        public Truck(string registrationNumber, string model, string brand, int year, int loadCapacity)
            : base(registrationNumber, model, brand, year)
        {
            LoadCapacity = loadCapacity;
        }

        public override string GetVehicleInfo()
        {
            return $"Truck - {Brand} {Model} ({Year}), Load Capacity: {LoadCapacity} kg, Rented: {IsRented}";
        }
    }

    public class Motorcycle : Vehicle
    {
        public int EngineDisplacement { get; set; }

        public Motorcycle(string registrationNumber, string model, string brand, int year, int engineDisplacement)
            : base(registrationNumber, model, brand, year)
        {
            EngineDisplacement = engineDisplacement;
        }

        public override string GetVehicleInfo()
        {
            return $"Motorcycle - {Brand} {Model} ({Year}), Engine Displacement: {EngineDisplacement} cc, Rented: {IsRented}";
        }
    }


}
