namespace Daycoval.Solid.Domain.Entidades
{
    public class Superfulos : Produto
    {
        public override void CalcularImposto() => ValorImposto = Valor * 0.20M;
    }

}