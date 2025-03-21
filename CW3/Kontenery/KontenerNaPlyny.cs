namespace CW3.Kontenery;

public class KontenerNaPlyny : Kontener, IHazardNotifier
{
    private static int _idCounter;
    protected sealed override char Letter { get; set; } = 'L';

    public KontenerNaPlyny()
    {
        SerialNumber = CreateName(Letter,_idCounter++);
    }

    public override void Load(double weight, string content)
    {
        double maxLoad = Data.Data.HazardousMaterials.Contains(content) ? 0.5 * MaxWeight : 0.9 * MaxWeight;
        
        if (Weight+weight > maxLoad)
        {
            Notify("Próba przeładowania kontenera: "+SerialNumber);
            throw new OverfillException("Próba przeładowania kontenera: "+SerialNumber);
        }

        base.Load(weight, content);

    }
    
    public void Notify(string message)
    {
        Console.WriteLine("Error " + SerialNumber + ": " + message);
    }
}