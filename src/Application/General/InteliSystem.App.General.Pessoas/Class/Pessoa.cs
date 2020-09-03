using System;
using System.ComponentModel.DataAnnotations;
using InteliSystem.App.General.Enderecos;
using InteliSystem.Util.AbstracClass;
using InteliSystem.Util.Enums;

namespace InteliSystem.App.General.Pessoas
{
    public class Pessoa : ClassBase
    {
        [Display(Name="Código")]
        public override string Id
        {
            get => base.Id;
            set => base.Id = value;
        }
        public string EnderecoId { get; set; } 
        public Endereco Endereco { get; set; }
        [Display(Name="Cpf")]
        [Required(ErrorMessage="{0} Não informado")]
        public string Cpf { get; set; }
        [Display(Name="Nome")]
        [Required(ErrorMessage="{0} não informado")]
        [StringLength(100, MinimumLength= 5, ErrorMessage="O {0} deve ter entre {2} e {1} caracteres")]
        public string Nome { get; set; }
        [Display(Name="Apelido")]
        [StringLength(100, MinimumLength= 5, ErrorMessage="O {0} deve ter entre {2} e {1} caracteres")]
        public string NomeCurto { get; set; }
        [Display(Name="Sexo")]
        [Required(ErrorMessage="{0} não informado")]
        public Sexo Sexo { get; set; }
        [Display(Name="Estado Civil")]
        public EstadoCivil EstadoCivil { get; set; }
        [Display(Name="Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
    }
}