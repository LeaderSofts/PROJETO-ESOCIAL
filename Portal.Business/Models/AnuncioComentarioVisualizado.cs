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

    [Table("anuncio_comentario_visualizacao")]
    public class AnuncioComentarioVisualizacao
    {
        [Key]
        public Int64 id_visualizacao { get; set; }
        
        [Required]
        public Int32 id_usuario { get; set; }

        [Required]
        public Int32 id_usuario_vendedor { get; set; }

        [Required]
        public Int64 id_anuncio { get; set; }
              
        public bool msg_usuario_visualizada { get; set; }

        public Nullable<DateTime> dh_msg_usuario_visualizada { get; set; }

        public DateTime dh_msg_visualizada { get; set; }
    }
}