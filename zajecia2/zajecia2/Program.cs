using System;
using zajecia2.Classes;


class Program
{
    static void Main(string[] args)
    {
        var ship = new ContainerShip(maxSpeed: 20, maxContainers: 100);

        while (true)
        {
            Console.WriteLine("Wybierz operację:");
            Console.WriteLine("1. Stwórz nowy kontener");
            Console.WriteLine("2. Załaduj ładunek do kontenera");
            Console.WriteLine("3. Załaduj kontener na statek");
            Console.WriteLine("4. Załaduj listę kontenerów na statek");
            Console.WriteLine("5. Usuń kontener ze statku");
            Console.WriteLine("6. Rozładuj kontener");
            Console.WriteLine("7. Zastąp kontener na statku innym kontenerem");
            Console.WriteLine("8. Przenieś kontener między statkami");
            Console.WriteLine("9. Wyświetl informacje o kontenerze");
            Console.WriteLine("10. Wyświetl informacje o statku i jego ładunku");
            Console.WriteLine("11. Zakończ");

            string input = Console.ReadLine();
            Container newContainer = null;
            List<Container> containterList = new List<Container>();
            switch (input)
            {
                case "1":
                    Console.WriteLine("Wybierz rodzaj kontenera:");
                    Console.WriteLine("1. GasContainer");
                    Console.WriteLine("2. CoolingContainer");
                    Console.WriteLine("3. LiquidContainer");

                    string containerTypeChoice = Console.ReadLine();
                    

                    Console.WriteLine("Podaj dane nowego kontenera:");

                    Console.WriteLine("Waga ładunku (kg):");
                    double cargoWeight = double.Parse(Console.ReadLine());
                    Console.WriteLine("Wysokość (cm):");
                    double height = double.Parse(Console.ReadLine());
                    Console.WriteLine("Własna waga kontenera (kg):");
                    double ownWeight = double.Parse(Console.ReadLine());
                    Console.WriteLine("Głębokość (cm):");
                    double depth = double.Parse(Console.ReadLine());
                    Console.WriteLine("Maksymalna waga ładunku (kg):");
                    double maxCargoWeight = double.Parse(Console.ReadLine());

                    switch (containerTypeChoice)
                    {
                        case "1":
                            Console.WriteLine("Ciśnienie (atmosfery):");
                            double pressure = double.Parse(Console.ReadLine());
                            newContainer = new GasContainer(cargoWeight, height, ownWeight, depth, maxCargoWeight,
                                pressure);
                            Console.WriteLine("Nowy kontener na gaz został utworzony.");
                            break;
                        case "2":
                            Console.WriteLine("Rodzaj produktu:");
                            string productType = Console.ReadLine();
                            Console.WriteLine("Wymagana temperatura:");
                            double requiredTemperature = double.Parse(Console.ReadLine());
                            newContainer = new CoolingContainer(cargoWeight, height, ownWeight, depth, maxCargoWeight,
                                productType, requiredTemperature);
                            Console.WriteLine("Nowy chłodniczy kontener został utworzony.");
                            break;
                        case "3":
                            newContainer = new LiquidContainer(cargoWeight, height, ownWeight, depth, maxCargoWeight, false);
                            Console.WriteLine("Nowy kontener na płyny został utworzony.");
                            break;
                        default:
                            Console.WriteLine("Niepoprawny wybór.");
                            break;
                    }
                    containterList.Add(newContainer);
                    break;
                case "2":
                    Console.WriteLine("Masa ładunku do załadowania:");
                    newContainer.Load(Convert.ToDouble(Console.ReadLine()));
                    break;
                case "3":
                    ship.LoadContainer(newContainer);
                    break;
                case "4":
                    ship.LoadContainerList(containterList);
                    break;
                case "5":
                    ship.UnloadContainer(newContainer);
                    break;
                case "6":
                    ship.UnloadContainer(newContainer);
                    break;
                case "7":
                    Container newerContainer = new GasContainer(20, 20, 20, 20, 20, 20);
                    ship.ReplaceContainer(newContainer, newerContainer);
                    break;
                case "8":
                    var ship2 = new ContainerShip(30, 100);
                    ship.UnloadContainer(newContainer);
                    ship2.LoadContainer(newContainer);
                    break;
                case "9":
                    Console.WriteLine("Kontener: ", newContainer.SerialNumber, newContainer.CargoWeight,
                        newContainer.MaxCargoWeight);
                    
                    break;
                case "10":
                    ship.PrintShipInfo();
                    break;
                case "11":
                    Console.WriteLine("Zakończono program.");
                    return;
                default:
                    Console.WriteLine("Niepoprawne polecenie. Wybierz opcję od 1 do 11.");
                    break;
            }
        }
    }
}

