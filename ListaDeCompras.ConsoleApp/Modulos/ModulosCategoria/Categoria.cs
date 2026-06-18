using ListaDeCompras.ConsoleApp.Compartilhado;

namespace ListaDeCompras.ConsoleApp.Modulos.ModulosCategoria;

public static class GeradorIdsCategoria
{
    private static int contadorIds = 1;

    public static int Gerarid()
    {
        return contadorIds++;
    }
}

public enum CorCategoria
{
    Branco,
    Vermelho,
    Verde,
    Azul
}

public class Categoria : EntidadeBase
{
    public string Nome { get; private set }
    public CorCategoria Cor { get; private set; }

    public Categoria(string nome, CorCategoria cor)
    {
        Id = GeradorIdsCategoria.Gerarid();

        Nome = nome;
        Cor = cor;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Categoria categoriaAtualizada = (Categoria)entidadeAtualizada;

        Nome = categoriaAtualizada.Nome;
        Cor = categoriaAtualizada.Cor;
    }
}
