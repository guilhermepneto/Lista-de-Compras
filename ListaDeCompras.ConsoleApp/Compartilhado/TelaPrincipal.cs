using ListaDeCompras.ConsoleApp.Modulos;
using ListaDeCompras.ConsoleApp.Modulos.ModulosCategoria;

namespace ListaDeCompras.ConsoleApp.Compartilhado;

public class TelaPrincipal
{
    private readonly RepositorioCategoria repositorioCategoria;

    public TelaPrincipal()
    {
        Categoria categoriaTeste = new Categoria("Produtos de Limpeza", CorCategoria.Vermelho);

        repositorioCategoria = new RepositorioCategoria();
        repositorioCategoria.Cadastrar(categoriaTeste);
    }
    public ITelaOpcoes? ObterOpcaoMenuPrincipal()
    {
        Console.Clear();
        Console.WriteLine("---------------------------");
        Console.WriteLine("Lista de Compras");
        Console.WriteLine("---------------------------");
        Console.WriteLine("1 - Gerenciar categorias");
        Console.WriteLine("2 - Gerenciar produtos");
        Console.WriteLine("3 - Gerenciar lista de compras");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------");
        Console.Write("> ");

        string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

        if (opcaoMenuPrincipal == "1")
            return new TelaCategoria(repositorioCategoria);

        if (opcaoMenuPrincipal == "2")
            return null;

        if (opcaoMenuPrincipal == "3")
            return null;

        return null;
    }
}