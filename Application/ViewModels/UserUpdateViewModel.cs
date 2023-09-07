namespace Application.ViewModels
{
    public class UserUpdateViewModel
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


        public UserUpdateViewModel()
        { }

        public UserUpdateViewModel(long id, string name, string apelido, string localidade, string cep, string bairro, string qualificacoes, string documento, string tipopessoa)
        {
            Id = id;
            Name = name;
            Apelido = apelido;
            Localidade = localidade;
            Cep = cep;
            Bairro = bairro;
            Qualificacoes = qualificacoes;
            Documento = documento;
            TipoDePessoa = tipopessoa;
        }
    }
}