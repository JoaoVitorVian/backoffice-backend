using System.Runtime.ConstrainedExecution;

namespace Application.ViewModels
{
    public class DepartamentoViewModel
    {
        public long Id { get; set; }

        public string NomeDepartamento { get; set; }

        public string NomeResponsavel { get; set; }

        public DepartamentoViewModel()
        { }

        public DepartamentoViewModel(long id, string nomeDepartamento, string nomeResponsavel)
        {
            Id = id;
            NomeDepartamento = nomeDepartamento;
            NomeResponsavel = nomeResponsavel;
        }
    }
}
