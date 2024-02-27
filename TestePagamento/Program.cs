using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

class Program
{
    class Car
    {
        public string PlateNumber { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public DateTime EntryTime { get; set; }
    }

    static List<Car> parkingLot = new List<Car>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("===O Farol Estacionamento===");
            Console.WriteLine("1. Estacione seu carro");
            Console.WriteLine("2. Retirare seu carro");
            Console.WriteLine("3. Mostrar carros estacionados");
            Console.WriteLine("4. Sair");

            Console.Write("Escolha uma opção: ");
            string choice = Console.ReadLine();
           
            switch (choice)
            {
                case "1":
                    ParkCar();
                    break;
                case "2":
                    RemoveCar();
                    break;
                case "3":
                    ShowCars();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
                    
            }
            
        }
      
    }

    static void ParkCar()
    {
        Console.Write("Digite a placa do carro: ");
        string plateNumber = Console.ReadLine();

        Car car = new Car { PlateNumber = plateNumber, EntryTime = DateTime.Now };
        parkingLot.Add(car);

        Console.WriteLine("Carro estacionado com sucesso!");
        Console.ReadKey();
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
        
    }

    static void RemoveCar()
    {
        Console.Write("Digite a placa do carro a ser retirado: ");
        string plateNumber = Console.ReadLine();

        Car carToRemove = parkingLot.Find(c => c.PlateNumber == plateNumber);

        if (carToRemove != null)
        {
            decimal totalCost = CalculateParkingCost(carToRemove.EntryTime);
            parkingLot.Remove(carToRemove);
            Console.WriteLine($"Valor a pagar:R${totalCost}");
            Console.ReadKey();
            Console.WriteLine("valor pago Com Sucesso, Obrigado e Volte Sempre");
            Console.ReadKey();
            Console.WriteLine($"Carro retirado com sucesso!{carToRemove.EntryTime}");
        }
        else
        {
            Console.WriteLine("Carro não encontrado no estacionamento.");
        }

        Console.ReadLine();
    }

    static decimal CalculateParkingCost(DateTime entryTime)
    {
        TimeSpan parkingDuration = DateTime.Now - entryTime;
        int minutesUsed = (int)parkingDuration.TotalMinutes;

        int baseCost = 15;
        int additionalCostPerMinute = 1;

        decimal totalCost = baseCost + ((minutesUsed - 5) * additionalCostPerMinute);
        return Math.Max(0, totalCost); 
    }

    static void ShowCars()
    {
        Console.WriteLine("Carros estacionados:");

        foreach (var car in parkingLot)
        {
            Console.WriteLine($"Placa: {car.PlateNumber},  Entrada: {car.EntryTime}");
        }

        Console.ReadLine();
    }
}