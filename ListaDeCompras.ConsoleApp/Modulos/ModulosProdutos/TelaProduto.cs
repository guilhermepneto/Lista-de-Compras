using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.Modulos;
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
            Produto p = (Produto)registro;

            if (p == null)
                continue;

            Console.WriteLine(
                "{0,-5} | {1,-20} | {2,-20} | {3,-10} | {4,-10}",
                p.Id, p.Nome, p.Categoria.Nome, p.UnidadeMedida, p.PrecoAproximado
                );
        }

        if (deveExibirCabecalho)
        {
            Console.ReadLine();
        }
    }

    protected override EntidadeBase ObterDadosCadastrais()
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine()!;

        Console.Write("Unidade de medida: ");
        string unidade = Console.ReadLine()!;

        Console.Write("Preço aproximado: ");
        decimal preco = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine();
        Console.WriteLine("Categorias:");

        EntidadeBase[] categorias = repositorioCategoria.SelecionarTodos();

        foreach (EntidadeBase registro in categorias)
        {
            Categoria c = (Categoria)registro;

            if (c == null)
                continue;

            Console.WriteLine($"{c.Id} - {c.Nome}");
        }

        Console.Write("Id da categoria: ");
        int idCategoria = Convert.ToInt32(Console.ReadLine());

        Categoria categoria = (Categoria)repositorioCategoria.SelecionarPorId(idCategoria)!;

        return new Produto(nome, categoria, unidade, preco);
    }

    protected override bool ExisteRegistroComInformacoesExclusivas(EntidadeBase entidade, int? idIgnorado = null)
    {
        Produto novoProduto = (Produto)entidade;

        EntidadeBase[] produtos = repositorioProduto.SelecionarTodos();

        foreach (EntidadeBase registro in produtos)
        {
            Produto p = (Produto)registro;

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
