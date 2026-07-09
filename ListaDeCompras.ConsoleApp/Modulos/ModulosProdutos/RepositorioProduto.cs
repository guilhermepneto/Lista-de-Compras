using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.Compartilhado.Arquivos;

namespace ListaDeCompras.ConsoleApp.Modulos.ModulosProdutos;

public class RepositorioProduto : RepositorioBase<Produtos>
{
    public RepositorioProduto(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Produtos> ObterRegistros()
    {
        return contexto.Produtos;
    }
}

