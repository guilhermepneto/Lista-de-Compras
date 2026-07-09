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
    public string Nome { get; set; }
    public CorCategoria Cor { get; set; }

    public Categoria(string v)
    {
    }

    public Categoria(string v, CorCategoria cor) : this(v)
    {
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome))
            erros.Add("O campo \"Nome\" precisa ser preenchido.");

        else if (Nome.Length > 50)
            erros.Add("O campo \"Nome\" pode conter no máximo 50 caracteres.");

        if (!Enum.IsDefined(Cor))
            erros.Add("O campo \"Cor\" deve conter uma seleção permitida (Branco, Vermelho, Verde, Azul).");

        return erros;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Categoria categoriaAtualizada = (Categoria)entidadeAtualizada;

        Nome = categoriaAtualizada.Nome;
        Cor = categoriaAtualizada.Cor;
    }
}
