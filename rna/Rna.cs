using System;
using System.Collections.Generic;
using System.Linq;
using Estudos.Rna.Interfaces.rna;

namespace Estudos.Rna.rna
{
    public class Rna : IRna
    {
        const double _numeroDeEuler = 2.718281;

        public double FuncaoDeAgregacao(double[] sinaisDeEntrada, double[] pesosSinapticos, double limiarDeAtivacao)
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

        public double FuncaoDeAtivacaoDegrau(double potencialDeAtivacao)
            => (potencialDeAtivacao >= 0) ? 1 : 0;

         public double FuncaoDeAtivacaoDegrauBipolar(double potencialDeAtivacao)
            => potencialDeAtivacao switch
                {
                    double x when x > 0 => 1,
                    double x when x == 0 => 0,
                    double x when x < 0 => -1,
                };

        public double FuncaoDeAtivacaoLogistica(double potencialDeAtivacao, double constanteDeInclinacao)
            => 1 / (1 + Math.Pow(_numeroDeEuler, -1 * constanteDeInclinacao * potencialDeAtivacao));

        public double FuncaoDeAtivacaoTangenteHiperbolica(double potencialDeAtivacao, double constanteDeInclinacao)
            => (1 - Math.Pow(_numeroDeEuler, -1 * constanteDeInclinacao * potencialDeAtivacao)) / (1 + Math.Pow(_numeroDeEuler, -1 * constanteDeInclinacao * potencialDeAtivacao));

        public double FuncaoDeAtivacaoGaussiana(double potencialDeAtivacao, double desvioPadrao, double centroDaFuncaoGaussiana)
            => Math.Pow(_numeroDeEuler, -1 * (Math.Sqrt(potencialDeAtivacao - centroDaFuncaoGaussiana) / 2 * Math.Sqrt(desvioPadrao)));

    }
}