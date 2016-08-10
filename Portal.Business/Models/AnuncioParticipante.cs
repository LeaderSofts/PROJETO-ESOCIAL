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

    [Table("anuncio_participante")]
    public class AnuncioParticipante
    {
        [Key]
        public Int64 id_anuncio_participante { get; set; }

        [Required]
        public Int32 id_usuario { get; set; }

        [Required]
        public Int32 id_time { get; set; }

        [Required]
        public Int64 id_anuncio { get; set; }

        [Required]
        public Int32 id_cartao_socio { get; set; }

        [Required]
        public DateTime dh_cad_anuncio_participante { get; set; }

        [Required]
        public string tipo_anuncio_participante { get; set; }

        [Required]
        [Display(Name = "Vencedor do Anúncio")]       
        public bool ganhador_anuncio_participante { get; set; }

        [Display(Name = "Observação do Anúncio")]
        public string obs_anuncio_participante { get; set; }   
    }
}