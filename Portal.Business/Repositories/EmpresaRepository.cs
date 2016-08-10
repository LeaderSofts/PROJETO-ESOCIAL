using Pst.Business.Helpers;
using Pst.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pst.Business.Repositories
{
    public partial class EmpresaRepository :  EFRepository<Empresa>
    {
        public EmpresaRepository() : base("dbEF") { }       

        public void Salvar(Empresa entity)
        {
            try            
            {       
                if (entity.id_empresa == 0)
                    entity.dh_cadastro = DateTime.Now;

                if (!this.IsValidEntity(entity))
                {
                    throw new PstException(string.Format("{0}{1}{2}", MessagesPst.ErpDataValidation, Environment.NewLine, string.Join(Environment.NewLine, this.GetErrorsEntity())));
                }
                else
                {
                    entity.cnpj = Gd.Util.StringHelper.Clear(entity.cnpj ?? string.Empty, "0123456789");                    

                    if (entity.id_empresa > 0)
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

        public void Excluir(int[] values)
        {
            try
            {
                Array.ForEach<int>(values, delegate(int value){
                    this.DeleteNotSaveChanges(c => c.id_empresa == value);
                });

                this.SaveChanges();
            }
            catch (Exception ex)
            {
                LogPst.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

        public Empresa Obter(int id_empresa)
        {
            try
            {
                return this.FindSingleBy(f => f.id_empresa == id_empresa);

            }
            catch (Exception ex)
            {
                LogPst.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

        public List<Empresa> Listar()
        {
            try
            {
                return this.FindAllOrderBy(u => u.nome_fantasia).ToList();
            }
            catch (Exception ex)
            {
                LogPst.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

        public Pagination<Empresa> Listar(string ocorrencia, int? page, int? limit)
        {
            try
            {
                if (string.IsNullOrEmpty(ocorrencia))
                {
                    return this.FindAllBy(o => o.nome_fantasia, page, limit);
                }
                else
                {
                    return this.FindAllBy(f => f.razao_social.Contains(ocorrencia) ||
                                   f.nome_fantasia.Contains(ocorrencia) ||
                                   f.email.Contains(ocorrencia) ||
                                   f.cnpj.Contains(ocorrencia), o => o.nome_fantasia, page, limit);
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