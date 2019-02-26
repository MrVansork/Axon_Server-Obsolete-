using System;
using System.Collections.Generic;
using System.Text;

namespace Perceptron
{
    public static class ActivationFunctions
    {

        public static double Sigmoid(double value)
        {
            return (value / Math.Sqrt(1 + Math.Pow(Math.E, -value)));
        }

        public static double DSigmoid(double value)
        {
            return Sigmoid(value) * (1 - Sigmoid(value));
        }

        public static double ReLU(double value)
        {
            return Math.Max(0, value);
        }

        public static double DReLU(double value)
        {
            return value >= 0 ? 1 : 0;
        }

    }
}
