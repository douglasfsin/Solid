using Daycoval.Solid.Domain.Entidades;
using System;
using System.Collections.Generic;
using Xunit;

namespace Daycoval.Solid.Test
{
    public class ProdutoTests
    {

        [Fact]
        public void Produto_Valido_CamposPreenchidos()
        {
            // Arrange 
            var produto = new Alimentos();
            produto.Descricao = "Produto 1";
            produto.Quantidade = 1;
            produto.Valor = 10;

            // Act & Assert
            Assert.Equal(true, produto.Valido());
        }

        [Fact]
        public void Produto_Valido_CamposNaoPreenchidos()
        {
            // Arrange 
            var produto = new Superfulos();
            produto.Descricao = "Produto 1";

            // Act & Assert
            Assert.Equal(false, produto.Valido());
        }

        [Theory]
        [InlineData("Produto salgadinho", TipoProduto.Superfulos, 2, 12, 2.40)]
        [InlineData("Produto Arroz", TipoProduto.Alimentos, 4, 15, 0.75)]
        [InlineData("Produto Pilha", TipoProduto.Eletronico, 6, 7, 1.05)]
        public void Produto_CalcularImposto_CalcularImpostoCorretamente(string Descricao, TipoProduto tipoProduto, int quantidade, int valor, decimal resultado)
        {
            // Arrange 
            var produto = new Alimentos();
            produto.Descricao = Descricao;
            produto.TipoProduto = tipoProduto;
            produto.Quantidade = quantidade;
            produto.Valor = valor;

            // Act 
            produto.CalcularImposto();

            // Assert
            Assert.Equal(resultado, produto.ValorImposto);

        }

        public void Produtos_CalcularImposto_CalcularImpostoCorretamente(string Descricao, TipoProduto tipoProduto, int quantidade, int valor, decimal resultado)
        {
            // Arrange 
            var produto = new Alimentos();
            produto.Descricao = Descricao;
            produto.TipoProduto = tipoProduto;
            produto.Quantidade = quantidade;
            produto.Valor = valor;

            // Act 
            produto.CalcularImposto();

            // Assert
            Assert.Equal(resultado, produto.ValorImposto);

        }
    }
}
