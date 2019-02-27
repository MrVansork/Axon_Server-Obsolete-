using System;
using System.Collections.Generic;
using System.IO;

namespace Axon_Server
{
    class Program
    {
        /*
        static int inputCount = 1;
        static int outputCount = 1;

        static double inputMax = 0;
        static double inputMin = 5;

        static double outputMax = 250;
        static double outputMin = 0;

        static List<double[]> input = new List<double[]>();
        static List<double[]> output = new List<double[]>();

        static void ReadData()
        {
            Log.i("Program", "Loading DataSet");
            string data = System.IO.File.ReadAllText("res/DatosTermocupla.csv").Replace("\r", "");//.Replace(",", ".");
            string[] row = data.Split(Environment.NewLine.ToCharArray());
            for (int i = 0; i < row.Length; i++)
            {
                string[] rowData = row[i].Split(';');

                double[] inputs = new double[inputCount];
                double[] outputs = new double[outputCount];

                for (int j = 0; j < rowData.Length; j++)
                {
                    if (j < inputCount)
                    {
                        inputs[j] = Util.Maths.Normalize(double.Parse(rowData[j]), inputMin, inputMax);
                    }
                    else
                    {
                        outputs[j - inputCount] = Util.Maths.Normalize(double.Parse(rowData[j]), outputMin, outputMax);
                    }
                }

                input.Add(inputs);
                output.Add(outputs);
            }
            Log.i("Program", "DataSet Loaded");
        }

        static void Evaluate(NNet.Perceptron p, double from, double to, double step)
        {
            string output = "";
            for (double i = from; i < to; i += step)
            {
                double res = p.Activate(new double[] { Util.Maths.Normalize(i, inputMin, inputMax) })[0];


                output += i + ";" + Util.Maths.InverseNormalize(res, outputMin, outputMax) + "\n";
                Console.WriteLine(i + ";" + res + "\n");
            }

            System.IO.File.WriteAllText(@"res/output.csv", output);
        }

        static void Main(string[] args)
        {
            Console.Write(Constants.BigTitle);
            Console.WriteLine("  Server");
            Console.WriteLine("---------------------------------------------\n");

            foreach (string arg in args)
            {
                switch (arg)
                {
                    case "debug":
                        Log.add(Log.Debug);
                        break;
                    default:
                        Log.w("Program", $"'{arg}' is not recognized as an argument");
                        break;
                }
            }

            NNet.Perceptron p;
            int[] netDef= new int[] {inputCount, 5, 5, outputCount};

            //Alpha
            double learnRate = 0.3;
            int maxIterations = 10000000;

            double maxError = 0.0005;

            ReadData();

            p = new NNet.Perceptron(netDef);

            while (!p.Learn(input, output, learnRate, maxError, maxIterations))
            {
                p = new NNet.Perceptron(netDef);
            }

            Log.i("Program", "Perceptron Trained");

            Evaluate(p, 0, 5, 0.1);

            while (false)
            {
                double[] val = new double[inputCount];
                for (int i = 0; i < inputCount; i++)
                {
                    Console.WriteLine("Inserte valor " + i + ": ");
                    val[i] = Util.Maths.Normalize(double.Parse(Console.ReadLine()), inputMin, inputMax);
                }
                double[] sal = p.Activate(val);
                for (int i = 0; i < outputCount; i++)
                {
                    Console.Write("Respuesta " + i + ": " + Util.Maths.InverseNormalize(sal[i], outputMin, outputMax) + " ");
                }
                Console.WriteLine("");
            }

            Console.Write("\nPulse cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
    */

    static void Main(string[] args)
    {
        FileStream ifsLabels = new FileStream(@"res/train-labels.idx1-ubyte", FileMode.Open);
        FileStream ifsImages = new FileStream(@"res/train-images.idx3-ubyte", FileMode.Open);

        BinaryReader brLabels = new BinaryReader(ifsLabels);
        BinaryReader brImages = new BinaryReader(ifsImages);

        int magic1 = brImages.ReadInt32();
        int numImages = brImages.ReadInt32();
        int numRows = brImages.ReadInt32();
        int numCols = brImages.ReadInt32();

        int magic2 = brLabels.ReadInt32();
        int numLabels = brLabels.ReadInt32();

        byte[][] pixels = new byte[28][];
        for (int i = 0; i < pixels.Length; i++)
            pixels[i] = new byte[28];

        // each test image
        for (int di = 0; di < 10000; ++di)
        {
            for (int i = 0; i < 28; ++i)
            {
                for (int j = 0; j < 28; ++j)
                {
                    byte b = brImages.ReadByte();
                    pixels[i][j] = b;
                }
            }

            byte lbl = brLabels.ReadByte();

            DigitImage dImage = new DigitImage(pixels, lbl);
            Console.WriteLine(dImage.ToString());
            Console.ReadLine();
        } // each image

        ifsImages.Close();
        ifsLabels.Close();
        brImages.Close();
        brLabels.Close();

        Console.ReadKey();
    }

}

    public class DigitImage
    {
        public byte[][] pixels;
        public byte label;

        public DigitImage(byte[][] pixels,
          byte label)
        {
            this.pixels = new byte[28][];
            for (int i = 0; i < this.pixels.Length; ++i)
                this.pixels[i] = new byte[28];

            for (int i = 0; i < 28; ++i)
                for (int j = 0; j < 28; ++j)
                    this.pixels[i][j] = pixels[i][j];

            this.label = label;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < 28; ++i)
            {
                for (int j = 0; j < 28; ++j)
                {
                    if (this.pixels[i][j] == 0)
                        s += " "; // white
                    else if (this.pixels[i][j] == 255)
                        s += "#"; // black
                    else
                        s += "+"; // gray
                }
                s += "\n";
            }
            s += this.label.ToString();
            return s;
        } // ToString
    }
}
