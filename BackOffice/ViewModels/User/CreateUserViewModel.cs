using System.ComponentModel.DataAnnotations;

namespace BackOffice.ViewModels.User
{
  public class CreateUserViewModel
  {
    [Required]
    public string Name { get; set; }
 
    public string Apelido { get; set; }

    [Required]
    public string Cep { get; set; }

    [Required]
    public string Localidade { get; set; }

    [Required]
    public string Bairro { get; set; }

    [Required]
    public string TipoDePessoa { get; set; }

    [Required]
    public string Documento { get; set; }

    [Required]
    public string Qualificacoes { get; set; }
  }
}