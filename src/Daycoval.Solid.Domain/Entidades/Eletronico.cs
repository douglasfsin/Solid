namespace Daycoval.Solid.Domain.Entidades
{
    public class Eletronico : Produto
    {
        public override void CalcularImposto() => ValorImposto = Valor * 0.15M;
    }

}