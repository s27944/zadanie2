using zajecia2.Exceptions;

namespace zajecia2.Classes
{
    public abstract class Container
    {
        public string SerialNumber { get; private set; }
        public double CargoWeight { get; protected set; }
        public double Height { get; protected set; }
        public double OwnWeight { get; protected set; }
        public double Depth { get; protected set; }
        public double MaxCargoWeight { get; protected set; }
        public static int ContainerCount = 1;

        public Container(double cargoWeight, double height, double ownWeight, double depth, double maxCargoWeight)
        {
            SerialNumber = $"KON-{GetType().Name.Substring(0, 1)}-{ContainerCount++}";
            CargoWeight = cargoWeight;
            Height = height;
            OwnWeight = ownWeight;
            Depth = depth;
            MaxCargoWeight = maxCargoWeight;
        }



        public abstract void EmptyCargo();



        public abstract void Load(double masa);
    }
}