using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.Modulos.ModulosCategoria;

namespace ListaDeCompras.ConsoleApp.Modulos.ModulosProdutos;

public static class GeradorIdsProduto
{
    private static int contadorIds = 1;

    public static int GerarId()
    {
        return contadorIds++;
    }
}

public class Produtos : EntidadeBase
{
    public string Nome { get; private set; }
    public Categoria Categoria { get; private set; }
    public string UnidadeMedida { get; private set; }
    public decimal PrecoAproximado { get; private set; }

    public Produtos(
            string nome,
            Categoria categoria,
            string unidadeMedida,
            decimal precoAproximado)
    {
        Id = GeradorIdsProduto.GerarId();

        Nome = nome;
        Categoria = categoria;
        UnidadeMedida = unidadeMedida;
        PrecoAproximado = precoAproximado;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Produtos produtoAtualizado = (Produtos)entidadeAtualizada;

        Nome = produtoAtualizado.Nome;
        Categoria = produtoAtualizado.Categoria;
        UnidadeMedida = produtoAtualizado.UnidadeMedida;
        PrecoAproximado = produtoAtualizado.PrecoAproximado;
    }
}

