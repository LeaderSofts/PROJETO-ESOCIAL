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

    [Table("time")]
    public class Time
    {
        [Key]
        public Int32 id_time { get; set; }
           
        [Required]     
        public DateTime dh_cad_time { get; set; }

        [Display(Name = "Nome Completo")]
        [Required(ErrorMessage = "Nome Completo inválido.")]
        public string nome_time_completo { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome inválido.")]
        public string nome_time { get; set; }

        [Display(Name = "Descrição")]
        public string descricao_time { get; set; }

        [Required(ErrorMessage = "Escudo inválido.")]
        [Display(Name = "Escudo")]
        public string escudo_time { get; set; }

        [Required(ErrorMessage = "Status do Time inválido.")]
        [Display(Name = "Status do Time")]
        public bool ativo_time { get; set; }

        [Display(Name = "Data da Fundação")]
        [DisplayFormat(DataFormatString="{0:dd/MM/yyyy}", NullDisplayText="Não disponível")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> d_fundacao_time { get; set; }

        [Display(Name = "Mascote")]
        public string nome_mascote_time { get; set; }

        [Display(Name = "Foto")]
        public string foto_mascote_time { get; set; }

        [Required(ErrorMessage = "Cidade inválido.")]
        [Display(Name = "Cidade")]
        public string cidade_time { get; set; }

        [Required(ErrorMessage = "Estado inválido.")]
        [Display(Name = "Estado")]
        public string uf_time { get; set; }        

    }
}