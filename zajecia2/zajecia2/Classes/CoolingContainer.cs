using System;
using zajecia2.Exceptions;
using zajecia2.Interfaces;

namespace zajecia2.Classes
{
    public class CoolingContainer : Container, IHazardNotifier
    {
        private string ProductType;
        private double RequiredTemperature;

        public CoolingContainer(double cargoWeight, double height, double ownWeight, double depth, double maxCargoWeight, string productType, double requiredTemperature) 
            : base(cargoWeight, height, ownWeight, depth, maxCargoWeight)
        {
            ProductType = productType;
            RequiredTemperature = requiredTemperature;
        }

        
        public override void EmptyCargo()
        {
            CargoWeight = 0;
        }
        

        public override void Load(double mass)
        {
            if (mass > MaxCargoWeight)
            {
                throw new OverfillException($"Próba załadowania kontenera {SerialNumber} przekraczająca maksymalną ładowność.");
            }
            

            CargoWeight += mass;
        }

        public void SetTemperature(double temperature)
        {
            if (temperature < RequiredTemperature)
            {
                throw new ArgumentException($"Temperatura kontenera {SerialNumber} jest niższa niż wymagana dla produktu typu {ProductType}.");
            }

            Console.WriteLine($"Ustawiono temperaturę kontenera {SerialNumber} na {temperature} stopni Celsjusza.");
        }

        public void NotifyDanger()
        {
            throw new NotImplementedException();
        }
    }
}