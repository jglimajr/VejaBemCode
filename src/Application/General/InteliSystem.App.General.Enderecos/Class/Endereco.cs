using InteliSystem.Util.AbstracClass;

namespace InteliSystem.App.General.Enderecos
{
    public class Endereco : ClassBase
    {
        public string Nome { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }
        public string Cep { get; set; }
    }
}