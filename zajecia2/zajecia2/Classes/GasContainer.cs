using zajecia2.Exceptions;
using zajecia2.Interfaces;

namespace zajecia2.Classes
{
    public class GasContainer : Container, IHazardNotifier
    {
        private double _pressure;

        public GasContainer(double cargoWeight, double height, double ownWeight, double depth, double maxCargoWeight,
            double pressure)
            : base(cargoWeight, height, ownWeight, depth, maxCargoWeight)
        {
            _pressure = pressure;
        }

        public override void Load(double mass)
        {
            if (mass > MaxCargoWeight)
            {
                throw new OverfillException(
                    $"Próba załadowania kontenera {SerialNumber} przekraczająca maksymalną ładowność.");
            }

            CargoWeight += mass;
        }

        public override void EmptyCargo()
        {
            CargoWeight = 0.05;
        }


        public void NotifyDanger()
        {
            throw new NotImplementedException();
        }
    }
}