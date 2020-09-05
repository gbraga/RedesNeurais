using FANNCSharp.Double;
using System;
using System.Collections;
using System.Collections.Generic;

namespace rna.fann
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Create DataSet

            double[][] inputs =
            {
                new double[] { 1.0, 0.0 },
                new double[] { 0.0, 1.0 }
            };

            double[][] outpus =
            {
                new double[] { 1.0 },
                new double[] { 0.0 }
            };

            #endregion

            #region Create the Network

            IList<uint> layers = new List<uint>();
            layers.Add(2); // inputs entrando em pares
            layers.Add(3); // camada oculta... poderia ser qualquer número, mas entramos com um número maior que a camada de entrada
            layers.Add(1); // output é um único número

            NeuralNet network = new NeuralNet(FANNCSharp.NetworkType.LAYER, layers);
            #endregion

            #region Train the Network

            TrainingData data = new TrainingData();
            data.SetTrainData(inputs, outpus);

            network.TrainOnData(data, 3000, 100, 0.001f);

            Console.WriteLine($"Final Error: {network.MSE}");
            #endregion

            #region Test

            double[] test = new double[] { 0.2, 0.8 };
            double[] test2 = new double[] { 0.9, 0.3 };

            double[] result = network.Run(test);
            double[] result2 = network.Run(test2);

            Console.WriteLine($"Output1: {result[0]}");
            Console.WriteLine($"Output2: {result2[0]}");
            #endregion
        }
    }
}
