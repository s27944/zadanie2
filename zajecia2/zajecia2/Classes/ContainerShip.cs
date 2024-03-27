using zajecia2.Exceptions;

namespace zajecia2.Classes
{
    public class ContainerShip
    {
        private double MaxSpeed;
        private int MaxContainers;
        private List<Container> Containers;

        public ContainerShip(double maxSpeed, int maxContainers)
        {
            MaxSpeed = maxSpeed;
            MaxContainers = maxContainers;
            Containers = new List<Container>();
        }

        public double MaxWeightCapacity()
        {
            double totalWeight = 0;
            foreach (Container container in Containers)
            {
                totalWeight += container.CargoWeight;
            }
            return totalWeight;
        }

        public void LoadContainer(Container container)
        {
            if (Containers.Count >= MaxContainers)
            {
                throw new OverfillException("Nie można dodać więcej kontenerów, statek osiągnął maksymalną liczbę kontenerów.");
            }

            if (MaxWeightCapacity() + container.CargoWeight > MaxContainers)
            {
                throw new OverfillException("Przekroczono maksymalną masę kontenerów, statek nie może zabrać więcej ładunku.");
            }

            Containers.Add(container);
        }
        
        public void LoadContainerList(List<Container> containerList)
        {
            foreach (var container in containerList)
            {
                try
                {
                    LoadContainer(container);
                }
                catch (OverfillException ex)
                {
                    Console.WriteLine($"Błąd podczas ładowania kontenera: {ex.Message}");
                }
            }
        }

        public void UnloadContainer(Container container)
        {
            if (!Containers.Remove(container))
            {
                throw new InvalidOperationException("Podany kontener nie znajduje się na statku.");
            }
        }

        public void ReplaceContainer(Container oldContainer, Container newContainer)
        {
            if (!Containers.Remove(oldContainer))
            {
                throw new InvalidOperationException("Podany stary kontener nie znajduje się na statku.");
            }

            LoadContainer(newContainer);
        }

        public void PrintContainers()
        {
            Console.WriteLine("Kontenery na statku:");
            foreach (var container in Containers)
            {
                Console.WriteLine($"Numer seryjny: {container.SerialNumber}, Typ: {container.GetType().Name}, Masa ładunku: {container.CargoWeight}");
            }
        }

        public void PrintShipInfo()
        {
            Console.WriteLine($"Informacje o statku:");
            Console.WriteLine($"Maksymalna prędkość: {MaxSpeed} węzłów");
            Console.WriteLine($"Maksymalna liczba kontenerów: {MaxContainers}");
            Console.WriteLine($"Aktualna liczba kontenerów: {Containers.Count}");
            Console.WriteLine($"Aktualna masa ładunku: {MaxWeightCapacity()} ton");
        }
    }
}