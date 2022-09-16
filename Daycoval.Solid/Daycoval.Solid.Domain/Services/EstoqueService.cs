using Daycoval.Solid.Domain.Entidades;
using System.Runtime.InteropServices;

namespace Daycoval.Solid.Domain.Services
{
    public class EstoqueService : IEstoqueService
    {
        public void SolicitarProduto(Produto produto)
        {
            //Este método não precisa ser implementado.
        }

        public void BaixarEstoque(Produto produto)
        {
            //Este método não precisa ser implementado.
        }

        public void BaixarProdutosEstoque(Carrinho carrinho, EstoqueService estoque)
        {
            if (!carrinho.FoiEntregue)
                throw new ExternalException("Os produtos não foram entregues.");

            foreach (var produto in carrinho.Produtos)
            {
                estoque.BaixarEstoque(produto);
            }
        }
    }
}