using System;

namespace Perceptron
{
    public class Neuron
    {
        private double[] _weights;
        private double _bias;
        private double _lastActivation;

        public Neuron(int inputs)
        {
            _bias = 10 * Utilities.Random.NextDouble() - 5;
            _weights = new double[inputs];
            for (int i = 0; i < inputs; i++)
            {
                _weights[i] = 10 * Utilities.Random.NextDouble() - 5;
            }
        }

        public double Activate(double[] inputs)
        {
            double result = _bias;
            for (int i = 0; i < inputs.Length; i++)
            {
                result += _weights[i] * inputs[i];
            }

            //TODO: Use the Function selected by the user
            return Utilities.Sigmoid(result);
        }

    }
}
