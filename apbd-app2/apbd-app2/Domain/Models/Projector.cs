namespace apbd_app2.Domain.Models;

public class Projector : Equipment
{
    public int Lumens { get; private set; }
    public string Resolution { get; private set; }

    public Projector(string name, int lumens, string resolution) : base(name)
    {
        Lumens = lumens;
        Resolution = resolution;
    }
}