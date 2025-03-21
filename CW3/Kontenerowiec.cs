using System.Text;
using CW3.Kontenery;

namespace CW3;

public class Kontenerowiec
{
    private static readonly List<Kontenerowiec> _ships = [];
    public List<Kontener> _containers { get; private set; }
    private double _maxSpeed;
    private double _currentSpeed;
    private int _maxContainers;
    private double _maxWeight;
    private double _currentWeight;
    
    public Kontenerowiec(double maxSpeed, int maxContainers, double maxWeight)
    {
        _maxSpeed = maxSpeed;
        _maxContainers = maxContainers;
        _maxWeight = maxWeight;
        _containers = new List<Kontener>();
        _currentWeight = 0;
        _currentSpeed = 0;
        _ships.Add(this);
    }

    public void Load(Kontener kontener)
    {
        if (_containers.Count + 1 > _maxContainers)
            throw new Exception("Brak miejsca na kontener");
        if (_currentWeight + kontener.Weight > _maxWeight)
            throw new Exception("Brak miejsca na kontener");
        _containers.Add(kontener);
        _currentWeight += kontener.Weight;
    }
    
    public void Load(List<Kontener> kontenery)
    {
        if (_containers.Count + kontenery.Count > _maxContainers)
            throw new Exception("Brak miejsca na kontenery");
        if (_currentWeight + kontenery.Sum(k => k.Weight) > _maxWeight)
            throw new Exception("Brak miejsca na kontenery");
        _containers.AddRange(kontenery);
        _currentWeight += kontenery.Sum(k => k.Weight);
    }

    public void Unload(Kontener kontener)
    {
        if (!_containers.Contains(kontener))
            throw new Exception("Kontener nie znajduje się na statku");
        _containers.Remove(kontener);
        _currentWeight -= kontener.Weight;
    }
    
    public List<Kontener> UnloadAll()
    {
        List<Kontener> containersCopy = [.._containers];
        _containers.Clear();
        _currentWeight = 0;
        return containersCopy;
    }
    
    public void SwitchContainer(String serialNumber, Kontener kontener)
    {
        if (_containers.Contains(kontener))
            throw new Exception("Kontener nie znajduje się na statku");
        Kontener oldContainer = _containers.First(k => k.SerialNumber == serialNumber);
        _containers.Remove(oldContainer);
        _containers.Add(kontener);
    }

    public void SwitchShip(Kontener kontener, Kontenerowiec kontenerowiec)
    {
        if (!_containers.Contains(kontener))
            throw new Exception("Kontener nie znajduje się na statku");
        kontenerowiec.Load(kontener);
        Unload(kontener);
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        sb.AppendLine($"Statek {_ships.IndexOf(this)} (speed={_maxSpeed}, maxContainers={_maxContainers}, maxWeight={_maxWeight})");
        sb.AppendLine("Zawartość:");
        if (_containers.Count == 0)
            sb.AppendLine("Brak kontenerów");
        else
            foreach (Kontener con in _containers)
                sb.AppendLine(con.ToString());

        return sb.ToString();
    }
}