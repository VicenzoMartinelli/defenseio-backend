using System.Collections.Generic;

namespace DefenseIO.Infra.Shared.ViewModels
{
  public class PaginatedResultViewModel<T>
  {
    public ICollection<T> Itens { get; set; }
    public int Page { get; set; }
    public int ItensPerPage { get; set; }
    public int Total { get; set; }

    public PaginatedResultViewModel(ICollection<T> itens, int pagina, int itensPorPagina, int total)
    {
      Itens = itens;
      Page = pagina;
      ItensPerPage = itensPorPagina;
      Total = total;
    }
  }
}
