using Portal.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.Business.Utils
{
    public class Validate
    {

        //Validar nome em branco
        public static bool IsNome(string nome, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(nome))
            {
                error = "Nome em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar cpf invalido ou em branco
        public static bool IsCpf(string cpf, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(cpf))
            {
                error = "CPF em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if ((cpf) != "")
            {
                if (cpf.Length > 11)
                {
                    error = "CPF Inválido";
                    ResumoValidacao.CountInvalid++;
                    return false;
                }

                while (cpf.Length != 11)
                    cpf = '0' + cpf;

                bool igual = true;
                for (int i = 1; i < 11 && igual; i++)
                    if (cpf[i] != cpf[0])
                        igual = false;

                if (igual || cpf == "12345678909")
                {
                    error = "CPF Inválido";
                    ResumoValidacao.CountInvalid++;
                    return false;
                }

                int[] numeros = new int[11];

                for (int i = 0; i < 11; i++)
                    numeros[i] = int.Parse(cpf[i].ToString());

                int soma = 0;
                for (int i = 0; i < 9; i++)
                    soma += (10 - i) * numeros[i];

                int resultado = soma % 11;

                if (resultado == 1 || resultado == 0)
                {
                    if (numeros[9] != 0)
                    {
                        error = "CPF Inválido";
                        ResumoValidacao.CountInvalid++;
                        return false;
                    }
                }
                else if (numeros[9] != 11 - resultado)
                {
                    error = "CPF Inválido";
                    ResumoValidacao.CountInvalid++;
                    return false;
                }

                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += (11 - i) * numeros[i];

                resultado = soma % 11;

                if (resultado == 1 || resultado == 0)
                {
                    if (numeros[10] != 0)
                    {
                        error = "CPF Inválido";
                        ResumoValidacao.CountInvalid++;
                        return false;
                    }
                }
                else
                    if (numeros[10] != 11 - resultado)
                {
                    error = "CPF Inválido";
                    ResumoValidacao.CountInvalid++;
                    return false;
                }

                ResumoValidacao.CountValid++;
                return true;

            }
            ResumoValidacao.CountValid++;
            return true;

        }

        //Validar PIS em branco
        public static bool IsPis(string pis, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(pis))
            {
                error = "PIS em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if ((pis) != "")
            {
                int[] multiplicador = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int soma;
                int resto;
                if (pis.Trim().Length != 11)
                {
                    error = "PIS Inválido";
                    ResumoValidacao.CountInvalid++;
                    return false;
                }
                pis = pis.Trim();
                pis = pis.Replace("-", "").Replace(".", "").PadLeft(11, '0');

                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += int.Parse(pis[i].ToString()) * multiplicador[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                {
                    error = "PIS Inválido";
                    ResumoValidacao.CountInvalid++;
                    return false;
                }

            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar sexo em branco
        public static bool IsSexo(string sexo, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(sexo))
            {
                error = "Sexo em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if ((sexo) != "")
            {
                if (sexo != "M" && sexo != "F")
                {
                    error = "Campo Sexo Inválido";
                    ResumoValidacao.CountInvalid++;
                    return false;
                }
                ResumoValidacao.CountValid++;
                return true;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar raça em branco
        public static bool IsRaca(string raca, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(raca))
            {
                error = "Raça em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            } 

            if (raca  != "1" || raca != "2" || raca != "3" || raca != "4" || raca != "5" || raca != "6")
            {
                error = "Campo Raça Inválido";
                ResumoValidacao.CountInvalid++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar estado civil em branco
        public static bool IsEstadoCivil(string civil, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(civil))
            {
                error = "Estado Civil em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if (civil != "1" || civil != "2" || civil != "3" || civil != "4" || civil != "5")
            {
                error = "Campo Estado Civil Inválido";
                ResumoValidacao.CountInvalid++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        // //Validar Grau de instrução em branco
        public static bool IsGrauInstrucao(string grauInstrucao, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(grauInstrucao.ToString()))
            {
                error = "Grau de instrução em branco";
                ResumoValidacao.CountInvalid++;
                return false;
            }

            if (grauInstrucao.ToString() != "01" || grauInstrucao.ToString() != "02" || grauInstrucao.ToString() != "03"
                || grauInstrucao.ToString() != "04" || grauInstrucao.ToString() != "05" || grauInstrucao.ToString() != "06"
                || grauInstrucao.ToString() != "07" || grauInstrucao.ToString() != "08" || grauInstrucao.ToString() != "09"
                || grauInstrucao.ToString() != "10" || grauInstrucao.ToString() != "11" || grauInstrucao.ToString() != "12")
            {
                error = "Grau de Instrução Inválido";
                ResumoValidacao.CountInvalid++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        // //NASCIMENTO TRABALHADOR

        //Validar Data Nascimento em branco
        internal static bool IsDataNascimento(Nullable<DateTime> data_nascimento_usuario, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(data_nascimento_usuario.ToString()))
            {
                error = "Data de Nascimento do Trabalhador em branco";
                ResumoValidacao.CountInvalid++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;

        }

        // Validar Codigo Municipio em branco
        public static bool IsCodMunicipio(string cep, string codMunicipio, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(codMunicipio))
            {
                error = "Codigo Municipio do Trabalhador em branco";
                ResumoValidacao.CountInvalid++;
                return false;
            }

            if (!string.IsNullOrWhiteSpace(cep))
            {
                wsCorreios.AtendeClienteClient ws = new wsCorreios.AtendeClienteClient();
                try
                {
                    var result = ws.consultaCEP(cep.Replace("-", "").Replace(".", "").Trim());

                    if (result != null)
                    {
                        if (result.end.Contains(codMunicipio))
                            return true;
                        else
                        {
                            error = "Codigo Municipio inválido.";
                            ResumoValidacao.CountInvalid++;
                            return false;
                        }
                    }
                    else
                    {
                        error = "Codigo Municipio inválido.";
                    }
                }
                catch (Exception ex)
                {
                    error = "Codigo Municipio inválido.";
                    ResumoValidacao.CountInvalid++;
                    return false;
                }
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        // //Validar UF em branco
        public static bool IsUf(string cep, string cod_estado, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(cod_estado))
            {
                error = "UF do Trabalhador em branco";
                ResumoValidacao.CountInvalid++;
                return false;
            }
            if (!string.IsNullOrWhiteSpace(cod_estado.ToString()))
            {
                wsCorreios.AtendeClienteClient ws = new wsCorreios.AtendeClienteClient();
                try
                {
                    var result = ws.consultaCEP(cep.Replace("-", "").Replace(".", "").Trim());

                    if (result != null)
                    {
                        if (result.uf.Contains(cod_estado))
                            return true;
                        else
                        {
                            error = "UF inválida.";
                            ResumoValidacao.CountInvalid++;
                            return false;
                        }
                    }
                    else
                    {
                        error = "UF inválida.";
                    }
                }
                catch (Exception ex)
                {
                    error = "UF inválida.";
                    ResumoValidacao.CountInvalid++;
                    return false;
                }
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        // //Validar País de nascimento em branco
        public static bool IsPaisNascto(string cep, string paisNascto, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(paisNascto))
            {
                error = "Pais de Nascimento Trabalhador em branco";
                return false;
            }

            if (!string.IsNullOrWhiteSpace(cep))
            {
                wsCorreios.AtendeClienteClient ws = new wsCorreios.AtendeClienteClient();
                try
                {
                    var result = ws.consultaCEP(cep.Replace("-", "").Replace(".", "").Trim());

                    if (result != null)
                    {
                        if (result.end.Contains(paisNascto))
                            return true;
                        else
                        {
                            error = "Codigo País de Nascimento inválida.";
                            ResumoValidacao.CountInvalid++;
                            return false;
                        }
                    }
                    else
                    {
                        error = "Codigo País de Nascimento inválida.";
                    }
                }
                catch (Exception ex)
                {
                    error = "Codigo País de Nascimento inválida.";
                    ResumoValidacao.CountInvalid++;
                    return false;
                }
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        // //Validar País de nacionalidade em branco
        public static bool IsPaisNac(string cep, Nullable<int> cod_pais, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(cod_pais.ToString()))
            {
                error = "Pais de Nacionalidade Trabalhador em branco";
                return false;
            }

            if (!string.IsNullOrWhiteSpace(cod_pais.ToString()))
            {
                wsCorreios.AtendeClienteClient ws = new wsCorreios.AtendeClienteClient();
                try
                {
                    var result = ws.consultaCEP(cep.Replace("-", "").Replace(".", "").Trim());

                    if (result != null)
                    {
                        if (result.end.Contains(cod_pais.ToString()))
                            return true;
                        else
                        {
                            error = "Codigo País de Nacionalidade inválida.";
                            ResumoValidacao.CountInvalid++;
                            return false;
                        }
                    }
                    else
                    {
                        error = "Codigo País de Nacionalidade inválida.";
                    }
                }
                catch (Exception ex)
                {
                    error = "Codigo País de Nacionalidade inválida.";
                    ResumoValidacao.CountInvalid++;
                    return false;
                }
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        // //DOCUMENTOS TRABALHADOR

        // // *CTPS*
        //Validar Nº CTPS em branco
        public static bool IsNrCtps(string cart_trab, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(cart_trab))
            {
                error = "Nº CTPS Trabalhador em branco";
                ResumoValidacao.CountInvalid++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        // //Validar Nº de Série CTPS em branco
        public static bool IsSerieCtps(string serie_cart_trab, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(serie_cart_trab))
            {
                error = "Nº de Série CTPS Trabalhador em branco";
                ResumoValidacao.CountInvalid++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        // //Validar UF CTPS em branco
        public static bool IsUfCtps(string ufcarttrab, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(ufcarttrab))
            {
                error = "UF CTPS Trabalhador em branco";
                ResumoValidacao.CountInvalid++;
                return false;
            }

            if (ufcarttrab != "MG" && ufcarttrab != "SP")
            {
                error = "UF CTPS Inválido";
                ResumoValidacao.CountInvalid++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        // //Validar Numero RIC em branco
        public static bool ISNrRic(string numeroric, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(numeroric) && numeroric != "null")
            {
                error = "Nº da Ric Trabalhador em branco";
                ResumoValidacao.CountInvalid++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        // //Validar Orgão Emissor RIC em branco
        public static bool ISOrgEmissorRic(string orgemissorric, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(orgemissorric) && orgemissorric != "null")
            {
                error = "Orgão Emissor Ric em branco";
                ResumoValidacao.CountInvalid++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        // //Validar Data Emissao RIC em branco
        public static bool IsDtEmissaoRic(Nullable<DateTime> dtemissaoric, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(dtemissaoric.ToString()) && dtemissaoric.ToString() != "null")
            {
                error = "Data de Emissão Ric em branco";
                ResumoValidacao.CountInvalid++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Numero do RG em branco
        public static bool IsNRg(string rg, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(rg))
            {
                error = "Numero RG em branco";
                ResumoValidacao.CountInvalid++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Orgão emissor RG em branco
        public static bool IsOrgEmissorRg(string orgemissorident, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(orgemissorident))
            {
                error = "Orgão emissor RG em branco";
                ResumoValidacao.CountInvalid++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Data expedição RG em branco
        public static bool IsDtExpedicaoRg(Nullable<DateTime> data_em_ident, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(data_em_ident.ToString()))
            {
                error = "Data Expedição RG em branco";
                ResumoValidacao.CountInvalid++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Numero RNE em branco
        public static bool IsNrRNE(string nroreggeral, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(nroreggeral))
            {
                error = "Numero da RNE em branco";
                ResumoValidacao.CountInvalid++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Orgão Emissor RNE em branco
        public static bool IsOrgEmissorRNE(string orgemissorrne, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(orgemissorrne))
            {
                error = "Orgão emissor da RNE em branco";
                ResumoValidacao.CountInvalid++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Data expedição RNE em branco
        public static bool IsDtExpedicaoRNE(Nullable<DateTime> dtemissaorne, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(dtemissaorne.ToString()))
            {
                error = "Data Expedição RNE em branco";
                ResumoValidacao.CountInvalid++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Nº Inscrição OC em branco
        public static bool IsnrOc(string nrOc, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(nrOc))
            {
                error = "Nº Numero inscrição OC em branco";
                ResumoValidacao.CountInvalid++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Orgão emissor OC em branco
        public static bool IsOrgEmissorOc(string orgaoEmissorOc, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(orgaoEmissorOc))
            {
                error = "Orgão emissor OC em branco";
                ResumoValidacao.CountInvalid++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar data expedição OC em branco
        public static bool IsDtExpedOc(Nullable<DateTime> dtExpedicaoOc, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(dtExpedicaoOc.ToString()))
            {
                error = "Data expedição OC em branco";
                ResumoValidacao.CountInvalid++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar data validade OC em branco
        public static bool IsDtValidOc(Nullable<DateTime> dtValidOc, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(dtValidOc.ToString()))
            {
                error = "Data validade OC em branco";
                ResumoValidacao.CountInvalid++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar nº registro CNH em branco
        public static bool IsNrRegCnh(string nrRegCnh, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(nrRegCnh))
            {
                error = "Nº registro CNH em branco";
                ResumoValidacao.CountInvalid++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar data expedição CNH em branco
        public static bool IsDtExpCnh(Nullable<DateTime> dtExpCnh, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(dtExpCnh.ToString()))
            {
                error = "Data expedição CNH em branco";
                ResumoValidacao.CountInvalid++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar UF CNH em branco
        public static bool IsUfCnh(string ufCnh, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(ufCnh))
            {
                error = "Uf CNH em branco";
                ResumoValidacao.CountInvalid++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar data validade CNH em branco
        //public static bool IsDtValidCnh(DateTime dtValidCnh, out string error)
        //{
        //    error = string.Empty;

        //    if (string.IsNullOrWhiteSpace(dtValidCnh.ToString()))
        //    {
        //        error = "Data validade CNH em branco";
        //        ResumoValidacao.CountInvalid++;
        //        return false;
        //    }
        //    ResumoValidacao.CountValid++;
        //    return true;
        //}

        //Validar data Primeira CNH em branco
        public static bool IsDtPriHab(Nullable<DateTime> dtPriHab, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(dtPriHab.ToString()))
            {
                error = "Data Primeira CNH em branco";
                ResumoValidacao.CountInvalid++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Categoria CNH em branco
        public static bool IsCategoriaCnh(string categoriaCnh, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(categoriaCnh))
            {
                error = "Categoria CNH em branco";
                ResumoValidacao.CountInvalid++;
                return false;
            }

            if (categoriaCnh != "A" && categoriaCnh != "B" && categoriaCnh != "C" && categoriaCnh != "D" && categoriaCnh != "E" && categoriaCnh != "AB" &&
                categoriaCnh != "AC" && categoriaCnh != "AD" && categoriaCnh != "AE")
            {
                error = "Categoria CNH Inválida";
                ResumoValidacao.CountInvalid++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }


        //Validar Tipo de Logradouro em branco
        public static bool IstpLograd(string cep, Nullable<int> tpLograd, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(tpLograd.ToString()))
            {
                error = "Tipo de Logradouro em branco";
                ResumoValidacao.CountInvalid++;
                return false;
            }

            if (!string.IsNullOrWhiteSpace(tpLograd.ToString()))
            {
                wsCorreios.AtendeClienteClient ws = new wsCorreios.AtendeClienteClient();
                try
                {
                    var result = ws.consultaCEP(cep.Replace("-", "").Replace(".", "").Trim());

                    if (result != null)
                    {
                        if (result.end.Contains(tpLograd.ToString()))
                            return true;
                        else
                        {
                            error = "Tipo de logradouro inválido.";
                            ResumoValidacao.CountInvalid++;
                            return false;
                        }
                    }
                    else
                    {
                        error = "Tipo de logradouro inválido.";
                    }
                }
                catch (Exception ex)
                {
                    error = "Tipo de logradouro inválido.";
                    ResumoValidacao.CountInvalid++;
                    return false;
                }
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        // //Validar Descrição Logradouro em branco e Invalido
        public static bool IsdescLograd(string cep, string desLograd, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(desLograd))
            {
                error = "Endereço Trabalhador em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if (!string.IsNullOrWhiteSpace(cep))
            {
                wsCorreios.AtendeClienteClient ws = new wsCorreios.AtendeClienteClient();
                try
                {
                    var result = ws.consultaCEP(cep.Replace("-", "").Replace(".", "").Trim());

                    if (result != null)
                    {
                        if (result.end.Contains(desLograd))
                            return true;
                        else
                        {
                            error = "Descrição logradouro inválido.";
                            ResumoValidacao.CountInvalid++;
                            return false;
                        }
                    }
                    else
                    {
                        error = "Descrição logradouro inválido.";
                    }
                }
                catch (Exception ex)
                {
                    error = "ENDEREÇO inválido.";
                    ResumoValidacao.CountInvalid++;
                    return false;
                }
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Numero Logradouro em branco
        public static bool IsnrLograd(string nrLograd, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(nrLograd))
            {
                error = "Nº Logradouro em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Complemento Logradouro em branco
        public static bool Iscomplemento(string complemento, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(complemento))
            {
                error = "Complemento Logradouro em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Bairro em branco
        public static bool Isbairro(string cep, string bairro, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(bairro))
            {
                error = "Bairro em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }
            if (!string.IsNullOrWhiteSpace(cep))
            {
                wsCorreios.AtendeClienteClient ws = new wsCorreios.AtendeClienteClient();
                try
                {
                    var result = ws.consultaCEP(cep.Replace("-", "").Replace(".", "").Trim());

                    if (result != null)
                    {
                        if (result.bairro.Contains(bairro))
                            return true;
                        else
                        {
                            error = "Bairro inválido.";
                            ResumoValidacao.CountInvalid++;
                            return false;
                        }
                    }
                    else
                    {
                        error = "Bairro inválido.";
                    }
                }
                catch (Exception ex)
                {
                    error = "Bairro inválido.";
                    ResumoValidacao.CountInvalid++;
                    return false;
                }
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        // //Validar cep em branco
        public static bool IsCep(string cep, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(cep))
            {
                error = "CEP em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if ((cep) != "")
            {
                wsCorreios.AtendeClienteClient ws = new wsCorreios.AtendeClienteClient();
                try
                {
                    var result = ws.consultaCEP(cep.Replace("-", "").Replace(".", "").Trim());

                    if (result != null)
                        return true;
                    else
                    {
                        error = "CEP inválido.";
                    }
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    ResumoValidacao.CountInvalid++;
                    return false;
                }
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Cidade em branco e cidade invalida
        public static bool IsCodMunicipioEnd(string cep, string codMunicipio, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(codMunicipio))
            {
                error = "Codigo Municipio do Trabalhador em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if (!string.IsNullOrWhiteSpace(cep))
            {
                wsCorreios.AtendeClienteClient ws = new wsCorreios.AtendeClienteClient();
                try
                {
                    var result = ws.consultaCEP(cep.Replace("-", "").Replace(".", "").Trim());

                    if (result != null)
                    {
                        if (result.end.Contains(codMunicipio))
                            return true;
                        else
                        {
                            error = "Codigo Municipio inválido.";
                            ResumoValidacao.CountEmpty++;
                            return false;
                        }
                    }
                    else
                    {
                        error = "Codigo Municipio inválido.";
                    }
                }
                catch (Exception ex)
                {
                    error = "Codigo Municipio inválido.";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar UF em branco e cidade invalida
        public static bool IsUfEnd(string cep, string uf, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(uf))
            {
                error = "UF do Trabalhador em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if (!string.IsNullOrWhiteSpace(cep))
            {
                wsCorreios.AtendeClienteClient ws = new wsCorreios.AtendeClienteClient();
                try
                {
                    var result = ws.consultaCEP(cep.Replace("-", "").Replace(".", "").Trim());

                    if (result != null)
                    {
                        if (result.end.Contains(uf))
                            return true;
                        else
                        {
                            error = "UF inválida.";
                            ResumoValidacao.CountEmpty++;
                            return false;
                        }
                    }
                    else
                    {
                        error = "UF inválida.";
                    }
                }
                catch (Exception ex)
                {
                    error = "UF inválida.";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Páis Exterior em branco
        public static bool IsPaisResidExt(Nullable<int> cod_pais, string paisResidExt, out string error)
        {
            error = string.Empty;
            if ((cod_pais.ToString()) != "55")
            {
                error = string.Empty;

                if (string.IsNullOrWhiteSpace(paisResidExt))
                {
                    error = "Pais Exterior em branco";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }
                ResumoValidacao.CountValid++;
                return true;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Descrição Exterior em branco
        public static bool IsDesLogradExt(Nullable<int> cod_pais, string desLogradExt, out string error)
        {
            error = string.Empty;
            if ((cod_pais.ToString()) != "55")
            {
                error = string.Empty;

                if (string.IsNullOrWhiteSpace(desLogradExt))
                {
                    error = "Descrição Exterior em branco";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Complemento Exterior em branco
        public static bool IsComplementoExt(Nullable<int> cod_pais, string complementoExt, out string error)
        {
            error = string.Empty;
            if ((cod_pais.ToString()) != "55")
            {
                error = string.Empty;

                if (string.IsNullOrWhiteSpace(complementoExt))
                {
                    error = "Complemento Exterior em branco";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Nº Exterior em branco
        public static bool IsNrLogradExt(Nullable<int> cod_pais, string nrLogradExt, out string error)
        {
            error = string.Empty;
            if ((cod_pais.ToString()) != "55")
            {
                error = string.Empty;

                if (string.IsNullOrWhiteSpace(nrLogradExt))
                {
                    error = "Nº Exterior em branco";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Bairro Exterior em branco
        public static bool IsbairroExt(Nullable<int> cod_pais, string bairroExt, out string error)
        {
            error = string.Empty;
            if ((cod_pais.ToString()) != "55")
            {
                error = string.Empty;

                if (string.IsNullOrWhiteSpace(bairroExt))
                {
                    error = "Bairro Exterior em branco";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Cidade Exterior em branco
        public static bool IsNmCidExt(Nullable<int> cod_pais, string nmCidExt, out string error)
        {
            error = string.Empty;
            if ((cod_pais.ToString()) != "55")
            {
                error = string.Empty;

                if (string.IsNullOrWhiteSpace(nmCidExt))
                {
                    error = "Cidade Exterior em branco";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Codigo Postal Exterior em branco
        public static bool IsCodPostalExt(Nullable<int> cod_pais, string codPostalExt, out string error)
        {
            error = string.Empty;
            if ((cod_pais.ToString()) != "55")
            {
                error = string.Empty;

                if (string.IsNullOrWhiteSpace(codPostalExt))
                {
                    error = "Codigo Postal Exterior em branco";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Data chegada Estrangeiro em branco
        public static bool IsDtChegadaEstrang(Nullable<int> cod_pais, Nullable<DateTime> dtChegadaEstrang, out string error)
        {
            error = string.Empty;
            if ((cod_pais.ToString()) != "55")
            {
                error = string.Empty;

                if (string.IsNullOrWhiteSpace(dtChegadaEstrang.ToString()))
                {
                    error = "Data chegada Estrangeiro em branco";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Classe Estrangeiro em branco
        //public static bool IsclassTrabaEstrang(Nullable<int> cod_pais, Int16 classTrabaEstrang, out string error)
        //{
        //    error = string.Empty;

        //    if ((cod_pais.ToString()) != "55")
        //    {
        //        error = string.Empty;

        //        if (string.IsNullOrWhiteSpace(classTrabaEstrang.ToString()))
        //        {
        //            error = "Classe Estrangeiro em branco";
        //            ResumoValidacao.CountEmpty++;
        //            return false;
        //        }

        //        if((classTrabaEstrang.ToString()) != "" && (classTrabaEstrang.ToString() != null))
        //        {
        //            if(classTrabaEstrang < 1 && classTrabaEstrang > 12)
        //            {
        //                error = "Classe Estrangeiro em branco";
        //                ResumoValidacao.CountEmpty++;
        //                return false;
        //            }
        //            ResumoValidacao.CountValid++;
        //            return true;
        //        }
        //    }
        //    ResumoValidacao.CountValid++;
        //    return true;
        //}

        //Validar Casado com BR em branco
        public static bool IsCasadoBrEstrang(Nullable<int> cod_pais, string casadoBrEstrang, out string error)
        {
            error = string.Empty;

            if ((cod_pais.ToString()) != "55")
            {
                error = string.Empty;

                if (string.IsNullOrWhiteSpace(casadoBrEstrang))
                {
                    error = "Campo Casado com Brasileiro em branco";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }

                if ((casadoBrEstrang) != "")
                {
                    if (casadoBrEstrang != "S" && casadoBrEstrang != "N")
                    {
                        error = "Campo Casado com Brasileiro em branco";
                        ResumoValidacao.CountEmpty++;
                        return false;
                    }
                    ResumoValidacao.CountValid++;
                    return true;
                }
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Casado com BR em branco
        public static bool IsFilhosBrEstrang(Nullable<int> cod_pais, string filhosBrEstrang, out string error)
        {
            error = string.Empty;

            if ((cod_pais.ToString()) != "55")
            {
                error = string.Empty;

                if (string.IsNullOrWhiteSpace(filhosBrEstrang))
                {
                    error = "Campo filhos Brasileiros em branco";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }

                if ((filhosBrEstrang) != "")
                {
                    if (filhosBrEstrang != "S" && filhosBrEstrang != "N")
                    {
                        error = "Campo filhos Brasileiros em branco";
                        ResumoValidacao.CountEmpty++;
                        return false;
                    }
                    ResumoValidacao.CountValid++;
                    return true;
                }
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Deficiencia Fisica em branco
        public static bool IsDefFisico(string defFisico, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(defFisico))
            {
                error = "Campo Deficiente Físico em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if ((defFisico) != "")
            {
                if (defFisico != "S" && defFisico != "N")
                {
                    error = "Campo Deficiente Físico inválido.";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }
                ResumoValidacao.CountValid++;
                return true;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Deficiencia Visual em branco
        public static bool IsDefVisual(string defVisual, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(defVisual))
            {
                error = "Campo Deficiencia Visual em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if ((defVisual) != "")
            {
                if (defVisual != "S" && defVisual != "N")
                {
                    error = "Campo Deficiencia Visual inválido.";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }
                ResumoValidacao.CountValid++;
                return true;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Deficiencia Auditiva em branco
        public static bool IsDefAuditivo(string defAuditivo, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(defAuditivo))
            {
                error = "Campo Deficiencia Auditiva em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if ((defAuditivo) != "")
            {
                if (defAuditivo != "S" && defAuditivo != "N")
                {
                    error = "Campo Deficiencia Auditiva inválido.";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }
                ResumoValidacao.CountValid++;
                return true;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Deficiencia Mental em branco
        public static bool IsDefMental(string defMental, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(defMental))
            {
                error = "Campo Deficiencia Mental em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if ((defMental) != "")
            {
                if (defMental != "S" && defMental != "N")
                {
                    error = "Campo Deficiencia Mental inválido.";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }
                ResumoValidacao.CountValid++;
                return true;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Deficiencia Intelectual em branco
        public static bool IsDefIntelectual(string defIntelectual, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(defIntelectual))
            {
                error = "Campo Deficiencia Intelectual em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if ((defIntelectual) != "")
            {
                if (defIntelectual != "S" && defIntelectual != "N")
                {
                    error = "Campo Deficiencia Intelectual inválido.";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }
                ResumoValidacao.CountValid++;
                return true;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Deficiencia Reabilitado em branco
        //public static bool IsReabReadp(string reabReadp, out string error)
        //{
        //    error = string.Empty;

        //    if (string.IsNullOrWhiteSpace(reabReadp))
        //    {
        //        error = "Campo Deficiencia Intelectual em branco";
        //        ResumoValidacao.CountEmpty++;
        //        return false;
        //    }

        //    if ((reabReadp) != "")
        //    {
        //        if (reabReadp != "S" && reabReadp != "N")
        //        {
        //            error = "Campo Deficiencia Reabilitado inválido.";
        //            ResumoValidacao.CountEmpty++;
        //            return false;
        //        }
        //        ResumoValidacao.CountValid++;
        //        return true;
        //    }
        //    ResumoValidacao.CountValid++;
        //    return true;
        //}

        //Validar Trabalhador Aposentado em branco
        public static bool IsTrabAposent(string trabAposent, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(trabAposent))
            {
                error = "Campo Trabalhador Aposentado em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if ((trabAposent) != "")
            {
                if (trabAposent != "S" && trabAposent != "N")
                {
                    error = "Campo Trabalhador Aposentado inválido.";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }
                ResumoValidacao.CountValid++;
                return true;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Telefone Principal em branco
        public static bool IsFonePrinc(string fonePrinc, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(fonePrinc))
            {
                error = "Campo Telefone Principal em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if ((fonePrinc) != "")
            {
                if (fonePrinc.Length < 9)
                {
                    error = "Campo Telefone Principal inválido.";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }
                ResumoValidacao.CountValid++;
                return true;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Telefone Alternativo em branco
        public static bool IsFoneAlternat(string foneAlternat, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(foneAlternat))
            {
                error = "Campo Telefone Alternativo em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if ((foneAlternat) != "")
            {
                if (foneAlternat.Length < 9)
                {
                    error = "Campo Telefone Alternativo inválido.";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }
                ResumoValidacao.CountValid++;
                return true;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar E-mail principal em branco
        public static bool IsEmailPrinc(string emailPrinc, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(emailPrinc))
            {
                error = "Campo E-mail Principal em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            //if ((emailPrinc) != "")
            //{
            //    if ()
            //    {
            //        error = "Campo E-mail Principal inválido.";
            //        ResumoValidacao.CountEmpty++;
            //        return false;
            //    }
            //    ResumoValidacao.CountValid++;
            //    return true;
            //}
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar email alternativo em branco
        public static bool IsEmailAlternat(string emailAlternat, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(emailAlternat))
            {
                error = "Campo Trabalhador Aposentado em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            //if ((emailAlternat) != "")
            //{
            //    if (emailAlternat != "S" && emailAlternat != "N")
            //    {
            //        error = "Campo Trabalhador Aposentado inválido.";
            //        ResumoValidacao.CountEmpty++;
            //        return false;
            //    }
            //    ResumoValidacao.CountValid++;
            //    return true;
            //}
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Trabalhador Aposentado em branco
        public static bool IsMatricula(string matricula, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(matricula))
            {
                error = "Campo Trabalhador Aposentado em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Tipo de Regime Trabalhista em branco
        public static bool IsTpRegTrab(Nullable<int> tpRegTrab, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(tpRegTrab.ToString()))
            {
                error = "Campo Tipo de Regime Trabalhista em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if ((tpRegTrab.ToString()) != "")
            {
                if ((tpRegTrab != 1 || tpRegTrab != 2))
                {
                    error = "Campo Tipo de Regime Trabalhista inválido.";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }
                ResumoValidacao.CountValid++;
                return true;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Tipo de Regime Previdenciario em branco
        //public static bool IsTpRegPrev(Int32 tpRegPrev, out string error)
        //{
        //    error = string.Empty;

        //    if (string.IsNullOrWhiteSpace(tpRegPrev.ToString()))
        //    {
        //        error = "Campo Tipo de Regime Previdenciário em branco";
        //        ResumoValidacao.CountEmpty++;
        //        return false;
        //    }

        //    if ((tpRegPrev.ToString()) != "")
        //    {
        //        if ((tpRegPrev != 1 || tpRegPrev != 2 || tpRegPrev != 3))
        //        {
        //            error = "Campo Tipo de Regime Previdenciário inválido.";
        //            ResumoValidacao.CountEmpty++;
        //            return false;
        //        }
        //        ResumoValidacao.CountValid++;
        //        return true;
        //    }
        //    ResumoValidacao.CountValid++;
        //    return true;
        //}

        //Data Admissão
        public static bool IsDtAdm(Nullable<DateTime> dtAdm, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(dtAdm.ToString()))
            {
                error = "Campo Tipo de Regime Previdenciário em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            //if ((dtAdm.ToString()) != "")
            //{
            //    if ((dtAdm)  (data_nascimento_usuario))
            //    {
            //        error = "Campo Tipo de Regime Previdenciário inválido.";
            //        ResumoValidacao.CountEmpty++;
            //        return false;
            //    }
            //    ResumoValidacao.CountValid++;
            //    return true;
            //}
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Tipo de Admissao em branco
        public static bool IsTpAdmissao(Nullable<int> tpAdmissao, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(tpAdmissao.ToString()))
            {
                error = "Campo Tipo de Admissao em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if ((tpAdmissao.ToString()) != "")
            {
                if ((tpAdmissao < 1 || tpAdmissao > 4))
                {
                    error = "Campo Tipo de Admissao inválido.";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }
                ResumoValidacao.CountValid++;
                return true;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Indicativo Admissao em branco
        //public static bool IsIndAdmissao(Nullable<int> indAdmissao, out string error)
        //{
        //    error = string.Empty;

        //    if (string.IsNullOrWhiteSpace(indAdmissao.ToString()))
        //    {
        //        error = "Campo Indicativo Admissao em branco";
        //        ResumoValidacao.CountEmpty++;
        //        return false;
        //    }

        //    if ((indAdmissao.ToString()) != "")
        //    {
        //        if ((indAdmissao < 1 || indAdmissao > 3))
        //        {
        //            error = "Campo Indicativo Admissao inválido.";
        //            ResumoValidacao.CountEmpty++;
        //            return false;
        //        }
        //        ResumoValidacao.CountValid++;
        //        return true;
        //    }
        //    ResumoValidacao.CountValid++;
        //    return true;
        //}

        //Validar Regime de jornada em branco
        public static bool IsTpRegJor(Nullable<int> tpRegJor, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(tpRegJor.ToString()))
            {
                error = "Campo Regime de Jornada em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if ((tpRegJor.ToString()) != "")
            {
                if ((tpRegJor < 1 || tpRegJor > 3))
                {
                    error = "Campo Regime de Jornada  inválido.";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }
                ResumoValidacao.CountValid++;
                return true;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Natureza Atividade em branco
        public static bool IsNatAtividade(Nullable<int> natAtividade, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(natAtividade.ToString()))
            {
                error = "Campo Natureza Atividade em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if ((natAtividade.ToString()) != "")
            {
                if ((natAtividade < 1 || natAtividade > 2))
                {
                    error = "Campo Natureza Atividade inválido.";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }
                ResumoValidacao.CountValid++;
                return true;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Natureza Atividade em branco
        public static bool IsDtBase(Nullable<int> dtBase, out string error)
        {
            error = string.Empty;

            if (!dtBase.HasValue)
            {
                error = "Campo Data Atividade em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if (dtBase.HasValue)
            {
                if ((dtBase < 1 || dtBase > 12))
                {
                    error = "Campo Data Atividade inválido.";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }
                ResumoValidacao.CountValid++;
                return true;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar CNPJ Sindicato em branco
        public static bool IsCnpjSindCategProf(string cnpjSindCategProf, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(cnpjSindCategProf.ToString()))
            {
                error = "Campo CNPJ do Sindicato em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if ((cnpjSindCategProf) != "")
            {
                int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int soma;
                int resto;
                string digito;
                string tempCnpj;

                cnpjSindCategProf = cnpjSindCategProf.Trim();
                cnpjSindCategProf = cnpjSindCategProf.Replace(".", "").Replace("-", "").Replace("/", "");

                if (cnpjSindCategProf.Length != 14)
                {
                    error = "Campo CNPJ do Sindicato inválido.";
                    ResumoValidacao.CountInvalid++;
                    return false;
                }

                tempCnpj = cnpjSindCategProf.Substring(0, 12);
                soma = 0;
                for (int i = 0; i < 12; i++)
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
                resto = (soma % 11);
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = resto.ToString();
                tempCnpj = tempCnpj + digito;
                soma = 0;
                for (int i = 0; i < 13; i++)
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
                resto = (soma % 11);
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = digito + resto.ToString();
                return cnpjSindCategProf.EndsWith(digito);
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar FGTS em branco
        //public static bool IsOpcFgts(Nullable<int> opcFgts, out string error)
        //{
        //    error = string.Empty;

        //    if (string.IsNullOrWhiteSpace(opcFgts.ToString()))
        //    {
        //        error = "Campo Opção FTGS em branco";
        //        ResumoValidacao.CountEmpty++;
        //        return false;
        //    }

        //    if ((opcFgts.ToString()) != "")
        //    {
        //        if ((opcFgts < 1 || opcFgts > 2))
        //        {
        //            error = "Campo Opção FTGS inválida.";
        //            ResumoValidacao.CountEmpty++;
        //            return false;
        //        }
        //        ResumoValidacao.CountValid++;
        //        return true;
        //    }
        //    ResumoValidacao.CountValid++;
        //    return true;
        //}

        //Validar data FGTS em branco
        public static bool IsDtOpcFgts(Nullable<DateTime> dtOpcFgts, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(dtOpcFgts.ToString()))
            {
                error = "Campo Data Opção FTGS em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar MTV contratação em branco
        //public static bool IsMtvContrat(Nullable<int> mtvContrat, out string error)
        //{
        //    error = string.Empty;

        //    if (string.IsNullOrWhiteSpace(mtvContrat.ToString()))
        //    {
        //        error = "Campo Motivo Contratação em branco";
        //        ResumoValidacao.CountEmpty++;
        //        return false;
        //    }

        //    if ((mtvContrat.ToString()) != "")
        //    {
        //        if ((mtvContrat < 1 || mtvContrat > 2))
        //        {
        //            error = "Campo Motivo Contratação inválido.";
        //            ResumoValidacao.CountEmpty++;
        //            return false;
        //        }
        //        ResumoValidacao.CountValid++;
        //        return true;
        //    }
        //    ResumoValidacao.CountValid++;
        //    return true;
        //}

        //Validar Tipo de Inscrição contratação em branco
        //public static bool IsTpInsc(Nullable<int> tpInsc, out string error)
        //{
        //    error = string.Empty;

        //    if (string.IsNullOrWhiteSpace(tpInsc.ToString()))
        //    {
        //        error = "Campo Tipo de Inscrição Contratação em branco";
        //        ResumoValidacao.CountEmpty++;
        //        return false;
        //    }

        //    if ((tpInsc.ToString()) != "")
        //    {
        //        if ((tpInsc < 1 || tpInsc > 2))
        //        {
        //            error = "Campo Tipo de Inscrição Contratação inválido.";
        //            ResumoValidacao.CountEmpty++;
        //            return false;
        //        }
        //        ResumoValidacao.CountValid++;
        //        return true;
        //    }
        //    ResumoValidacao.CountValid++;
        //    return true;
        //}

        //Validar numero inscrição em branco
        //public static bool IsNrInsc(Nullable<int> tpInsc, string nrInsc, out string error)
        //{
        //    error = string.Empty;

        //    if (string.IsNullOrWhiteSpace(nrInsc.ToString()))
        //    {
        //        error = "Campo Tipo de Inscrição Contratação em branco";
        //        ResumoValidacao.CountEmpty++;
        //        return false;
        //    }

        //    if ((nrInsc.ToString()) != "")
        //    {
        //        if ((tpInsc == 1))
        //        {
        //            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        //            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        //            int soma;
        //            int resto;
        //            string digito;
        //            string tempCnpj;

        //            nrInsc = nrInsc.Trim();
        //            nrInsc = nrInsc.Replace(".", "").Replace("-", "").Replace("/", "");

        //            if (nrInsc.Length != 14)
        //            {
        //                error = "Campo CNPJ do Sindicato inválido.";
        //                ResumoValidacao.CountInvalid++;
        //                return false;
        //            }

        //            tempCnpj = nrInsc.Substring(0, 12);
        //            soma = 0;
        //            for (int i = 0; i < 12; i++)
        //                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
        //            resto = (soma % 11);
        //            if (resto < 2)
        //                resto = 0;
        //            else
        //                resto = 11 - resto;
        //            digito = resto.ToString();
        //            tempCnpj = tempCnpj + digito;
        //            soma = 0;
        //            for (int i = 0; i < 13; i++)
        //                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
        //            resto = (soma % 11);
        //            if (resto < 2)
        //                resto = 0;
        //            else
        //                resto = 11 - resto;
        //            digito = digito + resto.ToString();
        //            return nrInsc.EndsWith(digito);
        //        }
        //        if ((tpInsc == 2))
        //        {
        //            if (nrInsc.Length > 11)
        //            {
        //                error = "CPF Inválido";
        //                ResumoValidacao.CountInvalid++;
        //                return false;
        //            }

        //            while (nrInsc.Length != 11)
        //                nrInsc = '0' + nrInsc;

        //            bool igual = true;
        //            for (int i = 1; i < 11 && igual; i++)
        //                if (nrInsc[i] != nrInsc[0])
        //                    igual = false;

        //            if (igual || nrInsc == "12345678909")
        //            {
        //                error = "CPF Inválido";
        //                ResumoValidacao.CountInvalid++;
        //                return false;
        //            }

        //            int[] numeros = new int[11];

        //            for (int i = 0; i < 11; i++)
        //                numeros[i] = int.Parse(nrInsc[i].ToString());

        //            int soma = 0;
        //            for (int i = 0; i < 9; i++)
        //                soma += (10 - i) * numeros[i];

        //            int resultado = soma % 11;

        //            if (resultado == 1 || resultado == 0)
        //            {
        //                if (numeros[9] != 0)
        //                {
        //                    error = "CPF Inválido";
        //                    ResumoValidacao.CountInvalid++;
        //                    return false;
        //                }
        //            }
        //            else if (numeros[9] != 11 - resultado)
        //            {
        //                error = "CPF Inválido";
        //                ResumoValidacao.CountInvalid++;
        //                return false;
        //            }

        //            soma = 0;
        //            for (int i = 0; i < 10; i++)
        //                soma += (11 - i) * numeros[i];

        //            resultado = soma % 11;

        //            if (resultado == 1 || resultado == 0)
        //            {
        //                if (numeros[10] != 0)
        //                {
        //                    error = "CPF Inválido";
        //                    ResumoValidacao.CountInvalid++;
        //                    return false;
        //                }
        //            }
        //            else
        //                if (numeros[10] != 11 - resultado)
        //            {
        //                error = "CPF Inválido";
        //                ResumoValidacao.CountInvalid++;
        //                return false;
        //            }

        //            ResumoValidacao.CountValid++;
        //            return true;

        //        }
        //        ResumoValidacao.CountValid++;
        //        return true;
        //    }
        //    ResumoValidacao.CountValid++;
        //    return true;
        //}

        //Validar cpf Substituto invalido ou em branco
        public static bool IsCpfTrabSubst(string cpfTrabSubst, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(cpfTrabSubst))
            {
                error = "CPF em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if ((cpfTrabSubst) != "")
            {
                if (cpfTrabSubst.Length > 11)
                {
                    error = "CPF Inválido";
                    ResumoValidacao.CountInvalid++;
                    return false;
                }

                while (cpfTrabSubst.Length != 11)
                    cpfTrabSubst = '0' + cpfTrabSubst;

                bool igual = true;
                for (int i = 1; i < 11 && igual; i++)
                    if (cpfTrabSubst[i] != cpfTrabSubst[0])
                        igual = false;

                if (igual || cpfTrabSubst == "12345678909")
                {
                    error = "CPF Inválido";
                    ResumoValidacao.CountInvalid++;
                    return false;
                }

                int[] numeros = new int[11];

                for (int i = 0; i < 11; i++)
                    numeros[i] = int.Parse(cpfTrabSubst[i].ToString());

                int soma = 0;
                for (int i = 0; i < 9; i++)
                    soma += (10 - i) * numeros[i];

                int resultado = soma % 11;

                if (resultado == 1 || resultado == 0)
                {
                    if (numeros[9] != 0)
                    {
                        error = "CPF Inválido";
                        ResumoValidacao.CountInvalid++;
                        return false;
                    }
                }
                else if (numeros[9] != 11 - resultado)
                {
                    error = "CPF Inválido";
                    ResumoValidacao.CountInvalid++;
                    return false;
                }

                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += (11 - i) * numeros[i];

                resultado = soma % 11;

                if (resultado == 1 || resultado == 0)
                {
                    if (numeros[10] != 0)
                    {
                        error = "CPF Inválido";
                        ResumoValidacao.CountInvalid++;
                        return false;
                    }
                }
                else
                    if (numeros[10] != 11 - resultado)
                {
                    error = "CPF Inválido";
                    ResumoValidacao.CountInvalid++;
                    return false;
                }

                ResumoValidacao.CountValid++;
                return true;

            }
            ResumoValidacao.CountValid++;
            return true;

        }

        //Validar Matricula trabalhador em branco
        public static bool IsmatricTrabSubst(string matricTrabSubst, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(matricTrabSubst))
            {
                error = "Matricula Trabalhador (RET) em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        ////Validar Provimento em branco
        //public static bool IsIndProvim(Nullable<int> indProvim, out string error)
        //{
        //    error = string.Empty;

        //    if (string.IsNullOrWhiteSpace(indProvim.ToString()))
        //    {
        //        error = "Provimento em branco";
        //        ResumoValidacao.CountEmpty++;
        //        return false;
        //    }
        //    if ((indProvim.ToString()) != "")
        //    {
        //        if (indProvim < 1 || indProvim > 3)
        //        {
        //            error = "Provimento inálido.";
        //            ResumoValidacao.CountEmpty++;
        //            return false;
        //        }
        //        ResumoValidacao.CountValid++;
        //        return true;
        //    }
        //    ResumoValidacao.CountValid++;
        //    return true;
        //}

        ////Validar Tipo do Provimento em branco
        //public static bool IsTpProv(Nullable<int> tpProv, out string error)
        //{
        //    error = string.Empty;

        //    if (string.IsNullOrWhiteSpace(tpProv.ToString()))
        //    {
        //        error = "Tipo Provimento em branco";
        //        ResumoValidacao.CountEmpty++;
        //        return false;
        //    }
        //    if ((tpProv.ToString()) != "")
        //    {
        //        if (tpProv < 1 || tpProv > 3)
        //        {
        //            error = "Tipo Provimento inválido.";
        //            ResumoValidacao.CountEmpty++;
        //            return false;
        //        }
        //        ResumoValidacao.CountValid++;
        //        return true;
        //    }
        //    ResumoValidacao.CountValid++;
        //    return true;
        //}

        ////Validar Data Nomeação em branco
        //public static bool IsDtNomeacao(DateTime dtNomeacao, out string error)
        //{
        //    error = string.Empty;

        //    if (string.IsNullOrWhiteSpace(dtNomeacao))
        //    {
        //        error = "Data Nomeação em branco";
        //        ResumoValidacao.CountEmpty++;
        //        return false;
        //    }
        //    ResumoValidacao.CountValid++;
        //    return true;
        //}

        ////Validar Data Posse em branco
        //public static bool IsDtPosse(DateTime dtPosse, out string error)
        //{
        //    error = string.Empty;

        //    if (string.IsNullOrWhiteSpace(dtPosse.ToString()))
        //    {
        //        error = "Data Posse em branco";
        //        ResumoValidacao.CountEmpty++;
        //        return false;
        //    }
        //    ResumoValidacao.CountValid++;
        //    return true;
        //}

        ////Validar Matricula trabalhador em branco
        //public static bool IsDtExercicio(Nullable<int> indProvim, DateTime dtExercicio, out string error)
        //{
        //    error = string.Empty;

        //    if (indProvim == 1 || indProvim == 2)
        //    {
        //        if (string.IsNullOrWhiteSpace(dtExercicio.ToString()))
        //        {
        //            error = "Data do Exercício em branco";
        //            ResumoValidacao.CountEmpty++;
        //            return false;
        //        }
        //    }
        //    ResumoValidacao.CountValid++;
        //    return true;
        //}

        //Validar Codigo Cargo trabalhador em branco
        //public static bool IsCodCargo(Nullable<int> tpProv, Nullable<int> codCargo, out string error)
        //{
        //    error = string.Empty;

        //    if (tpProv != 2)
        //    {
        //        if (string.IsNullOrWhiteSpace(codCargo.ToString()))
        //        {
        //            error = "Codigo Cargo em branco";
        //            ResumoValidacao.CountEmpty++;
        //            return false;
        //        }
        //    }
        //    ResumoValidacao.CountValid++;
        //    return true;
        //}

        ////Validar Codigo Função trabalhador em branco
        //public static bool IsCodFuncao(Nullable<int> tpProv, Nullable<int> codFuncao, out string error)
        //{
        //    error = string.Empty;

        //    if (tpProv != 2)
        //    {
        //        if (string.IsNullOrWhiteSpace(codFuncao.ToString()))
        //        {
        //            error = "Codigo Funcao em branco";
        //            ResumoValidacao.CountEmpty++;
        //            return false;
        //        }
        //    }
        //    ResumoValidacao.CountValid++;
        //    return true;
        //}

        ////Validar Codigo Categoria trabalhador em branco
        //public static bool IsCodCateg(Nullable<int> codCateg, out string error)
        //{
        //    error = string.Empty;
        //    if (string.IsNullOrWhiteSpace(codCateg.ToString()))
        //    {
        //        error = "Codigo Categoria em branco";
        //        ResumoValidacao.CountEmpty++;
        //        return false;
        //    }
        //    ResumoValidacao.CountValid++;
        //    return true;
        //}

        //Validar Natureza Atividade em branco
        public static bool IsVrSalFx(decimal vrSalFx, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(vrSalFx.ToString()))
            {
                error = "Salário Fixo em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Unidade Salario Fixo em branco
        public static bool IsUndSalFixo(Nullable<int> undSalFixo, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(undSalFixo.ToString()))
            {
                error = "Salário Fixo em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if (undSalFixo < 1 || undSalFixo > 7)
            {
                error = "Unidade Salario Fixo inválida.";
                ResumoValidacao.CountInvalid++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Descrição dalário variavel em branco
        public static bool IsDescSalvar(Nullable<int> undSalFixo, string descSalvar, out string error)
        {
            error = string.Empty;

            if (undSalFixo == 7)
            {
                error = "Salário Fixo em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Tipo de Contrato em branco
        public static bool IsTpContr(Nullable<int> tpContr, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(tpContr.ToString()))
            {
                error = "Campo Tipo de contrato em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if ((tpContr.ToString()) != "")
            {
                if ((tpContr < 1 || tpContr > 2))
                {
                    error = "Campo Tipo de contrato inválido.";
                    ResumoValidacao.CountInvalid++;
                    return false;
                }
                ResumoValidacao.CountValid++;
                return true;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Data do Termino em branco
        public static bool IsDtTerm(Nullable<int> tpContr, DateTime dtTermino, out string error)
        {
            error = string.Empty;

            if (tpContr == 2)
            {
                error = "Campo Data do Término em branco.";
                ResumoValidacao.CountInvalid++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Tipo inscrição local de trabalho branco
        public static bool IsTpInscLocalTrab(string tpInscLocalTrab, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(tpInscLocalTrab.ToString()))
            {
                error = "Campo Tipo de contrato em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if ((tpInscLocalTrab.ToString()) != "")
            {
                if ((tpInscLocalTrab != "1" || tpInscLocalTrab != "3" || tpInscLocalTrab != "4"))
                {
                    error = "Campo Tipo de contrato inválido.";
                    ResumoValidacao.CountInvalid++;
                    return false;
                }
                ResumoValidacao.CountValid++;
                return true;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar numero inscrição local de trabalho branco
        public static bool IsNrInscLocalTrab(Nullable<int> nrInscLocalTrab, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(nrInscLocalTrab.ToString()))
            {
                error = "Campo Tipo de contrato em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Descrição local de trabalho branco
        public static bool IsDescCompLocalTrab(string descCompLocalTrab, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(descCompLocalTrab))
            {
                error = "Campo Tipo de contrato em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        public static bool IstpLogradDom(string cepDom, string tpLogradDom, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(tpLogradDom))
            {
                error = "Tipo de Logradouro Doméstico em branco";
                ResumoValidacao.CountInvalid++;
                return false;
            }

            if (!string.IsNullOrWhiteSpace(tpLogradDom.ToString()))
            {
                wsCorreios.AtendeClienteClient ws = new wsCorreios.AtendeClienteClient();
                try
                {
                    var result = ws.consultaCEP(cepDom.Replace("-", "").Replace(".", "").Trim());

                    if (result != null)
                    {
                        if (result.end.Contains(tpLogradDom))
                            return true;
                        else
                        {
                            error = "Tipo de logradouro Doméstico inválido.";
                            ResumoValidacao.CountInvalid++;
                            return false;
                        }
                    }
                    else
                    {
                        error = "Tipo de logradouro Doméstico inválido.";
                    }
                }
                catch (Exception ex)
                {
                    error = "Tipo de logradouro Doméstico inválido.";
                    ResumoValidacao.CountInvalid++;
                    return false;
                }
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        // //Validar Descrição Logradouro em branco e Invalido
        public static bool IsdescLogradDom(string cepDom, string desLogradDom, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(desLogradDom))
            {
                error = "Endereço Trabalhador Doméstico em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if (!string.IsNullOrWhiteSpace(cepDom))
            {
                wsCorreios.AtendeClienteClient ws = new wsCorreios.AtendeClienteClient();
                try
                {
                    var result = ws.consultaCEP(cepDom.Replace("-", "").Replace(".", "").Trim());

                    if (result != null)
                    {
                        if (result.end.Contains(desLogradDom))
                            return true;
                        else
                        {
                            error = "Descrição logradouro Doméstico inválido.";
                            ResumoValidacao.CountInvalid++;
                            return false;
                        }
                    }
                    else
                    {
                        error = "Descrição logradouro Doméstico inválido.";
                    }
                }
                catch (Exception ex)
                {
                    error = "Logradouro Doméstico inválido.";
                    ResumoValidacao.CountInvalid++;
                    return false;
                }
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Numero Logradouro em branco
        public static bool IsnrLogradDom(string nrLogradDom, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(nrLogradDom))
            {
                error = "Nº Logradouro Doméstico em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Complemento Logradouro em branco
        public static bool IscomplementoDom(string complementoDom, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(complementoDom))
            {
                error = "Complemento Logradouro Doméstico em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Bairro em branco
        public static bool IsbairroDom(string cepDom, string bairroDom, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(bairroDom))
            {
                error = "Bairro Doméstico em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }
            if (!string.IsNullOrWhiteSpace(cepDom))
            {
                wsCorreios.AtendeClienteClient ws = new wsCorreios.AtendeClienteClient();
                try
                {
                    var result = ws.consultaCEP(cepDom.Replace("-", "").Replace(".", "").Trim());

                    if (result != null)
                    {
                        if (result.bairro.Contains(bairroDom))
                            return true;
                        else
                        {
                            error = "Bairro Doméstico inválido.";
                            ResumoValidacao.CountInvalid++;
                            return false;
                        }
                    }
                    else
                    {
                        error = "Bairro  Domésticoinválido.";
                    }
                }
                catch (Exception ex)
                {
                    error = "Bairro Doméstico inválido.";
                    ResumoValidacao.CountInvalid++;
                    return false;
                }
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        // //Validar cep em branco
        public static bool IsCepDom(string cepDom, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(cepDom))
            {
                error = "CEP Doméstico em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if ((cepDom) != "")
            {
                wsCorreios.AtendeClienteClient ws = new wsCorreios.AtendeClienteClient();
                try
                {
                    var result = ws.consultaCEP(cepDom.Replace("-", "").Replace(".", "").Trim());

                    if (result != null)
                        return true;
                    else
                    {
                        error = "CEP Doméstico inválido.";
                    }
                }
                catch (Exception ex)
                {
                    error = ex.Message;
                    ResumoValidacao.CountInvalid++;
                    return false;
                }
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Cidade em branco e cidade invalida
        public static bool IsCodMunicipioEndDom(string cepDom, string codMunicipioDom, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(codMunicipioDom))
            {
                error = "Codigo Municipio Doméstico em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if (!string.IsNullOrWhiteSpace(cepDom))
            {
                wsCorreios.AtendeClienteClient ws = new wsCorreios.AtendeClienteClient();
                try
                {
                    var result = ws.consultaCEP(cepDom.Replace("-", "").Replace(".", "").Trim());

                    if (result != null)
                    {
                        if (result.end.Contains(codMunicipioDom))
                            return true;
                        else
                        {
                            error = "Codigo Municipio Doméstico inválido.";
                            ResumoValidacao.CountEmpty++;
                            return false;
                        }
                    }
                    else
                    {
                        error = "Codigo Municipio Doméstico inválido.";
                    }
                }
                catch (Exception ex)
                {
                    error = "Codigo Municipio Doméstico inválido.";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar UF em branco e cidade invalida
        public static bool IsUfEndDom(string cepDom, string ufDom, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(ufDom))
            {
                error = "UF do Trabalhador Doméstico em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if (!string.IsNullOrWhiteSpace(cepDom))
            {
                wsCorreios.AtendeClienteClient ws = new wsCorreios.AtendeClienteClient();
                try
                {
                    var result = ws.consultaCEP(cepDom.Replace("-", "").Replace(".", "").Trim());

                    if (result != null)
                    {
                        if (result.end.Contains(ufDom))
                            return true;
                        else
                        {
                            error = "UF oméstico inválida.";
                            ResumoValidacao.CountEmpty++;
                            return false;
                        }
                    }
                    else
                    {
                        error = "UF inválida.";
                    }
                }
                catch (Exception ex)
                {
                    error = "UF Doméstico inválida.";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Horário contratual em branco
        public static bool IsQtdHrsSem(Nullable<int> qtdHrsSem, Nullable<int> tpRegJor, out string error)
        {
            error = string.Empty;
            if (tpRegJor == 1)
            {
                error = string.Empty;

                if (string.IsNullOrWhiteSpace(qtdHrsSem.ToString()))
                {
                    error = "Quantidade horas semanal em branco";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }
                ResumoValidacao.CountValid++;
                return true;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Tipo de Jornada contratual em branco
        public static bool IsTpJornada(Nullable<int> tpJornada, Nullable<int> tpRegJor, out string error)
        {
            error = string.Empty;
            if (tpRegJor == 1)
            {
                error = string.Empty;

                if (string.IsNullOrWhiteSpace(tpJornada.ToString()))
                {
                    error = "Tipo de jornada em branco";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }

                if (tpJornada < 1 || tpJornada > 2)
                {
                    error = "Tipo de jornada inválida.";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }
                ResumoValidacao.CountValid++;
                return true;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Tipo de Jornada contratual em branco
        public static bool IsDscTpJorn(Nullable<int> tpJornada, Nullable<int> dscTpJorn, Nullable<int> tpRegJor, out string error)
        {
            error = string.Empty;
            if (tpRegJor == 1)
            {
                error = string.Empty;

                if (string.IsNullOrWhiteSpace(dscTpJorn.ToString()))
                {
                    error = "Descrição da jornada em branco";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }

                if (tpJornada == 2)
                {
                    error = "Tipo de jornada inválida.";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }
                ResumoValidacao.CountValid++;
                return true;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Dia em branco
        public static bool IsDia(Nullable<int> dia, Nullable<int> tpRegJor, out string error)
        {
            error = string.Empty;
            if (tpRegJor == 1)
            {
                error = string.Empty;

                if (string.IsNullOrWhiteSpace(dia.ToString()))
                {
                    error = "Dia em branco";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }

                if (dia < 1 || dia > 8)
                {
                    error = "Dia inválida.";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }
                ResumoValidacao.CountValid++;
                return true;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Codigo de horas em branco
        public static bool IsCodHorContrat(string codHorContrat, Nullable<int> tpRegJor, out string error)
        {
            error = string.Empty;
            if (tpRegJor == 1)
            {
                error = string.Empty;

                if (string.IsNullOrWhiteSpace(codHorContrat.ToString()))
                {
                    error = "Codigo de Hora Contratual em branco";
                    ResumoValidacao.CountEmpty++;
                    return false;
                }
                ResumoValidacao.CountValid++;
                return true;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar CNPJ Sindicato em branco
        public static bool IsCnpjSindTrab(string cnpjSindTrab, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(cnpjSindTrab.ToString()))
            {
                error = "Campo CNPJ do Sindicato em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if ((cnpjSindTrab) != "")
            {
                int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int soma;
                int resto;
                string digito;
                string tempCnpj;

                cnpjSindTrab = cnpjSindTrab.Trim();
                cnpjSindTrab = cnpjSindTrab.Replace(".", "").Replace("-", "").Replace("/", "");

                if (cnpjSindTrab.Length != 14)
                {
                    error = "Campo CNPJ do Sindicato inválido.";
                    ResumoValidacao.CountInvalid++;
                    return false;
                }

                tempCnpj = cnpjSindTrab.Substring(0, 12);
                soma = 0;
                for (int i = 0; i < 12; i++)
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
                resto = (soma % 11);
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = resto.ToString();
                tempCnpj = tempCnpj + digito;
                soma = 0;
                for (int i = 0; i < 13; i++)
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
                resto = (soma % 11);
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = digito + resto.ToString();
                return cnpjSindTrab.EndsWith(digito);
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Nº Processo Judicial em branco
        public static bool IsNrProcJud(string nrProcJud, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(nrProcJud) && nrProcJud != "null")
            {
                error = "Nº Processo Judicial em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar CNPJ Empregador Anterior em branco
        public static bool IsCnpjEmpregAnt(string cnpjEmpregAnt, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(cnpjEmpregAnt.ToString()) && cnpjEmpregAnt != "null")
            {
                error = "Campo CNPJ Empregador Anterior em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }

            if ((cnpjEmpregAnt) != "")
            {
                int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int soma;
                int resto;
                string digito;
                string tempCnpj;

                cnpjEmpregAnt = cnpjEmpregAnt.Trim();
                cnpjEmpregAnt = cnpjEmpregAnt.Replace(".", "").Replace("-", "").Replace("/", "");

                if (cnpjEmpregAnt.Length != 14)
                {
                    error = "Campo CNPJ do Empregador Anterior inválido.";
                    ResumoValidacao.CountInvalid++;
                    return false;
                }

                tempCnpj = cnpjEmpregAnt.Substring(0, 12);
                soma = 0;
                for (int i = 0; i < 12; i++)
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
                resto = (soma % 11);
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = resto.ToString();
                tempCnpj = tempCnpj + digito;
                soma = 0;
                for (int i = 0; i < 13; i++)
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
                resto = (soma % 11);
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = digito + resto.ToString();
                return cnpjEmpregAnt.EndsWith(digito);
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar Nº Matricula trabalhador no empregador anterior em branco
        public static bool IsMatricAnt(string matricAnt, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(matricAnt) && matricAnt != "null")
            {
                error = "Matricula do Trabalhador Anterior em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        ////Validar data inicio vinculo em branco
        ////public static bool IsDtIniVinculo(DateTime dtIniVinculo, out string error)
        ////{
        ////    error = string.Empty;

        ////    if (string.IsNullOrWhiteSpace(dtIniVinculo.ToString()))
        ////    {
        ////        error = "Data Inicial do Vinculo em branco";
        ////        ResumoValidacao.CountEmpty++;
        ////        return false;
        ////    }
        ////    ResumoValidacao.CountValid++;
        ////    return true;
        ////}

        ////Validar data inicio vinculo em branco
        ////public static bool IsDtIniAfast(DateTime dtIniAfast, out string error)
        ////{
        ////    error = string.Empty;

        ////    if (string.IsNullOrWhiteSpace(dtIniAfast.ToString()))
        ////    {
        ////        error = "Data Iniciio Asfastamento em branco";
        ////        ResumoValidacao.CountEmpty++;
        ////        return false;
        ////    }
        ////    ResumoValidacao.CountValid++;
        ////    return true;
        ////}

        //Validar Codigo Motivo Asfastamento em branco
        public static bool IsCodMotAfast(string codMotAfast, out string error)
        {
            error = string.Empty;

            if (string.IsNullOrWhiteSpace(codMotAfast) && codMotAfast != "null")
            {
                error = "Codigo Motivo Afastamento em branco";
                ResumoValidacao.CountEmpty++;
                return false;
            }
            ResumoValidacao.CountValid++;
            return true;
        }

        //Validar data desligamento em branco
        //public static bool IsDtDeslig(DateTime dtDeslig, out string error)
        //{
        //    error = string.Empty;

        //    if (string.IsNullOrWhiteSpace(dtDeslig.ToString()))
        //    {
        //        error = "Data Desligamento em branco";
        //        ResumoValidacao.CountEmpty++;
        //        return false;
        //    }
        //    ResumoValidacao.CountValid++;
        //    return true;
        //}




    }
}
