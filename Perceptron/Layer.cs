using System;
using System.Collections.Generic;
using System.Text;

namespace NNet
{
    class Layer
    {
        private Neuron[] _neurons;
        private double[] _outputs;

        public Layer(int neuronsLength, int inputsLength)
        {
            _neurons = new Neuron[neuronsLength];
            _outputs = new double[neuronsLength];
            for (int i = 0; i < neuronsLength; i++)
            {
                _neurons[i] = new Neuron(inputsLength);
            }
        }

        public double[] Activate(double[] inputs)
        {
            for (int i = 0; i < _neurons.Length; i++)
            {
                _outputs[i] = _neurons[i].Activate(inputs);
            }

            return _outputs;
        }

        public Neuron[] GetNeurons() { return _neurons; }

    }
}
