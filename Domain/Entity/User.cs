using Core.Exceptions;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Text;
using Validators;

namespace Domain.Entity
{
    public class User : Base
    {
        public string TipoDePessoa { get;  set; }

        public string Documento { get;  set; }

        public string Name { get;  set; }

        public string Apelido { get;  set; }

        public string Localidade { get;  set; }

        public string Bairro { get;  set; }

        public string Cep { get;  set; }

        public string Qualificacoes { get;  set; }

        public DateTime DataAtualizacao { get; set; }

        public User() { }

        public User(string name, string apelido, string localidade, string tipoDePessoa, string documento, string qualificacoes, string bairro, string cep)
        {
            Name = name;
            Apelido = apelido;
            Localidade = localidade;
            TipoDePessoa = tipoDePessoa;
            Bairro = bairro;
            Documento = documento;
            Qualificacoes = qualificacoes;
            Cep = cep;
            _errors = new List<string>();
        }

        public override bool Validate()
        {
            var validator = new UserValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new DomainExceptions("Alguns campos estão invalidos, corrija-os", _errors);
            }

            DataAtualizacao = DateTime.Now;
            return true;
        }
    }
}