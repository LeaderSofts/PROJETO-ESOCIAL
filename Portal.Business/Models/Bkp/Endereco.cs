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
    public partial class Endereco
    {                
        [Display(Name = "Cep")]
        public string cep { get; set; }

        [Display(Name = "Endereço")]
        public string endereco { get; set; }

        [Display(Name = "Número")]
        public string numero { get; set; }

        [Display(Name = "Complemento")]
        public string complemento { get; set; }
        
        [Display(Name = "Bairro")]
        public string bairro { get; set; }

        [Display(Name = "Município")]
        public string municipio { get; set; }

        [Display(Name = "UF")]
        public string uf { get; set; }

        [Display(Name = "Código Município")]        
        public string cod_municipio { get; set; }

        [Display(Name = "Código UF")]
        public string cod_uf { get; set; }

    }
}
