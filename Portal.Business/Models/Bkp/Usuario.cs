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

    [Table("erp_usuario")]
    public partial class Usuario
    {
        public enum TypeUser { SUPERADMIN = 0, ADMIN = 1, USER = 2 }

        [Key]
        public int id_usuario { get; set; }

        [Display(Name = "Empresa")]
        public Int32 id_empresa { get; set; }

        [Display(Name = "Grupo de Usuário")]
        [Required(ErrorMessage = "Grupo de Usuário inválido.")]
        public Int32 id_grupo_usuario { get; set; }

        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Endereço de e-mail inválido.")]
        [Required(ErrorMessage = "E-mail inválido.")]
        public string login { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Senha inválida.")]
        public string senha { get; set; }
        
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome inválido.")]
        public string nome { get; set; }

        [Display(Name = "Ativo")]
        public bool ativo { get; set; }

        [Display(Name = "Perfil")]
        public TypeUser tipo_usuario { get; set; }

        [Display(Name = "Data de Cadastro")]
        [DataType(DataType.DateTime, ErrorMessage = "Data de cadastro inválida.")]
        public DateTime dh_cadastro { get; set; }
        
        [Display(Name = "Último Acesso")]
        [DataType(DataType.DateTime, ErrorMessage = "Data de último acesso inválida.")]
        public Nullable<DateTime> dh_ultimoAcesso { get; set; }
    }
}
