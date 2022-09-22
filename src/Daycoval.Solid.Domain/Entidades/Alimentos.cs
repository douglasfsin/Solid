namespace Daycoval.Solid.Domain.Entidades
{
    public class Alimentos : Produto
    {
        public override void CalcularImposto() => ValorImposto = Valor * 0.05M;
    }

}