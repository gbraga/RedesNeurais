namespace Estudos.Rna.Interfaces.rna
{
    public interface IRna
    {
        double FuncaoDeAgregacao(double[] sinaisEntrada, double[] pesosSinapticos, double limiarAtivacao);
    }
}