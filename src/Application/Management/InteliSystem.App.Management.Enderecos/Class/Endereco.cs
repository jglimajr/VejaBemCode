using InteliSystem.Util.AbstractClass;

namespace InteliSystem.App.Management.Enderecos
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