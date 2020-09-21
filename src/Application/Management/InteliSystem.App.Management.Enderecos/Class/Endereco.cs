using System.ComponentModel.DataAnnotations;
using InteliSystem.Util.AbstractClass;
using InteliSystem.Util.Extentions;

namespace InteliSystem.App.Management.Enderecos
{
    public class Endereco : ClassBase
    {
        public string Nome { get; set; }
        [Display(Name = "Endereço")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "{0} deve conter entre {2} à {1} caracteres")]
        public string Logradouro { get; set; }
        [Display(Name = "Número")]
        [RegularExpression(@"^(?=.[0-9]).{0, 5}")]
        public string Numero { get; set; }
        public string Complemento { get; set; }
        [Display(Name = "Bairro")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "{0} deve conter entre {2} à {1} caracteres")]
        [Required(ErrorMessage = "Favor informar o {0}")]
        public string Bairro { get; set; }
        [Display(Name = "Cidade")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "{0} deve conter entre {2} à {1} caracteres")]
        [Required(ErrorMessage = "Favor informar a {0}")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Favor informar a {0}")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "A {0} deve conter {1}")]
        public string Uf { get; set; }
        [Required(ErrorMessage = "Favor informar o {0}")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "O {0} deve conter {1}")]
        [RegularExpression(@"^\d{2}.\d{3}-\d{3}$", ErrorMessage = "{0} com formato inválido")]
        public string Cep { get; set; }

        public override string ToString()
        {
            return $"{Logradouro}, {(Numero.IsEmpty() ? "S/N" : Numero)}";
        }
    }
}