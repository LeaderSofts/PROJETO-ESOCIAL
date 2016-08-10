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
    [Table("erp_grupo_usuario")]
    public class GrupoUsuario
    {
        [Key]
        public int id_grupo_usuario { get; set; }
        public string descricao { get; set; }
        public Usuario.TypeUser perfil { get; set; }
        public Nullable<int> id_empresa { get; set; }
    }
}
