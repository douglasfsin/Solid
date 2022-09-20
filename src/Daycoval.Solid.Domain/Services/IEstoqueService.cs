using Daycoval.Solid.Domain.Entidades;

namespace Daycoval.Solid.Domain.Services
{
    public interface IEstoqueService
    {
        void SolicitarProduto(Produto produto);
        void BaixarEstoque(Produto produto);
        void BaixarProdutosEstoque(Carrinho carrinho, EstoqueService estoque);
    }
}