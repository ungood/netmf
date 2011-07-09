using System;
using Microsoft.SPOT;

namespace OneTrueName.LPD6803
{
    public class Color
    {
        public byte Red { get; private set; }
        public byte Green { get; private set; }
        public byte Blue { get; private set; }

        public Color(double red, double green, double blue)
        {
            Red = (byte) (red * 255);
            Green = (byte) (green * 255);
            Blue = (byte) (blue * 255);
        }

        public Color(byte red, byte green, byte blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        /// <summary>
        /// Create a color from the HSL color space.
        /// </summary>
        /// <remarks>>
        /// I pass in a reference to an existing color instead of creating a new color
        /// to avoid using the GC too much.
        /// </remarks>
        public static void FromHSL(double h, double s, double l, ref Color color)
        {
            double v;
            double r,g,b;
 
            r = l;   // default to gray
            g = l;
            b = l;
            v = (l <= 0.5) ? (l * (1.0 + s)) : (l + s - l * s);
            if (v > 0)
            {
                  double m;
                  double sv;
                  int sextant;
                  double fract, vsf, mid1, mid2;
 
                  m = l + l - v;
                  sv = (v - m ) / v;
                  h *= 6.0;
                  sextant = (int)h;
                  fract = h - sextant;
                  vsf = v * sv * fract;
                  mid1 = m + vsf;
                  mid2 = v - vsf;
                  switch (sextant)
                  {
                        case 0:
                              r = v;
                              g = mid1;
                              b = m;
                              break;
                        case 1:
                              r = mid2;
                              g = v;
                              b = m;
                              break;
                        case 2:
                              r = m;
                              g = v;
                              b = mid1;
                              break;
                        case 3:
                              r = m;
                              g = mid2;
                              b = v;
                              break;
                        case 4:
                              r = mid1;
                              g = m;
                              b = v;
                              break;
                        case 5:
                              r = v;
                              g = m;
                              b = mid2;
                              break;
                  }
            }
            color.Red = (byte) (r * 255);
            color.Green = (byte) (g * 255);
            color.Blue = (byte) (b * 255);
        }
    }
}
