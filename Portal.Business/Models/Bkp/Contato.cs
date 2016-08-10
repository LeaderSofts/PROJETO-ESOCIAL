using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Web.Security;
using MySql.Data.Entity;
using System.Data.Entity;
using System.Data.Common;

namespace Portal.Business.Models
{
    [Table("erp_contato")]
    public partial class Contato : Endereco
    {
        public enum TypeTipoDoc { Física = 1, Jurídica = 2 }

        public enum TypeCategoria { Contato = 1, Cliente = 2, Fornecedor = 3, Funcionário = 4 }

        [Key]
        public int id_contato { get; set; }

        [Display(Name = "Empresa")]
        [Required(ErrorMessage = "Empresa inválida.")]
        public int id_empresa { get; set; }

        [Display(Name = "Razão Social")]       
        public string razao_social { get; set; }

        [Display(Name = "Nome Fantasia")]
        [Required(ErrorMessage = "Nome Fantasia inválida.")]
        public string nome_fantasia { get; set; }

        [Display(Name = "Cnpj/Cpf")]
        public string cnpj_cpf { get; set; }
        
        [Display(Name = "Inscrição Estadual")]
        public string ie { get; set; }

        [Display(Name = "Inscrição Municipal")]
        public string im { get; set; }

        [Display(Name = "RG")]
        public string rg { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "Tipo inválido.")]
        public TypeTipoDoc tipo_doc { get; set; }

        [Display(Name = "Data de Abertura/Nascimento")]
        [DataType(DataType.Date, ErrorMessage = "Data de abertura/nascimento inválida.")]        
        public Nullable<DateTime> d_abertura_nascimento { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Endereço de e-mail inválido.")]
        [Required(ErrorMessage = "E-mail inválido.")]
        public string email { get; set; }

        [Display(Name = "Telefone")]
        public string tel { get; set; }

        [Display(Name = "Celular")]
        public string cel { get; set; }

        [Display(Name = "Ativo")]
        public bool ativo { get; set; }
        
        [Display(Name = "Data de Cadastro")]
        [DataType(DataType.DateTime, ErrorMessage="Data de cadastro inválida.")]
        public DateTime dh_cadastro { get; set; }

        [Display(Name = "Categoria")]
        [Required(ErrorMessage = "Categoria inválida.")]
        public TypeCategoria categoria { get; set; }
    }
}
