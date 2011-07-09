using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;

namespace OneTrueName.LPD6803
{
    public class Sample
    {
        private const int NumPixels = 70;
        private static Color temp = new Color(0, 0, 0);

        // I was using SPI2 because I was using SPI1 for some FEZ Music shields.
        // Change the SPI module to what you have the data/clock plugged into.
        // The second parameter is 
        private static readonly LPD6803 rope = new LPD6803(SPI.SPI_module.SPI2, NumPixels);

        public static void Main()
        {
            while(true)
            {
                Debug.Print("RED");
                ColorChase(255, 0, 0);
                
                Debug.Print("GREEN");
                ColorChase(0, 255, 0);
                
                Debug.Print("BLUE");
                ColorChase(0, 0, 255);

                Thread.Sleep(1000);
                Rainbow();
                Thread.Sleep(5000);
            }
        }

        private static void ColorChase(byte red, byte green, byte blue)
        {
            for(int i = 0; i < NumPixels; i++)
            {
                rope.SetColor(i, red, green, blue);
                Thread.Sleep(50);
            }

            //rope.Update();
        }

        private static void Rainbow()
        {
            for(int i = 0; i < NumPixels; i++)
            {
                var angle = (double) i / NumPixels * 360;
                Color.FromHSL(angle, 0.5, 0.5, ref temp);
                rope.SetColor(i, temp.Red, temp.Green, temp.Blue);
            }
        }
    }
}
