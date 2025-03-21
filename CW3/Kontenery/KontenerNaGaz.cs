namespace CW3.Kontenery;

public class KontenerNaGaz : Kontener, IHazardNotifier
{
    
    private static int _idCounter;
    protected sealed override char Letter { get; set; } = 'G';
    private double Pressure { get; set; }

    public KontenerNaGaz(double pressure)
    {
        SerialNumber = CreateName(Letter,_idCounter++);
        Pressure = pressure;
    }
    
    public override void Unload()
    {
        if (Content == null)
            return;
        Weight = 0.05 * Weight;
        Pressure = 0;
        Content = null;
    }

    public override void Load(double weight ,string content)
    {
        if (weight > MaxWeight)
        {
            Notify("Konterer jest przepełniony");
            throw new OverfillException("Konterer jest przepełniony");
        }
        
        base.Load(weight, content);
    }
    
    
    public void Notify(string message)
    {
        Console.WriteLine("Error " + SerialNumber + ": " + message);
    }
}