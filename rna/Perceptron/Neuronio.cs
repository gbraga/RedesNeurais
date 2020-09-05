using System;
using Estudos.Rna.Perceptron.Interfaces;

namespace Estudos.Rna.Perceptron
{
    public class Neuronio : INeuronio
    {
        private const double _numeroDeEuler = 2.718281;
        private readonly double limiarDeAtivacao;
        private readonly double? constanteDeInclinacao;
        private readonly double? desvioPadrao;
        private readonly double? centroDaFuncaoGaussiana;

        public Neuronio(double limiarDeAtivacao, double? constanteDeInclinacao = null, double? desvioPadrao = null, double? centroDaFuncaoGaussiana = null)
        {
            this.limiarDeAtivacao = limiarDeAtivacao;
            this.constanteDeInclinacao = constanteDeInclinacao;
            this.desvioPadrao = desvioPadrao;
            this.centroDaFuncaoGaussiana = centroDaFuncaoGaussiana;
        }

        /// <sumary>
        /// Calcula o que o neurônio deve responder.
        /// </sumary>
        /// <param name="x">Sinais de Entrada para a rede.</param>
        /// <param name="w">Pesos sinapticos para a rede.</param>
        /// <param name="f">Qual a função de ativação que o neurônio deve usar.</param>
        /// <returns>Um valor Y de resposta.</returns>
        public double Exec(double[] x, double[] w, FuncaoAtivacao f)
        {
            var u = FuncaoDeAgregacao(x, w);
            var y = f switch
            {
                FuncaoAtivacao.Degrau => FuncaoDeAtivacaoDegrau(u),
                FuncaoAtivacao.DegrauBipolar => FuncaoDeAtivacaoDegrauBipolar(u),
                FuncaoAtivacao.Gaussiana => FuncaoDeAtivacaoGaussiana(u),
                FuncaoAtivacao.TangenteHiperbolica => FuncaoDeAtivacaoTangenteHiperbolica(u),
                FuncaoAtivacao.Logistica => FuncaoDeAtivacaoLogistica(u),
            };

            return y;
        }

        private double FuncaoDeAgregacao(double[] sinaisDeEntrada, double[] pesosSinapticos)
        {
            if (sinaisDeEntrada.Length != pesosSinapticos.Length) throw new InvalidOperationException();

            double potencialDeAtivacao = 0;
            int n = sinaisDeEntrada.Length;

            for (int i = 0; i < n; i++)
            {
                potencialDeAtivacao += sinaisDeEntrada[i] * pesosSinapticos[i];
            }

            return potencialDeAtivacao - limiarDeAtivacao;
        }

        private double FuncaoDeAtivacaoDegrau(double potencialDeAtivacao)
            => (potencialDeAtivacao >= 0) ? 1 : 0;

        private double FuncaoDeAtivacaoDegrauBipolar(double potencialDeAtivacao)
            => potencialDeAtivacao switch
                {
                    double x when x > 0 => 1,
                    double x when x == 0 => 0,
                    double x when x < 0 => -1,
                };

        private double FuncaoDeAtivacaoLogistica(double potencialDeAtivacao)
        {
            var c = constanteDeInclinacao ?? throw new ArgumentNullException("constanteDeInclinacao");

            return 1 / (1 + Math.Pow(_numeroDeEuler, -1 * c * potencialDeAtivacao));
        }

        private double FuncaoDeAtivacaoTangenteHiperbolica(double potencialDeAtivacao)
        {
            var c = constanteDeInclinacao ?? throw new ArgumentNullException("constanteDeInclinacao");

            return (1 - Math.Pow(_numeroDeEuler, -1 * c * potencialDeAtivacao)) / (1 + Math.Pow(_numeroDeEuler, -1 * c * potencialDeAtivacao));
        }

        private double FuncaoDeAtivacaoGaussiana(double potencialDeAtivacao)
        {
            var c = centroDaFuncaoGaussiana ?? throw new ArgumentNullException("centroDaFuncaoGaussiana");
            var d = desvioPadrao ?? throw new ArgumentNullException("desvioPadrao");

            return Math.Pow(_numeroDeEuler, -1 * (Math.Sqrt(potencialDeAtivacao - c) / 2 * Math.Sqrt(d)));
        }
    }
}