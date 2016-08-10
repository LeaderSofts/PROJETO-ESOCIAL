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
    public class ValidateUsuario
    {
        
        public Int32 id_usuario { get; set; }

        [Display(Name = "Usuário")]
        public string nome_usuario { get; set; }

        [Display(Name = "Campo")]
        public string campo { get; set; }

        [Display(Name = "Erro")]
        public string erro { get; set; }
    }
}