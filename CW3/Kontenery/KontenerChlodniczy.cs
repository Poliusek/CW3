using CW3.Data;

namespace CW3.Kontenery;

public class KontenerChlodniczy : Kontener, IHazardNotifier
{
    protected sealed override char Letter { get; set; } = 'C';
    private static int _idCounter;
    
    private Items StorableItem { get; set; }
    private double Temperature { get; set; } = new Random().Next(-40, 7);
    
    public KontenerChlodniczy(Items storableItem)
    {
        StorableItem = storableItem;
        SerialNumber = CreateName(Letter, _idCounter++);
    }

    public override void Load(double weight, string content)
    {
        if (StorableItem.ToString() != content)
            Notify("Nie można przechować " + content + " w kontenerze na " + StorableItem);
        

        if (Temperature < Data.Data.TempData[content])
            Notify("Temperatura w kontenerze jest za niska dla " + content);
        

        base.Load(weight, content);
    }

    public void Notify(string message)
    {
        Console.WriteLine("Error " + SerialNumber + ": " + message);
    }
}