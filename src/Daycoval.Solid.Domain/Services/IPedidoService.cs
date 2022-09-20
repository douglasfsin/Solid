using Daycoval.Solid.Domain.Entidades;

namespace Daycoval.Solid.Domain.Services
{
    public interface IPedidoService
    {
        void EfetuarPedido(Carrinho carrinho, bool notificarClienteEmail,
           bool notificarClienteSms);
        void EntregarProdutos(Carrinho carrinho);

        void VerificarCarrinhoPago(Carrinho carrinho, EstoqueService estoque);
 
    }
}