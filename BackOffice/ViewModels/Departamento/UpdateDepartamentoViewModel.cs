using System.ComponentModel.DataAnnotations;

namespace BackOffice.ViewModels.User
{
    public class UpdateDepartamentoViewModel
    {
        public long Id { get; set; }

        public string NomeDepartamento { get; set; }


        public string NomeResponsavel { get; set; }
    }
}