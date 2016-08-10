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
    
    [Table("avaliacao")]
    public class Avaliacao
    {
        public enum TypeSinalizacaoAvaliacao { Avaliar = 0, Ruim = 1, Regular = 2, Bom = 3, Otimo = 4, Excelente = 5 }

        [Key]
        public Int64 id_avaliacao { get; set; }

        [Required]
        public Int64 id_anuncio { get; set; }        

        [Required]
        public Int32 id_usuario_avaliador { get; set; }        

        [Required]
        public Int32 id_usuario_avaliado { get; set; }        

        [Required]
        public DateTime dh_cad_avaliacao { get; set; }

        [Required(ErrorMessage = "Avaliação inválida.")]
        [Display(Name = "Avaliação")]
        [Range(1, 5, ErrorMessage = "Avaliação inválida.")]
        public TypeSinalizacaoAvaliacao sinalizar_avaliacao { get; set; }

        [Required(ErrorMessage = "Comentário inválido.")]
        [Display(Name = "Comentário")]
        public string comentario_avaliacao{ get; set; }        
    }
}