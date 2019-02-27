using System;

namespace Util
{
    public static class Maths
    {
        public static double Normalize(double value, double min, double max)
        {
            return (value - min) / (max - min);
        }

        public static double InverseNormalize(double value, double min, double max)
        {
            return value * (max - min) + min;
        }
    }
}
