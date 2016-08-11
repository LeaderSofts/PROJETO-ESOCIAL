using Portal.Business.Models;
using Portal.Business.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Portal.Business.Repositories
{
    public partial class UsuarioRepository :  EFRepository<eSocial>
    {
        public UsuarioRepository() : base("dbEF") { }       
 
        public List<ValidateUsuario> Validar()
        {
            try
            {
                ResumoValidacao.CountEmpty = 0;
                ResumoValidacao.CountInvalid = 0;
                ResumoValidacao.CountValid = 0;

                List<ValidateUsuario> list_erros = new List<ValidateUsuario>();

                var listUsuario = this.FindAllBy();
                string error = string.Empty;

                foreach(var item in listUsuario)
                {
                    // INICIO TRABALHADOR

                    //list nome
                    if (!Validate.IsNome(item.nome, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "nome",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list cpf
                    if (!Validate.IsCpf(item.cpf, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "cpf",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list sexo
                    if (!Validate.IsSexo(item.sexo, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "sexo",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    ////list raça
                    if (!Validate.IsRaca(item.corraca, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "corraca",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    ////list estado civil
                    if (!Validate.IsEstadoCivil(item.estadocivil, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "estadocivil",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    ////list pis
                    if (!Validate.IsPis(item.pispasep, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "pispasep",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list Grau Instrução
                    if (!Validate.IsGrauInstrucao(item.grau_instrucao, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "grau_instrucao",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //NASCIMENTO TRABALHADOR

                    //list data de nascimento
                    if (!Validate.IsDataNascimento(item.data_nascimento, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "data_nascimento",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list Codigo Munnicipio
                    if (!Validate.IsCodMunicipio(item.cep, item.cod_municipio, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "cod_municipio",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list UF
                    if (!Validate.IsUf(item.cep, item.cod_estado, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "cod_estado",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list País de Nascimento
                    /*if (!Validate.IsPaisNascto(item.cep, item.cod_pais_Nascto, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "cod_pais_Nascto",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }*/

                    //list País de Nacionalidade
                    if (!Validate.IsPaisNac(item.cep, item.cod_pais, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "cod_pais",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //DOCUMENTOS TRABALHADOR

                    //list Nº CTPS
                    if (!Validate.IsNrCtps(item.cart_trab, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "cart_trab",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list Nº Série CTPS
                    if (!Validate.IsSerieCtps(item.serie_cart_trab, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "serie_cart_trab",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list UF CTPS
                    if (!Validate.IsUfCtps(item.ufcarttrab, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "ufcarttrab",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list Nº Ric
                    if (!Validate.ISNrRic(item.numeroric, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "numeroric",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                   // list Orgão Emissor Ric
                    if (!Validate.ISOrgEmissorRic(item.orgemissorric, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "orgemissorric",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                   // list Data Emissao Ric
                    if (!Validate.IsDtEmissaoRic(item.dtemissaoric, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "dtemissaoric",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                   // list numero RG
                    if (!Validate.IsNRg(item.rg, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "rg",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                  //  list Orgão Emissor RG
                    if (!Validate.IsOrgEmissorRg(item.orgemissorident, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "orgemissorident",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                  //  list Data de Expedição RG
                    if (!Validate.IsDtExpedicaoRg(item.data_em_ident, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "data_em_ident",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                  //  list numero da RNE
                    if (!Validate.IsNrRNE(item.nroreggeral, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "nroreggeral",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                  //  list orgão emissor da RNE
                    if (!Validate.IsOrgEmissorRNE(item.orgemissorrne, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "orgemissorrne",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                  //  list data expedição RNE
                    if (!Validate.IsDtExpedicaoRNE(item.dtemissaorne, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "dtemissaorne",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                   // list Nº Inscrição OC
                    if (!Validate.IsnrOc(item.nrOc, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "nrOc",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list Orgão emissor OC
                    if (!Validate.IsOrgEmissorOc(item.orgaoEmissorOc, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "orgaoEmissorOc",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                  //  list Data de Expedição OC
                    if (!Validate.IsDtExpedOc(item.dtExpedicaoOc, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "dtExpedicaoOc",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list data validade de Expedição OC
                    if (!Validate.IsDtValidOc(item.dtValidOc, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "dtValidOc",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                  //  list Nº Registro CNH
                    if (!Validate.IsNrRegCnh(item.nrRegCnh, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "nrRegCnh",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                   // list Data Expedição CNH
                    if (!Validate.IsDtExpCnh(item.dtExpCnh, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "dtExpCnh",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                  //  list UF CNH
                    if (!Validate.IsUfCnh(item.ufCnh, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "ufCnh",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                   // list data validade CNH
                   /* if (!Validate.IsDtValidCnh(item.dtValidCnh, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "dtValidCnh",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }*/

                  //  list data Primeira CNH
                    if (!Validate.IsDtPriHab(item.dtPriHab, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "dtPriHab",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                  //  list Categoria CNH
                    if (!Validate.IsCategoriaCnh(item.categoriaCnh, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "categoriaCnh",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }


                   // list tipo Logradouro
                    if (!Validate.IstpLograd(item.cep, item.tpLograd, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "tpLograd",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list Descrição Logradouro
                    if (!Validate.IsdescLograd(item.cep, item.desLograd, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "desLograd",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                  //  list Nº Logradouro
                    if (!Validate.IsnrLograd(item.nrLograd, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "nrLograd",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                   // list Complemento Logradouro
                    if (!Validate.Iscomplemento(item.complemento, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "complemento",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list Bairro Logradouro
                    if (!Validate.Isbairro(item.cep, item.bairro, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "bairro",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list cep
                    if (!Validate.IsCep(item.cep, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "cep",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                   // list Codigo Municipio
                    if (!Validate.IsCodMunicipioEnd(item.cep, item.codMunicipio, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "codMunicipio",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                  //  list uf
                    if (!Validate.IsUfEnd(item.cep, item.uf, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "uf",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                  //  Exterior

                  //  list País Residente Exterior
                    if (!Validate.IsPaisResidExt(item.cod_pais, item.paisResidExt, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "paisresidext",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                  //  list Logradouro Residente Exterior
                    if (!Validate.IsDesLogradExt(item.cod_pais, item.desLogradExt, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "desLogradExt",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                   // list complemento Residente Exterior
                    if (!Validate.IsComplementoExt(item.cod_pais, item.complementoExt, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "complementoExt",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                   // list numero logradouro Residente Exterior
                    if (!Validate.IsNrLogradExt(item.cod_pais, item.nrLogradExt, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "nrLogradExt",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                  //  list bairro Residente Exterior
                    if (!Validate.IsbairroExt(item.cod_pais, item.bairroExt, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "bairroExt",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                  //  list cidade Residente Exterior
                    if (!Validate.IsNmCidExt(item.cod_pais, item.nmCidExt, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "nmCidExt",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                  //  list Codigo Postal Residente Exterior
                    if (!Validate.IsCodPostalExt(item.cod_pais, item.codPostalExt, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "codPostalExt",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                  //  list Data chegada Extrangeiro
                    if (!Validate.IsDtChegadaEstrang(item.cod_pais, item.dtChegadaEstrang, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "dtChegadaEstrang",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                  //  list Classe Extrangeiro
                /*    if (!Validate.IsclassTrabaEstrang(item.cod_pais, item.classTrabaEstrang, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "classTrabaEstrang",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }*/

                  //  list Casado com Brasileiro
                    if (!Validate.IsCasadoBrEstrang(item.cod_pais, item.casadoBrEstrang, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "casadoBrEstrang",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                   // list Filhos com Brasileiros
                    if (!Validate.IsFilhosBrEstrang(item.cod_pais, item.filhosBrEstrang, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "filhosBrEstrang",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                  //  list deficiencia fisica
                    if (!Validate.IsDefFisico(item.defFisico, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "defFisico",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                  //  list deficiencia Visual
                    if (!Validate.IsDefVisual(item.defVisual, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "defVisual",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                   // list deficiencia Auditiva
                    if (!Validate.IsDefAuditivo(item.defAuditivo, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "defAuditivo",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list deficiencia Mental
                    if (!Validate.IsDefMental(item.defMental, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "defMental",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                   // list deficiencia Intelectual
                    if (!Validate.IsDefIntelectual(item.defIntelectual, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "defIntelectual",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                   // list Reabilitado
                    /*if (!Validate.IsReabReadp(item.reabReadap, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "reabReadap",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }*/

                  //  list Trabalhador Aposentado
                    if (!Validate.IsTrabAposent(item.trabAposent, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "trabAposent",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                  //  list Fone Principal
                    if (!Validate.IsFonePrinc(item.fonePrinc, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "fonePrinc",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list Fone Alternativo
                    if (!Validate.IsFoneAlternat(item.foneAlternat, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "foneAlternat",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                   // list E-mail principal
                    if (!Validate.IsEmailPrinc(item.emailPrinc, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "emailPrinc",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                  //  list e-mail alternartivo
                    if (!Validate.IsEmailAlternat(item.emailAlternat, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "emailAlternat",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                  //  list matricula
                    if (!Validate.IsMatricula(item.matricula, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "matricula",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                  //  list tipo regime trabalhista
                    if (!Validate.IsTpRegTrab(item.tpRegTrab, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "tpRegTrab",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                   // list tipo regime Previdenciario
                   /* if (!Validate.IsTpRegPrev(item.tpRegPrev, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "tpRegPrev",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }
                    */
                   // list tipo Data Adm
                    if (!Validate.IsDtAdm(item.dtAdm, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "dtAdm",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                  //  list tp Admissao
                    if (!Validate.IsTpAdmissao(item.tpAdmissao, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "tpAdmissao",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                   // list indicativo Admissao
                   /* if (!Validate.IsIndAdmissao(item.indAdmissao, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "indAdmissao",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }*/

                 //   list Regime Jornada
                    if (!Validate.IsTpRegJor(item.tpRegJor, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "tpRegJor",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                 //   list Natureza Atividade
                    if (!Validate.IsNatAtividade(item.natAtividade, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "natAtividade",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                 //   list data Base
                    if (!Validate.IsDtBase(item.dtBase, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "dtBase",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                //    list cnpj sindicato
                    if (!Validate.IsCnpjSindCategProf(item.cnpjSindCategProf, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "cnpjSindCategProf",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                //    list OPC FGTS
                  /*  if (!Validate.IsOpcFgts(item.opcFGTS, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "opcFGTS",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }*/

                //    list Data OPC FGTS
                    if (!Validate.IsDtOpcFgts(item.dtOpcFGTS, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "opcFGTS",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list Motivo Contratação
                    /*  if (!Validate.IsMtvContrat(item.mtvContrat, out error))
                      {
                          list_erros.Add(new ValidateUsuario
                          {
                              campo = "mtvContrat",
                              erro = error,
                              id_usuario = Convert.ToInt32(item.codigo),
                              nome_usuario = item.nome
                          });
                      }

                      //list Tipo Inscrição
                      if (!Validate.IsTpInsc(item.tpInsc, out error))
                      {
                          list_erros.Add(new ValidateUsuario
                          {
                              campo = "tpInscTemp",
                              erro = error,
                              id_usuario = Convert.ToInt32(item.codigo),
                              nome_usuario = item.nome
                          });
                      }

                      //list numero CNPJ ou CPF
                      if (!Validate.IsNrInsc(item.tpInsc, item.nrInsc, out error))
                      {
                          list_erros.Add(new ValidateUsuario
                          {
                              campo = "nrInscTemp",
                              erro = error,
                              id_usuario = Convert.ToInt32(item.codigo),
                              nome_usuario = item.nome
                          });
                      }
                      */
                    //   list numero CPF subsituto
                    if (!Validate.IsCpfTrabSubst(item.cpfTrabSubst, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "cpfTrabSubst",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

               //     list Matricula
                    if (!Validate.IsmatricTrabSubst(item.matricTrabSubst, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "matricTrabSubst",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list Provimento
                 /*   if (!Validate.IsIndProvim(item.indProvim, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "indProvim",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }*/

                    //list Tipo Provimento
                    if (!Validate.IsTpAdmissao(item.tpProv, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "tpProv",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }
                    /*
                    //list Data Nomeação
                    if (!Validate.IsDtNomeacao(item.dtNomeacao, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "dtNomeacao",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list Data Posse
                    if (!Validate.IsDtPosse(item.dtPosse, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "dtPosse",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list Data Exercicio
                    if (!Validate.IsDtExercicio(item.dtExercicio, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "dtExercicio",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list Codigo Cargo
                    if (!Validate.IsCodCargo(item.tpProv, item.codCargo, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "codCargo",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list codigo Funcao
                    if (!Validate.IsCodFuncao(item.tpProv, item.codFuncao, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "codFuncao",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list codigo Categ
                    if (!Validate.IsCodCateg(item.tpProv, item.codCateg, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "codCateg",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }
                    */
                 //   list valor Salario Fixo
                    if (!Validate.IsVrSalFx(item.vrSalFx, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "vrSalFx",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                 //   list unidade Salario Fixo
                    if (!Validate.IsUndSalFixo(item.undSalFixo, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "undSalFixo",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list descrição Salario variavel
                    if (!Validate.IsDescSalvar(item.undSalFixo, item.descSalVar, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "descSalVar",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list Tipo de Contrato
                    if (!Validate.IsTpContr(item.tpContr, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "tpContr",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list Término do Contrato
                 /*   if (!Validate.IsDtTerm(item.tpContr, item.dtTerm, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "dtTerm",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }
                    */
                    //list Tipo de inscrição
                    if (!Validate.IsTpInscLocalTrab(item.tpInscLocalTrab, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "tpInscLocalTrab",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    // list numero inscrição de trabalho
                    if (!Validate.IsNrInscLocalTrab(item.nrInscLocalTrab, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "nrInscLocalTrab",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    // list descrição local trabalho
                    if (!Validate.IsDescCompLocalTrab(item.descCompLocalTrab, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "descCompLocalTrab",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list tipo Logradouro
                    if (!Validate.IstpLogradDom(item.cepDom, item.tpLogradDom, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "tpLogradDom",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list Descrição Logradouro
                    if (!Validate.IsdescLogradDom(item.cepDom, item.descLogradDom, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "desLogradDom",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list Nº Logradouro
                    if (!Validate.IsnrLogradDom(item.nrLogradDom, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "nrLogradDom",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list Complemento Logradouro
                    if (!Validate.IscomplementoDom(item.complementoDom, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "complementoDom",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list Nº Logradouro
                    if (!Validate.IsbairroDom(item.cepDom, item.bairroDom, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "bairroDom",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list cep
                    if (!Validate.IsCepDom(item.cepDom, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "cepDom",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list Codigo Municipio
                    if (!Validate.IsCodMunicipioEndDom(item.cepDom, item.codMunicipio, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "codMunicipioDom",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list uf Dom
                    if (!Validate.IsUfEndDom(item.cepDom, item.ufDom, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "ufDom",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list Quantidade de horas semanal
                    if (!Validate.IsQtdHrsSem(item.qtdHrsSem, item.tpRegJor, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "qtdHrsSem",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                   // list Tipo de jornada
                    if (!Validate.IsTpJornada(item.tpJornada, item.tpRegJor, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "tpJornada",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list Descrição de jornada
                    /*
                    if (!Validate.IsDscTpJorn(item.tpJornada, item.dscTpJorn, item.tpRegJor, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "dscTpJorn",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }*/

                    //list Dia
                    if (!Validate.IsDia(item.dia, item.tpRegJor, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "dia",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list Codigo Hora Contratual
                    if (!Validate.IsCodHorContrat(item.codHorContrat, item.tpRegJor, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "codHorContrat",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list Nº CNPJ Sindicato
                    if (!Validate.IsCnpjSindTrab(item.cnpjSindTrab, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "cnpjSindTrab",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list Nº Processo Judicial
                    if (!Validate.IsNrProcJud(item.nrProcJud, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "nrProcJud",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list CNPJ Empregador Anterior
                    if (!Validate.IsCnpjEmpregAnt(item.cnpjEmpregAnt, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "cnpjEmpregAnt",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list Nº Matricula do trabalhador no empregador anterior
                    if (!Validate.IsMatricAnt(item.matricAnt, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "matricAnt",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list Data Inicial do vinculo anterior
                    //if (!Validate.IsDtIniVinculo(item.dtIniVinculo, out error))
                    //{
                    //    list_erros.Add(new ValidateUsuario
                    //    {
                    //        campo = "dtIniVinculo",
                    //        erro = error,
                    //        id_usuario = Convert.ToInt32(item.codigo),
                    //        nome_usuario = item.nome
                    //    });
                    //}

                    //list Data inicio Afastamento anterior
                    //if (!Validate.IsDtIniAfast(item.dtIniAfast, out error))
                    //{
                    //    list_erros.Add(new ValidateUsuario
                    //    {
                    //        campo = "dtIniAfast",
                    //        erro = error,
                    //        id_usuario = Convert.ToInt32(item.codigo),
                    //        nome_usuario = item.nome
                    //    });
                    //}

                    //list Codigo Motivo Afastamento anterior
                    if (!Validate.IsCodMotAfast(item.codMotAfast, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "codMotAfast",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }

                    //list Data Desligamento
                  /*  if (!Validate.IsDtDeslig(item.dtDeslig, out error))
                    {
                        list_erros.Add(new ValidateUsuario
                        {
                            campo = "dtDeslig",
                            erro = error,
                            id_usuario = Convert.ToInt32(item.codigo),
                            nome_usuario = item.nome
                        });
                    }*/


                }

                return list_erros;
            }
            catch (Exception ex)
            {
                LogUtil.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }
    }
}