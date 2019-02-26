using System;
using System.Collections.Generic;
using System.Text;

namespace Perceptron
{
    public static class Utilities
    {
        public static Random Random = new Random();

        #region Activation Functions

        public static double Sigmoid(double value)
        {
            return (value / Math.Sqrt(1 + Math.Pow(Math.E, -value)));
        }

        public static double DSigmoid(double value)
        {
            double x = Sigmoid(value);
            return x * (1 - x);
        }

        public static double ReLU(double value)
        {
            return Math.Max(0, value);
        }

        public static double DReLU(double value)
        {
            return value >= 0 ? 1 : 0;
        }

        #endregion

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
