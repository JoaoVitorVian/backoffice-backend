using System.ComponentModel.DataAnnotations;

namespace BackOffice.ViewModels.User
{
    public class UpdateUserViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Apelido { get; set; }

        public string Cep { get; set; }

        public string Localidade { get; set; }

        public string Bairro { get; set; }

        public string TipoDePessoa { get; set; }

        public string Documento { get; set; }

        public string Qualificacoes { get; set; }
    }
}