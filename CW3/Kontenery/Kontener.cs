namespace CW3.Kontenery;

public abstract class Kontener
{
    protected abstract char Letter { get;set; }

    private static readonly List<string> _serialNumbers = [];
    public double Weight { get; protected set; } = 0;
    protected double Height { get; set; } = 200;
    protected double OwnWeight { get; set; } = 200;
    protected double Depth { get; set; } = 500;
    public string SerialNumber { get; protected set; }
    protected double MaxWeight { get; set; } = 1000;
    protected string? Content { get;set; }

    protected static string CreateName(char letter, int number)
    {
        string name = $"KON-{letter}-{number}";
        if (_serialNumbers.Contains(name))
            throw new SystemException(name+" is already in use");
        _serialNumbers.Add(name);
        return name;
    }
    
    public virtual void Unload()
    {
        Weight = 0;
        Content = null;
    }

    public virtual void Load(double weight, string content)
    {
        if (Weight + weight > MaxWeight)
            throw new OverfillException("Próba przeładowania kontenera: "+SerialNumber);
        if (Content != content && Content != null)
            throw new SystemException("Nie można przechować " + content + " w kontenerze na " + Content);
        Weight += weight;
        Content = content;
    }

    public override string ToString()
    {
        string contentstr = Content ?? "Brak";
        return $"{SerialNumber} Content: {contentstr} Weight: {Weight}";
    }
}