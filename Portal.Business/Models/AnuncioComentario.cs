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

    [Table("anuncio_comentario")]
    public class AnuncioComentario
    {
        [Key]
        public Int64 id_anuncio_comentario { get; set; }

        [Required]
        public Int32 id_usuario { get; set; }

        [Required]
        public Int32 id_time { get; set; }

        [Required]
        public Int64 id_anuncio { get; set; }

        [Required]
        public Int32 id_cartao_socio { get; set; }

        [Required]
        public DateTime dh_cad_anuncio_comentario { get; set; }

        [Required(ErrorMessage = "Comentário inválido.")]
        [Display(Name = "Comentário")]
        public string msg_anuncio_comentario { get; set; }      

    }
}