using ListaDeCompras.ConsoleApp.Modulos.ModulosProdutos;

namespace ListaDeCompras.ConsoleApp.Modulos.ModulosItemListaCompras;

public static class GeradorIdsItemListaCompras
{
    private static int contadorIds = 1;

    public static int GerarId()
    {
        return contadorIds++;
    }
}

public class ItemListaCompras
{
    public int Id { get; private set; }
    public Produtos Produto { get; private set; }
    public int Quantidade { get; private set; }

    public decimal PrecoTotal
    {
        get
        {
            return Produto.PrecoAproximado * Quantidade;
        }
    }

    public ItemListaCompras(Produto produto, int quantidade)
    {
        Id = GeradorIdsItemListaCompras.GerarId();
        Produto = produto;
        Quantidade = quantidade;
    }
}
