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

public enum UnidadeMedidaProduto
{
    Unidade,
    Caixa,
    Duzia,
    Kg,
    L,
    Ml,
    G
}

public class Produtos : EntidadeBase
{
    public string Nome { get; set; }
    public Categoria Categoria { get; set; }
    public int ValorUnidadeMedida { get; set; }
    public UnidadeMedidaProduto UnidadeMedida { get; set; } = UnidadeMedidaProduto.Unidade;
    public decimal PrecoAproximado { get; set; }

    public Produtos(
            string nome,
            Categoria categoria,
            int valorUnidadeMedida,
            UnidadeMedidaProduto unidadeMedida,
            decimal precoAproximado)
    {
        Id = GeradorIdsProduto.GerarId();

        Nome = nome;
        Categoria = categoria;
        ValorUnidadeMedida = valorUnidadeMedida;
        UnidadeMedida = unidadeMedida;
        PrecoAproximado = precoAproximado;
    }
    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome))
            erros.Add("O campo \"Nome\" deve ser preenchido.");

        else if (Nome.Length < 2 || Nome.Length > 100)
            erros.Add("O campo \"Nome\" deve conter entre 2 e 100 caracteres.");

        if (Categoria == null)
            erros.Add("O campo \"Categoria\" deve ser preenchido.");

        if (ValorUnidadeMedida == 0)
            erros.Add("O campo \"Valor da Unidade de Medida\" não pode conter o valor zero.");

        if (!Enum.IsDefined(UnidadeMedida))
            erros.Add("O campo \"Unidade de Medida\" deve conter uma seleção permitida (Unidade, Caixa, Dúzia, Kg, L, ml, g).");

        if (PrecoAproximado == 0)
            erros.Add("O campo \"Preço Aproximado\" não pode conter o valor zero.");

        return erros;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        Produtos produtoAtualizado = (Produtos)entidadeAtualizada;

        Nome = produtoAtualizado.Nome;
        Categoria = produtoAtualizado.Categoria;
        ValorUnidadeMedida = produtoAtualizado.ValorUnidadeMedida;
        UnidadeMedida = produtoAtualizado.UnidadeMedida;
        PrecoAproximado = produtoAtualizado.PrecoAproximado;
    }
}

