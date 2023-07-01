using UnityEngine;
using JuhaKurisu.Unixels.V4;

public class SampleMono : MonoBehaviour
{
    Unixel unixel;

    private void Start()
    {
        unixel = new(512, 512);
        UnixelMono unixelMono = UnixelMono.CreateUnixelDisplay(unixel);
    }

    private void Update()
    {
        unixel.Clear(Color.green);
        unixel.SetPixel(10, 10, new Color32(255, 0, 255, 255));
    }
}
