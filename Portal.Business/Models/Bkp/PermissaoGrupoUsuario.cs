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
    [Table("erp_permissao_grupo_usuario")]
    public class PermissaoGrupoUsuario
    {
        [Key]
        public int id_permissao_grupo_usuario { get; set; }
        public int id_modulo { get; set; }
        public int id_grupo_usuario { get; set; }
    }

    [NotMapped]
    public class PermissaoGrupoUsuarioAux : PermissaoGrupoUsuario
    {        
        public string descricao_modulo { get; set; }
        public bool permitido
        {
            get
            {
                return (id_permissao_grupo_usuario > 0);
            }
        }
    }

}
