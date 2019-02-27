using System;
using System.Collections.Generic;
using System.Text;

namespace NNet
{
    public class Perceptron
    {
        private Layer[] _layers;

        public Perceptron(int[] neuronsPerLayer)
        {
            _layers = new Layer[neuronsPerLayer.Length];
            for (int i = 0; i < _layers.Length; i++)
            {
                _layers[i] = new Layer(neuronsPerLayer[i], i == 0 ? neuronsPerLayer[i] : neuronsPerLayer[i - 1]);
            }
        }

        public double[] Activate(double[] inputs)
        {
            double[] outputs = null;

            for (int i = 1; i < _layers.Length; i++)
            {
                outputs = _layers[i].Activate(inputs);
                inputs = outputs;
            }

            return outputs;
        }

        public bool Learn(List<double[]> input, List<double[]> desiredOutput, double alpha, double maxError, int maxIterations, String net_path = null, int iter_save = 1)
        {
            double err = 99999;
            int it = maxIterations;
            while (err > maxError)
            {
                ApplyBackPropagation(input, desiredOutput, alpha);
                err = GeneralError(input, desiredOutput);


                if ((it - maxIterations) % 1000 == 0)
                {
                    Console.WriteLine(err + " iterations: " + (it - maxIterations));
                }


                maxIterations--;

                if (maxIterations <= 0)
                {
                    Console.WriteLine("MINIMO LOCAL");
                    return false;
                }

            }

            return true;
        }


        private double IndividualError(double[] realOutput, double[] desiredOutput)
        {
            double err = 0;
            for (int i = 0; i < realOutput.Length; i++)
            {
                err += Math.Pow(realOutput[i] - desiredOutput[i], 2);
            }
            return err;
        }

        private double GeneralError(List<double[]> input, List<double[]> desiredOutput)
        {
            double err = 0;
            for (int i = 0; i < input.Count; i++)
            {
                err += IndividualError(Activate(input[i]), desiredOutput[i]);
            }
            return err;
        }

        private List<double[]> _sigmas;
        private List<double[,]> _deltas;

        private void SetSigmas(double[] desiredOutput)
        {
            _sigmas = new List<double[]>();
            for (int i = 0; i < _layers.Length; i++)
            {
                _sigmas.Add(new double[_layers[i].GetNeurons().Length]);
            }

            for (int i = _layers.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < _layers[i].GetNeurons().Length; j++)
                {
                    if (i == _layers.Length - 1)
                    {
                        double y = _layers[i].GetNeurons()[j].LastActivation;
                        _sigmas[i][j] = (Utilities.Sigmoid(y) - desiredOutput[j]) * Utilities.DSigmoid(y);
                    }
                    else
                    {
                        double sum = 0;
                        for (int k = 0; k < _layers[i + 1].GetNeurons().Length; k++)
                        {
                            sum += _layers[i + 1].GetNeurons()[k].Weights[j] * _sigmas[i + 1][k];
                        }
                        _sigmas[i][j] = Utilities.DSigmoid(_layers[i].GetNeurons()[j].LastActivation) * sum;
                    }
                }
            }
        }

        private void SetDeltas()
        {
            _deltas = new List<double[,]>();
            for (int i = 0; i < _layers.Length; i++)
            {
                _deltas.Add(new double[_layers[i].GetNeurons().Length, _layers[i].GetNeurons()[0].Weights.Length]);
            }
        }

        private void AddDelta()
        {
            for (int i = 1; i < _layers.Length; i++)
            {
                for (int j = 0; j < _layers[i].GetNeurons().Length; j++)
                {
                    for (int k = 0; k < _layers[i].GetNeurons()[j].Weights.Length; k++)
                    {
                        _deltas[i][j, k] += _sigmas[i][j] * Utilities.Sigmoid(_layers[i - 1].GetNeurons()[k].LastActivation);
                    }
                }
            }
        }

        private void UpdateBias(double alpha)
        {
            for (int i = 0; i < _layers.Length; i++)
            {
                for (int j = 0; j < _layers[i].GetNeurons().Length; j++)
                {
                    _layers[i].GetNeurons()[j].Bias -= alpha * _sigmas[i][j];
                }
            }
        }

        private void UpdateWeights(double alpha)
        {
            for (int i = 0; i < _layers.Length; i++)
            {
                for (int j = 0; j < _layers[i].GetNeurons().Length; j++)
                {
                    for (int k = 0; k < _layers[i].GetNeurons()[j].Weights.Length; k++)
                    {
                        _layers[i].GetNeurons()[j].Weights[k] -= alpha * _deltas[i][j, k];
                    }
                }
            }
        }

        private void ApplyBackPropagation(List<double[]> input, List<double[]> desiredOutput, double alpha)
        {
            SetDeltas();
            for (int i = 0; i < input.Count; i++)
            {
                Activate(input[i]);
                SetSigmas(desiredOutput[i]);
                UpdateBias(alpha);
                AddDelta();
            }
            UpdateWeights(alpha);

        }

    }
}
