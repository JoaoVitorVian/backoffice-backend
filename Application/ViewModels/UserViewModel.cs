using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class UserViewModel
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


        public UserViewModel()
        { }

        public UserViewModel(long id, string name, string apelido, string localidade, string tipoPessoa, string documento, string cep, string bairro, string qualificacoes)
        {
            Id = id;
            Name = name;
            Apelido = apelido;
            Localidade = localidade;
            TipoDePessoa = tipoPessoa;
            Documento = documento;
            Cep = cep;
            Bairro = bairro;
            Qualificacoes = qualificacoes;
        }
    }
}
