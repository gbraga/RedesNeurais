using System;
using Estudos.Rna;
using Estudos.Rna.Interfaces.rna;
using Estudos.Rna.Perceptron;
using Estudos.Rna.Perceptron.Interfaces;
using Estudos.Rna.rna;

namespace rna
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---");
            Console.WriteLine("Introdução a rede neural");
            Console.WriteLine();
            Console.WriteLine("Inserindo sinais de entrada = [3, 5, 6.1, 8.3, 6, 2.2, 0.1]");
            var sinaisDeEntrada = new double[] { 3, 5, 6.1, 8.3, 6, 2.2, 0.1 };

            Console.WriteLine();
            Console.WriteLine("Inserindo peso sinapticos = [1, 2, 5, 1.3, 2, 4, 0.6]");
            var pesosSinapticos = new double[] { 1, 2, 5, 1.3, 2, 4, 0.6 };

            Console.WriteLine();
            Console.WriteLine("Definindo limiar de ativação = 3.4.");
            var limiarDeAtivacao = 3.4;

            Console.WriteLine();
            Console.WriteLine("Calculando função de agregação.");
            INeuronio neuro = new Neuronio(limiarDeAtivacao);
            var resultado = neuro.Exec(sinaisDeEntrada, pesosSinapticos, FuncaoAtivacao.Degrau);

            Console.WriteLine();
            Console.WriteLine("Calculando...");
            Console.WriteLine($"É igual a {resultado}.");
            Console.WriteLine("---");
        }

        public static void Intro()
        {
            Console.WriteLine("---");
            Console.WriteLine("Introdução a rede neural");
            Console.WriteLine();
            Console.WriteLine("Inserindo sinais de entrada = [3, 5, 6.1, 8.3, 6, 2.2, 0.1]");
            var sinaisDeEntrada = new double[] { 3, 5, 6.1, 8.3, 6, 2.2, 0.1 };

            Console.WriteLine();
            Console.WriteLine("Inserindo peso sinapticos = [1, 2, 5, 1.3, 2, 4, 0.6]");
            var pesosSinapticos = new double[] { 1, 2, 5, 1.3, 2, 4, 0.6 };

            Console.WriteLine();
            Console.WriteLine("Definindo limiar de ativação = 3.4.");
            var limiarDeAtivacao = 3.4;

            Console.WriteLine();
            Console.WriteLine("Calculando função de agregação.");
            IRna rna = new Rna();
            var potencialDeAtivacao = rna.FuncaoDeAgregacao(sinaisDeEntrada, pesosSinapticos, limiarDeAtivacao);

            Console.WriteLine();
            Console.WriteLine("Calculando função de agregação.");
            Console.WriteLine($"O potencial de ativação é igual a {potencialDeAtivacao}.");
            Console.WriteLine("---");
        }
    }
}
