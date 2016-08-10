using Portal.Business.Helpers;
using Portal.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Portal.Business.Repositories
{
    public partial class ContatoRepository :  EFRepository<Usuario>
    {
        public AccountContatoRepository() : base("dbEF") { }       

        public void Salvar(Contato entity)
        {
            try
            {
                if (entity.id_contato == 0)
                    entity.dh_cadastro = DateTime.Now;

                if (!this.IsValidEntity(entity))
                {
                    throw new PstException(string.Format("{0}{1}{2}", MessagesPst.ErpDataValidation, Environment.NewLine, string.Join(Environment.NewLine, this.GetErrorsEntity())));
                }
                else
                {
                    entity.cnpj_cpf = Gd.Util.StringHelper.Clear(entity.cnpj_cpf ?? string.Empty, "0123456789");                    

                    if (entity.id_contato > 0)
                        this.Update(entity);
                    else
                        this.Save(entity);
                }

            }
            catch (Exception ex)
            {
                LogPst.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

        public void Excluir(int id_empresa, int[] values)
        {
            try
            {
                Array.ForEach<int>(values, delegate(int value){
                    this.DeleteNotSaveChanges(c => c.id_empresa == id_empresa && c.id_contato == value);
                });

                this.SaveChanges();
            }
            catch (Exception ex)
            {
                LogPst.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

        public Contato Obter(int id_empresa, int id_contato)
        {
            try
            {
                return this.FindSingleBy(f => f.id_empresa == id_empresa && f.id_contato == id_contato);

            }
            catch (Exception ex)
            {
                LogPst.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

        public Pagination<Contato> Listar(int id_empresa, string ocorrencia, int? page, int? limit)
        {
            try
            {
                if (string.IsNullOrEmpty(ocorrencia))
                {
                    return this.FindAllBy(w => w.id_empresa == id_empresa, o => o.nome_fantasia, page, limit);
                }
                else
                {                    
                    return this.FindAllBy(f => f.id_empresa == id_empresa && 
                                         (f.razao_social.Contains(ocorrencia) ||
                                          f.nome_fantasia.Contains(ocorrencia) ||
                                          f.email.Contains(ocorrencia) ||
                                          f.cnpj_cpf.Contains(ocorrencia)), o => o.nome_fantasia, page, limit);
                }
            }
            catch (Exception ex)
            {
                LogPst.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }
    }
}