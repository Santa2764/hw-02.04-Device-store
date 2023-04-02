using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace дз_02._04
{
    abstract class Device
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Color { get; set; }

        public abstract void PrintInfo();
    }

    class MobilePhone : Device
    {
        public string OperatingSystem { get; set; }

        public override void PrintInfo()
        {
            Console.WriteLine($"Mobile Phone: {Manufacturer} {Model}, OS: {OperatingSystem}, Qty: {Quantity}, Price: {Price}, Color: {Color}");
        }
    }

    class Laptop : Device
    {
        public int RAM { get; set; }

        public override void PrintInfo()
        {
            Console.WriteLine($"Laptop: {Manufacturer} {Model}, RAM: {RAM} GB, Qty: {Quantity}, Price: {Price}, Color: {Color}");
        }
    }

    class Tablet : Device
    {
        public string ScreenSize { get; set; }

        public override void PrintInfo()
        {
            Console.WriteLine($"Tablet: {Manufacturer} {Model}, Screen: {ScreenSize}, Qty: {Quantity}, Price: {Price}, Color: {Color}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Device> devices = new List<Device>();

            while (true)
            {
                Console.WriteLine("\nWhat do you want to do?");
                Console.WriteLine("1. Add a device");
                Console.WriteLine("2. Remove a device by criteria");
                Console.WriteLine("3. Print device list");
                Console.WriteLine("4. Search for a device by criteria");
                Console.WriteLine("5. Exit");

                Console.Write("\nEnter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddDevice(devices);
                        break;
                    case "2":
                        RemoveDevice(devices);
                        break;
                    case "3":
                        PrintDeviceList(devices);
                        break;
                    case "4":
                        SearchDevice(devices);
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }

        static void AddDevice(List<Device> devices)
        {
            Console.WriteLine("\nWhat type of device do you want to add?");
            Console.WriteLine("1. Mobile Phone");
            Console.WriteLine("2. Laptop");
            Console.WriteLine("3. Tablet");

            Console.Write("\nEnter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    MobilePhone phone = new MobilePhone();
                    FillDeviceDetails(phone);
                    Console.Write("Enter the operating system: ");
                    phone.OperatingSystem = Console.ReadLine();
                    devices.Add(phone);
                    break;
                case "2":
                    Laptop laptop = new Laptop();
                    FillDeviceDetails(laptop);
                    Console.Write("Enter the RAM size in GB: ");
                    laptop.RAM = int.Parse(Console.ReadLine());
                    devices.Add(laptop);
                    break;
                case "3":
                    Tablet tablet = new Tablet();
                    FillDeviceDetails(tablet);
                    Console.Write("Enter the screen size: ");
                    tablet.ScreenSize = Console.ReadLine();
                    devices.Add(tablet);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }

        static void FillDeviceDetails(Device device)
        {
            Console.Write("Enter the manufacturer: ");
            device.Manufacturer = Console.ReadLine();
            Console.Write("Enter the model: ");
            device.Model = Console.ReadLine();

            Console.Write("Enter the quantity: ");
            device.Quantity = int.Parse(Console.ReadLine());

            Console.Write("Enter the price: ");
            device.Price = decimal.Parse(Console.ReadLine());

            Console.Write("Enter the color: ");
            device.Color = Console.ReadLine();
        }

        static void RemoveDevice(List<Device> devices)
        {
            Console.WriteLine("\nWhat criteria do you want to use for removing a device?");
            Console.WriteLine("1. Manufacturer");
            Console.WriteLine("2. Model");

            Console.Write("\nEnter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter the manufacturer: ");
                    string manufacturer = Console.ReadLine();
                    devices.RemoveAll(d => d.Manufacturer == manufacturer);
                    Console.WriteLine($"Removed all devices from {manufacturer}.");
                    break;
                case "2":
                    Console.Write("Enter the model: ");
                    string model = Console.ReadLine();
                    devices.RemoveAll(d => d.Model == model);
                    Console.WriteLine($"Removed all devices with model {model}.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }

        static void PrintDeviceList(List<Device> devices)
        {
            Console.WriteLine("\nDevice List:");
            foreach (Device device in devices)
            {
                device.PrintInfo();
            }
        }

        static void SearchDevice(List<Device> devices)
        {
            Console.WriteLine("\nWhat criteria do you want to use for searching a device?");
            Console.WriteLine("1. Manufacturer");
            Console.WriteLine("2. Model");

            Console.Write("\nEnter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter the manufacturer: ");
                    string manufacturer = Console.ReadLine();
                    List<Device> matchingDevicesByManufacturer = devices.FindAll(d => d.Manufacturer == manufacturer);
                    if (matchingDevicesByManufacturer.Count > 0)
                    {
                        Console.WriteLine($"Found {matchingDevicesByManufacturer.Count} devices from {manufacturer}:");
                        foreach (Device device in matchingDevicesByManufacturer)
                        {
                            device.PrintInfo();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No devices found from {manufacturer}.");
                    }
                    break;
                case "2":
                    Console.Write("Enter the model: ");
                    string model = Console.ReadLine();
                    List<Device> matchingDevicesByModel = devices.FindAll(d => d.Model == model);
                    if (matchingDevicesByModel.Count > 0)
                    {
                        Console.WriteLine($"Found {matchingDevicesByModel.Count} devices with model {model}:");
                        foreach (Device device in matchingDevicesByModel)
                        {
                            device.PrintInfo();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No devices found with model {model}.");
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}