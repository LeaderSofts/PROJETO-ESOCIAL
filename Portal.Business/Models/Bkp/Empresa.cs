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
    [Table("erp_empresa")]
    public partial class Empresa : Endereco
    {
        public enum TypeTipoDoc { Física = 1, Jurídica = 2 }

        public enum TypeCategoria { Contato = 1, Cliente = 2, Fornecedor = 3, Funcionário = 4 }

        [Key]
        public int id_empresa { get; set; }

        [Display(Name = "Razão Social")]       
        public string razao_social { get; set; }

        [Display(Name = "Nome Fantasia")]
        [Required(ErrorMessage = "Nome Fantasia inválida.")]
        public string nome_fantasia { get; set; }

        [Display(Name = "Cnpj")]
        public string cnpj { get; set; }
        
        [Display(Name = "Inscrição Estadual")]
        public string ie { get; set; }

        [Display(Name = "Data de Abertura")]
        [DataType(DataType.Date, ErrorMessage = "Data de abertura")]        
        public Nullable<DateTime> d_abertura { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Endereço de e-mail inválido.")]
        public string email { get; set; }

        [Display(Name = "Telefone 1")]
        public string tel1 { get; set; }

        [Display(Name = "Telefone 2")]
        public string tel2 { get; set; }

        [Display(Name = "Ativo")]
        public bool ativo { get; set; }
        
        [Display(Name = "Data de Cadastro")]
        [DataType(DataType.DateTime, ErrorMessage="Data de cadastro inválida.")]
        public DateTime dh_cadastro { get; set; }

        [Display(Name = "Logomarca da Empresa")]
        public string logomarca { get; set; }

    }
}
