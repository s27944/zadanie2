using zajecia2.Exceptions;
using zajecia2.Interfaces;

namespace zajecia2.Classes;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool _isHazardous;

    public LiquidContainer(double cargoWeight, double height, double ownWeight, double depth, double maxCargoWeight,
        bool isHazardous)
        : base(cargoWeight, height, ownWeight, depth, maxCargoWeight)
    {
        _isHazardous = isHazardous;
        if (_isHazardous)
        {
            MaxCargoWeight *= 0.5;
        }
        else
        {
            MaxCargoWeight *= 0.9;
        }
    }

    public override void EmptyCargo()
    {
        CargoWeight = 0;
    }

    public override void Load(double cargoWeight)
    {
        if (_isHazardous && cargoWeight > MaxCargoWeight * 0.5)
        {
            throw new OverfillException(
                $"Próba załadowania kontenera {SerialNumber} przekraczająca maksymalną ładowność dla ładunku niebezpiecznego.");
        }
        else if (cargoWeight > MaxCargoWeight * 0.9)
        {
            throw new OverfillException(
                $"Próba załadowania kontenera {SerialNumber} przekraczająca maksymalną ładowność dla ładunku bezpiecznego.");
        }

        CargoWeight += cargoWeight;
    }

    public void NotifyDanger()
    {
        Console.WriteLine("Niebezpieczna sytuacja: " + SerialNumber);
    }
}