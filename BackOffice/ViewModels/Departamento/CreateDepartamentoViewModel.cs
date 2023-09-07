using System.ComponentModel.DataAnnotations;

namespace BackOffice.ViewModels.User
{
    public class CreateDepartamentoViewModel
    {
        [Required]
        public string NomeDepartamento { get; set; }
        [Required]
        public string NomeResponsavel { get; set; }
    }
}