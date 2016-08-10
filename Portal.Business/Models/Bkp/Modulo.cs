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
    [Table("erp_modulo")]
    public class Modulo
    {
        [Key]
        [Display(Name = "Código do Módulo")]
        public int id_modulo { get; set; }

        [Display(Name = "Código do Módulo Pai")]
        [Required(ErrorMessage = "Código do Módulo Pai inválido.")]
        public int id_modulo_pai { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Descrição inválida.")]
        public string descricao { get; set; }

        [Display(Name = "Url")]
        [Required(ErrorMessage = "Url inválida.")]
        public string url { get; set; }

        [Display(Name = "Índice")]
        [Required(ErrorMessage = "Índice inválido.")]
        public int indice { get; set; }

        [Display(Name = "Ativo")]
        public bool ativo { get; set; } 
    }
}
