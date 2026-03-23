namespace apbd_app2.Domain.Models;

public class Laptop : Equipment
{
    public int RamGB { get; private set; }
    public double ScreenSizeInch { get; private set; }

    public Laptop(string name, int ramGB, double screenSizeInch) : base(name)
    {
        RamGB = ramGB;
        ScreenSizeInch = screenSizeInch;
    }
}