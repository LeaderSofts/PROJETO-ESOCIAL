using Portal.Business.Helpers;
using Portal.Business.Models;
using Portal.Business.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Portal.Business.Repositories
{
    public partial class CartaoSocioRepository :  EFRepository<CartaoSocio>
    {
        public CartaoSocioRepository() : base("dbEF") { }       
        
        public void Salvar(CartaoSocio entity)
        {
            try
            {        
                if (entity.id_cartao_socio == 0)
                {
                    entity.dh_cad_cartao_socio = DateTime.Now;
                    entity.ativo_cartao_socio = true;                 
                }
                else
                {
                    var objCurrent = this.Obter(entity.id_usuario, entity.id_cartao_socio);

                    if (objCurrent != null)
                    {
                        entity.id_usuario = objCurrent.id_usuario;
                        entity.id_time = objCurrent.id_time;
                        entity.dh_cad_cartao_socio = objCurrent.dh_cad_cartao_socio;
                        entity.ativo_cartao_socio = objCurrent.ativo_cartao_socio;
                            
                        Entry(objCurrent).State = System.Data.Entity.EntityState.Detached;
                    }
                }

                if (!this.IsValidEntity(entity))
                    throw new PortalException(string.Format("{0}{1}{2}", MessagesPortal.PortalDataValidation, Environment.NewLine, string.Join(Environment.NewLine, this.GetErrorsEntity())));
                else
                {
                    if (entity.id_cartao_socio > 0)
                        this.Update(entity);
                    else
                        this.Save(entity);
                }
                
            }
            catch (Exception ex)
            {
                LogUtil.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

        public void Excluir(int id_usuario, params int[] values)
        {
            try
            {
                Array.ForEach<int>(values, delegate(int value)
                {
                    this.DeleteNotSaveChanges(c => c.id_usuario == id_usuario && c.id_cartao_socio == value);
                });

                this.SaveChanges();
            }
            catch (Exception ex)
            {
                LogUtil.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

        public CartaoSocio Obter(int id_usuario, int id_cartao_socio)
        {
            try
            {
                return this.FindSingleBy(f => f.id_usuario == id_usuario &&  f.id_cartao_socio == id_cartao_socio);
            }
            catch (Exception ex)
            {
                LogUtil.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

        public Pagination<CartaoSocio> Listar(int id_usuario, string ocorrencia, int? page, int? limit)
        {
            try
            {
                if (string.IsNullOrEmpty(ocorrencia))
                {
                    return this.FindAllBy(f => f.id_usuario == id_usuario, o => o.id_cartao_socio, SortOrder.Descending, page, limit);
                }
                else
                {
                    return this.FindAllBy(f => f.id_usuario == id_usuario && 
                                         (f.numero_cartao_socio.Contains(ocorrencia) ||
                                          f.modalidade_cartao_socio.Contains(ocorrencia) ||
                                          f.setor_cartao_socio.Contains(ocorrencia)), o => o.numero_cartao_socio, SortOrder.Descending, page, limit);
                }
            }
            catch (Exception ex)
            {
                LogUtil.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

        public Pagination<CartaoSocio> Listar(int id_usuario, bool ativo, int? page, int? limit)
        {
            try
            {             
                return this.FindAllBy(f => f.id_usuario == id_usuario && f.ativo_cartao_socio == ativo, page, limit);
            }
            catch (Exception ex)
            {
                LogUtil.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

        public bool CartaoExists(int id_usuario)
        {
            var count = this.FindAllBy(f=> f.id_usuario == id_usuario && f.ativo_cartao_socio).Count();

            return (count > 0);            
        }


        public List<CartaoSocio> Listar(int id_usario, bool ativo)
        {
            try
            {
                return this.FindAllBy(f => f.id_usuario == id_usario && f.ativo_cartao_socio == ativo).ToList();
            }
            catch (Exception ex)
            {
                LogUtil.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }
    }
}