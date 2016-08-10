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

    [Table("v_eSocial")]
    public class eSocial
    {

        [Key]
        public string codigo { get; set; }

        //TRABALHADOR
        public string chapa { get; set; }

        public string codcoligada { get; set; }

        public string cpf { get; set; }

        public string pispasep { get; set; }

        public string nome { get; set; }

        public string sexo { get; set; }

        public string corraca { get; set; }

        public string estadocivil { get; set; }

        public string grau_instrucao { get; set; }

        // //NASCIMENTO TRABALHADOR

        public Nullable<DateTime> data_nascimento { get; set; }

        public string cod_municipio { get; set; }

        public string cod_estado { get; set; }

        //public string cod_pais_Nascto { get; set; }

        public Nullable<Int32> cod_pais { get; set; }

        public string nmMae { get; set; }

        public string nmPai { get; set; }

        // //DOCUMENTOS TRABALHADOR

        public string cart_trab { get; set; }

        public string serie_cart_trab { get; set; }

        public string ufcarttrab { get; set; }

        public string numeroric { get; set; }

        public string orgemissorric { get; set; }

        public Nullable<DateTime> dtemissaoric { get; set; }

        public string rg { get; set; }

        public string orgemissorident { get; set; }

        public Nullable<DateTime> data_em_ident { get; set; }

        public string nroreggeral { get; set; }

        public string orgemissorrne { get; set; }

        public Nullable<DateTime> dtemissaorne { get; set; }

        public string nrOc { get; set; }

        public string orgaoEmissorOc { get; set; }

        public Nullable<DateTime> dtExpedicaoOc { get; set; }

        public Nullable<DateTime> dtValidOc { get; set; }

        public string nrRegCnh { get; set; }

        public Nullable<DateTime> dtExpCnh { get; set; }

        public string ufCnh { get; set; }

        public Nullable<DateTime> dtValidCnh { get; set; }

        public Nullable<DateTime> dtPriHab { get; set; }

        public string categoriaCnh { get; set; }

        //ENDEREÇO TRABALHADOR BRASIL

        public Nullable<Int32> tpLograd { get; set; }

        public string desLograd { get; set; }

        public string nrLograd { get; set; }

        public string complemento { get; set; }

        public string bairro { get; set; }

        public string cep { get; set; }

        public string codMunicipio { get; set; }

        public string uf { get; set; }

        //ENDEREÇO EXTERIOR TRABALHADOR

        public string paisResidExt { get; set; }

        public string desLogradExt { get; set; }

        public string nrLogradExt { get; set; }

        public string complementoExt { get; set; }

        public string bairroExt { get; set; }

        public string nmCidExt { get; set; }

        public string codPostalExt { get; set; }

        //TRABALHADOR ESTRANGEIRO

        public Nullable<DateTime> dtChegadaEstrang { get; set; }

        public Int16 classTrabaEstrang { get; set; }

        public string casadoBrEstrang { get; set; }

        public string filhosBrEstrang { get; set; }

        //INFORMAÇÕES DEFICIENCIA TRABALHADOR

        public string defFisico { get; set; }

        public string defVisual { get; set; }

        public string defAuditivo { get; set; }

        public string defMental { get; set; }

        public string defIntelectual { get; set; }

        public string reabReadap { get; set; }

        public string observacao { get; set; }

        //DEPENDENTE TRABALHADOR

        public string tpDep { get; set; }

        public string nmDep { get; set; }

        public Nullable<DateTime> dtNascto { get; set; }

        public string cpfDep { get; set; }

        public string depIRRF { get; set; }

        public string depSF { get; set; }

        //APOSENTADORIA TRABALHADOR
        public string trabAposent { get; set; }

        //CONTATOS TRABALHADOR

        public string fonePrinc { get; set; }

        public string foneAlternat { get; set; }

        public string emailPrinc { get; set; }

        public string emailAlternat { get; set; }

        //VÍNCULO TRABALHADOR

        public string matricula { get; set; }

        public Nullable<Int32> tpRegTrab { get; set; }

        public Int32 tpRegPrev { get; set; }

        //REGIME TRABALHISTA

        public Nullable<DateTime> dtAdm { get; set; }

        public Nullable<Int32> tpAdmissao { get; set; }

        public Int32 indAdmissao { get; set; }

        public Nullable<Int32> tpRegJor { get; set; }

        public Nullable<Int32> natAtividade { get; set; }

        public Nullable<Int32> dtBase { get; set; }

        public string cnpjSindCategProf { get; set; }

        //FTGS TRABALHADOR

        public Int32 opcFGTS { get; set; }

        public Nullable<DateTime> dtOpcFGTS { get; set; }

        //TRABALHADOR TEMPORARIO

        public Int32 mtvContrat { get; set; }

        public Int32 tpInsc { get; set; }

        public string nrInsc { get; set; }

        ////TRABALHADOR SUBSTITUTO

        public string cpfTrabSubst { get; set; }

        public string matricTrabSubst { get; set; }

        //TRABALHADOR ESTATUARIO

        public Int32 indProvim { get; set; }

        public Int32 tpProv { get; set; }

        public Nullable<DateTime> dtNomeacao { get; set; }

        public Nullable<DateTime> dtPosse { get; set; }

        public Nullable<DateTime> dtExercicio { get; set; }

        ////CONTRATO DE TRABALHO DO TRABALHADOR

        public Int32 codCargo { get; set; }

        public Int32 codFuncao { get; set; }

        public Int32 codCateg { get; set; }

        ////REMUNERAÇÃO DO TRABALHADOR

        public decimal vrSalFx { get; set; }

        public Nullable<Int32> undSalFixo { get; set; }

        public string descSalVar { get; set; }

        //DURAÇÃO CONTRATO DO TRABALHADOR

        public Nullable<Int32> tpContr { get; set; }

        //public Nullable<DateTime> dtTerm { get; set; }

        ////LOCAL DE TRABALHO DO TRABALHADOR

        public string tpInscLocalTrab { get; set; }

        public Int32 nrInscLocalTrab { get; set; }

        public string descCompLocalTrab { get; set; }

        //LOCAL DE TRABALHO DOMESTICO DO TRABALHADOR

        public string tpLogradDom { get; set; }

        public string descLogradDom { get; set; }

        public string nrLogradDom { get; set; }

        public string complementoDom { get; set; }

        public string bairroDom { get; set; }

        public string cepDom { get; set; }

        public string codMunicDom { get; set; }

        public string ufDom { get; set; }

        //HORARIO CONTRATUAL DO TRABALHADOR

        public Nullable<Int32> qtdHrsSem { get; set; }

        public Nullable<Int32> tpJornada { get; set; }

        //public Int32 dscTpJorn { get; set; }

        public Nullable<Int32> dia { get; set; }

        public string codHorContrat { get; set; }

        //FILIAÇÃO SINDICAL DO TRABALHADOR

        public string cnpjSindTrab { get; set; }

        //ALVARÁ JUDICIAL DO TRABALHADOR APRENDIZ

        public string nrProcJud { get; set; }

        //EMPRESA ANTERIOR DO TRABALHADOR

        public string cnpjEmpregAnt { get; set; }

        public string matricAnt { get; set; }

        public Nullable<DateTime> dtIniVinculo { get; set; }

        //AFASTAMENTO DO TRABALHADOR

        public Nullable<DateTime> dtIniAfast { get; set; }

        public string codMotAfast { get; set; }

        //DESLIGAMENTO DO TRABALHADOR

        public Nullable<DateTime> dtDeslig { get; set; }
    }
}