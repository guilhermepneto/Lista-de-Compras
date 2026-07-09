using ListaDeCompras.ConsoleApp.Compartilhado.Arquivos;

namespace ListaDeCompras.ConsoleApp.Compartilhado;

public abstract class RepositorioBase<TEntidade> where TEntidade : EntidadeBase
{
    protected readonly ContextoJson contexto;
    protected readonly List<TEntidade> registros;

    protected RepositorioBase(ContextoJson contexto)
    {
        this.contexto = contexto;
        registros = ObterRegistros();
    }

    protected abstract List<TEntidade> ObterRegistros();

    public void Cadastrar(TEntidade novoRegistro)
    {
        registros.Add(novoRegistro);
    }
    public bool Editar(int idSelecionado, TEntidade entidadeAtualizada)
    {
        TEntidade? entidadeSelecionada = SelecionarPorId(idSelecionado);

        if (entidadeSelecionada == null)
            return false;

        entidadeSelecionada.Atualizar(entidadeAtualizada);

        return true;
    }

    public bool Excluir(int idSelecionado)
    {
        TEntidade? registro = SelecionarPorId(idSelecionado);

        if (registro == null)
            return false;

        return registros.Remove(registro);
    }


    public TEntidade? SelecionarPorId(int idSelecionado)
    {
        foreach (TEntidade o in registros)
        {
            if (o.Id == idSelecionado)
                return o;
        }

        return null;
    }

    public List<TEntidade> SelecionarTodos()
    {
        return registros;
    }
}
