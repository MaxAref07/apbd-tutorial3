namespace apbd_app2.Domain.Models;

public class Camera : Equipment
{
    public int MegaPixels { get; private set; }
    public bool HasVideo { get; private set; }
    public Camera(string name, int megaPixels, bool hasVideo) : base(name)
    {
        MegaPixels = megaPixels;
        HasVideo = hasVideo;
    }
}