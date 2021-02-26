using CarClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Car Store.");
            Console.WriteLine("\nTo get started you must create a car catalogue, then you may add some cars to the shopping cart. \nFinally you may checkout which will give you the total value of the shopping cart.");

            Store s = new Store();
            int option = chooseOption();

            while (option != 0)
            {
                switch(option)
                {
                    //Add to catalogue
                    case 1:

                        Console.WriteLine("You chose to add a new car to the catalogue");

                        string carMake;
                        string carModel;
                        string carColour;
                        int carYear;
                        int carPrice;

                        Console.WriteLine("\nWhat is the car make? (e.g. Audi, BMW, Mercedes-Benz, etc)");
                        Console.Write("Make: ");
                        carMake = Console.ReadLine();

                        Console.WriteLine("\nWhat is the car model? (e.g. A5, 530d, C-Class, etc)");
                        Console.Write("Model: ");
                        carModel = Console.ReadLine();

                        Console.WriteLine("\nWhat is the car's colour?");
                        Console.Write("Colour: ");
                        carColour = Console.ReadLine();

                        Console.WriteLine("\nIn which year was the car manufactured?");
                        Console.Write("Year: ");
                        carYear = int.Parse(Console.ReadLine());

                        Console.WriteLine("\nWhat is the car's price?");
                        Console.Write("Price: £");
                        carPrice = int.Parse(Console.ReadLine());

                        Car newCar = new Car(carMake, carModel, carColour, carYear, carPrice);
                        s.CarCatalogue.Add(newCar);

                        printCarCatalogue(s);
                        break;


                    //Add to cart
                    case 2:

                        Console.WriteLine("You chose to add a car to your cart");
                        printCarCatalogue(s);
                        Console.WriteLine("\nWhich car from the catalogue would you like to buy?");
                        Console.Write("Car: ");
                        int carChosen = int.Parse(Console.ReadLine());
                        carChosen--;

                        s.Cart.Add(s.CarCatalogue[carChosen]);

                        printCart(s);
                        break;


                    //Checkout
                    case 3:
                        printCart(s);
                        Console.WriteLine($"The total cost for the cars you would like to buy comes to £{s.Checkout()}");
                        break;


                    default:
                        break;
                }

                option = chooseOption();
            }
            
        }

    private static void printCart(Store s)
        {
            Console.WriteLine("\nCars you have chosen to buy:");
            int i = 0;
            foreach (Car c in s.Cart)
            {
                i++;
                Console.WriteLine($"Car {i}: {c.Make} {c.Model} {c.Colour} {c.Year} £{c.Price}");
            }
        }

        private static void printCarCatalogue(Store s)
        {
            Console.WriteLine("\nList of cars in the catalogue:");
            int i = 0;
            foreach (Car c in s.CarCatalogue)
            {
                i++;
                Console.WriteLine($"Car {i}: {c.Make} {c.Model} {c.Colour} {c.Year} £{c.Price}");
            }
        }

        static public int chooseOption()
        {
            int choice = 0;
            Console.WriteLine("\nMain Menu \n(0) Quit \n(1) Add a car to the catalogue \n(2) Add a car to the cart \n(3) Checkout ");
            Console.Write("\nPlease choose an option (0-3): ");
            choice = int.Parse(Console.ReadLine());
            return choice;

            //int.Parse will cause the program to crash if the user types something other than an integer. Add a try and catch to prevent the app crashing.
        }
    }
}
