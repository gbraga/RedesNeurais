namespace Estudos.Rna.Perceptron.Interfaces
{
    public interface INeuronio
    {
        /// <sumary>
        /// Calcula o que o neurônio deve responder.
        /// </sumary>
        /// <param name="x">Sinais de Entrada para a rede.</param>
        /// <param name="w">Pesos sinapticos para a rede.</param>
        /// <param name="f">Qual a função de ativação que o neurônio deve usar.</param>
        /// <returns>Um valor Y de resposta.</returns>
        double Exec(double[] sinaisEntrada, double[] pesosSinapticos, FuncaoAtivacao f);
    }
}