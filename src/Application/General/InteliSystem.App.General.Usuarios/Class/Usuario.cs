using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using InteliSystem.App.General.Pessoas;
using InteliSystem.Util.AbstractClass;

namespace InteliSystem.App.General.Usuarios
{
    public class Usuario : ClassBase
    {
        [JsonIgnore()]
        [StringLength(36, MinimumLength=36, ErrorMessage="{0} deve conter {1} caracteres")]
        public string PessoaId { get; set; }
        public Pessoa Pessoa { get; set; } 
        [DisplayName("Usuário")]
        [Required(ErrorMessage = "Ôps! Favor informar seu {0}")]
        [StringLength(50, MinimumLength=5, ErrorMessage="Seu {0} deve conter entre {2} à {1} caracteres")]
        public string UserName { get; set; }
        [Display(Name = "Senha")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Sua {0} deve conter entre {2} à {1} caracteres")]
        [RegularExpression(@"^(?=.*[a-z])(?=.[A-Z])(?=.*\d)(?=.[^\da-zA-Z]).{8, 20}$", ErrorMessage = "{0} no formato inválido")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
        [JsonIgnore]
        public string SenhaProvisoria { get; set; } = "N";
        [DisplayName("E-Mail")]
        [EmailAddress(ErrorMessage = "")]
        public string Email { get; set; }
        public short AcessoErro { get; set; }
        public string SocialToken { get; set; }
    }
}