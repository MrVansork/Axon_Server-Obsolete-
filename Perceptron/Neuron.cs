using System;

namespace NNet
{
    public class Neuron
    {
        private double _bias;
        public double Bias
        {
            get
            {
                return _bias;
            }
            set
            {
                _bias = value;
            }
        }

        private double[] _weights;
        public double[] Weights{
            get
            {
                return _weights;
            }
        }

        private double _lastActivation;
        public double LastActivation
        {
            get
            {
                return _lastActivation;
            }
        }

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

            _lastActivation = result;
            //TODO: Use the Function selected by the user
            return Utilities.Sigmoid(result);
        }

    }
}
