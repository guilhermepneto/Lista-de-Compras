using ListaDeCompras.ConsoleApp.Compartilhado;
using ListaDeCompras.ConsoleApp.Modulos.ModulosItemListaCompras;

namespace ListaDeCompras.ConsoleApp.Modulos.ModulosListaDeCompras;

public static class GeradorIdsListaCompras
{
    private static int contadorIds = 1;

    public static int GerarId()
    {
        return contadorIds++;
    }
}

public enum StatusListaCompras
{
    Aberta,
    Concluída
}

public class ListaCompras : EntidadeBase
{

    public string Nome { get; private set; }
    public DateTime DataCriacao { get; private set; }
    public StatusListaCompras Status { get; private set; } = StatusListaCompras.Aberta;
    public ItemListaCompras[] Itens { get; private set; } = new ItemListaCompras[100];

    public ListaCompras(string nome)
    {
        Id = GeradorIdsListaCompras.GerarId();
        Nome = nome;
        DataCriacao = DateTime.Now;
    }

    public void AdicionarItem(ItemListaCompras itemLista)
    {
        for (int i = 0; i < Itens.Length; i++)
        {
            if (Itens[i] == null)
            {
                Itens[i] = itemLista;
                return;
            }
        }
    }

    public void RemoverItem(int idItemLista)
    {
        for (int i = 0; i < Itens.Length; i++)
        {
            if (Itens[i] == null)
                continue;

            if (Itens[i].Id == idItemLista)
            {
                Itens[i] = null;
                return;
            }
        }
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome))
            erros.Add("O campo \"Nome\" deve ser preenchido.");

        else if (Nome.Length < 3 || Nome.Length > 100)
            erros.Add("O campo \"Nome\" deve conter entre 3 e 100 caracteres.");

        return erros;
    }

    public override void Atualizar(EntidadeBase entidadeAtualizada)
    {
        ListaCompras listaAtualizada = (ListaCompras)entidadeAtualizada;

        Nome = listaAtualizada.Nome;
        Status = listaAtualizada.Status;
    }
}
