using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.Modulos.ModulosCategoria;

namespace ListaDeCompras.ConsoleApp.Modulos.ModulosProdutos;

public class TelaProduto : TelaBase, ITelaOpcoes
{
    private readonly RepositorioProduto repositorioProduto;
    private readonly RepositorioCategoria repositorioCategoria;

    public TelaProduto(
        RepositorioProduto repositorioProduto,
        RepositorioCategoria repositorioCategoria) : base("Produto", repositorioProduto)
    {
        this.repositorioProduto = repositorioProduto;
        this.repositorioCategoria = repositorioCategoria;
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Visualização de Produtos");
            Console.WriteLine("---------------------------");
        }

        Console.WriteLine(
            "{0,-5} | {1,-20} | {2,-20} | {3,-10} | {4,-10}",
            "Id", "Nome", "Categoria", "Unidade", "Preço"
            );

        EntidadeBase[] registros = repositorioProduto.SelecionarTodos();

        foreach (EntidadeBase registro in registros)
        {
            Produtos p = (Produtos)registro;

            if (p == null)
                continue;

            Console.WriteLine(
                "{0,-5} | {1,-20} | {2,-20} | {3,-10} | {4,-10}",
                p.Id, p.Nome, p.Categoria.Nome, p.UnidadeMedida, p.PrecoAproximado
                );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Pressione ENTER para prosseguir.");
            Console.ReadLine();
        }
    }

    protected override EntidadeBase ObterDadosCadastrais()
    {
        Console.Write("Informe o nome do produto: ");
        string? nome = Console.ReadLine();

        Console.WriteLine("---------------------------------");

        VisualizarCategorias();

        Console.WriteLine("---------------------------------");

        Console.Write("Informe o ID da categoria do produto: ");
        int idCategoria = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("---------------------------------");

        Categoria? categoriaSelecionada =
            (Categoria?)repositorioCategoria.SelecionarPorId(idCategoria);

        Console.Write("Informe o valor/quantidade da unidade de medida do produto: ");
        int valorUnidadeMedida = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("---------------------------------");
        Console.WriteLine("Selecione uma unidade de medida disponível para o produto");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Unidade (Padrão)");
        Console.WriteLine("2 - Caixa");
        Console.WriteLine("3 - Duzia");
        Console.WriteLine("4 - Kg");
        Console.WriteLine("5 - L");
        Console.WriteLine("6 - Ml");
        Console.WriteLine("7 - G");
        Console.WriteLine("---------------------------------");
        Console.Write("Informe a unidade de medida escolhida: ");
        string? unidadeSelecionada = Console.ReadLine();

        UnidadeMedidaProduto unidadeMedida;

        switch (unidadeSelecionada)
        {
            case "1":
                unidadeMedida = UnidadeMedidaProduto.Unidade;
                break;

            case "2":
                unidadeMedida = UnidadeMedidaProduto.Caixa;
                break;

            case "3":
                unidadeMedida = UnidadeMedidaProduto.Duzia;
                break;

            case "4":
                unidadeMedida = UnidadeMedidaProduto.Kg;
                break;

            case "5":
                unidadeMedida = UnidadeMedidaProduto.L;
                break;

            case "6":
                unidadeMedida = UnidadeMedidaProduto.Ml;
                break;

            case "7":
                unidadeMedida = UnidadeMedidaProduto.G;
                break;

            default:
                unidadeMedida = UnidadeMedidaProduto.Unidade;
                break;
        }

        Console.Write("Informe o preço aproximado do produto: ");
        decimal precoAproximado = Convert.ToDecimal(Console.ReadLine());

        return new Produtos(
            nome!,
            categoriaSelecionada!,
            valorUnidadeMedida,
            unidadeMedida,
            precoAproximado);
    }

    private void VisualizarCategorias()
    {
        throw new NotImplementedException();
    }

    protected override bool ExisteRegistroComInformacoesExclusivas(EntidadeBase entidade, int? idIgnorado = null)
    {
        Produtos novoProduto = (Produtos)entidade;

        EntidadeBase[] produtos = repositorioProduto.SelecionarTodos();

        foreach (EntidadeBase registro in produtos)
        {
            Produtos p = (Produtos)registro;

            if (p == null)
                continue;

            if (
                p.Id != idIgnorado &&
                p.Nome == novoProduto.Nome &&
                p.Categoria.Id == novoProduto.Categoria.Id)
            {
                Console.WriteLine("Já existe um produto com esse nome nesta categoria.");

                return true;
            }
        }
        return false;
    }
}
