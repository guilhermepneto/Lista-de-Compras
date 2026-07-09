using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.Compartilhado.Arquivos;
using ListaDeCompras.ConsoleApp.Modulos.ModulosCategoria;

namespace ListaDeCompras.ConsoleApp.Modulos;

public class RepositorioCategoria : RepositorioBase<Categoria>
{
    public RepositorioCategoria(ContextoJson contexto) : base(contexto)
    {
    }

    protected override List<Categoria> ObterRegistros()
    {
        return contexto.Categorias;
    }
}
