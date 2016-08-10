using Portal.Business.Helpers;
using Portal.Business.Models;
using Portal.Business.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Portal.Business.Repositories
{
    public partial class AnuncioRepository :  EFRepository<Anuncio>
    {
        public AnuncioRepository() : base("dbEF") { }       
        
        public void Salvar(Anuncio entity)
        {
            try
            {        
                if (entity.id_anuncio == 0)
                {
                    entity.dh_cadastro_anuncio = DateTime.Now;
                    entity.status_anuncio = Anuncio.TypeStatusAnuncio.Disponivel;
                }
                else
                {
                    var objCurrent = this.Obter(entity.id_anuncio);

                    if (objCurrent != null)
                    {
                        entity.id_usuario = objCurrent.id_usuario;
                        entity.id_time = objCurrent.id_time;
                        entity.dh_cadastro_anuncio = objCurrent.dh_cadastro_anuncio;
                        entity.status_anuncio = objCurrent.status_anuncio;
                            
                        Entry(objCurrent).State = System.Data.Entity.EntityState.Detached;
                    }
                }

                if (!this.IsValidEntity(entity))
                    throw new PortalException(string.Format("{0}{1}{2}", MessagesPortal.PortalDataValidation, Environment.NewLine, string.Join(Environment.NewLine, this.GetErrorsEntity())));
                else
                {
                    if (entity.id_anuncio > 0)
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

        public void Bloquear(int id_usuario, long id_anuncio, string motivo)
        {
            try
            {
                var anuncio = this.Obter(id_usuario, id_anuncio);

                if (anuncio != null)
                {
                    anuncio.motivo_bloqueio_anuncio = motivo;
                    anuncio.status_anuncio = Anuncio.TypeStatusAnuncio.Bloqueado;

                    this.Update(anuncio);
                }
                else
                {
                    throw new Exception(MessagesPortal.PortalDataRecordNotFound);
                }
            }
            catch (Exception ex)
            {
                LogUtil.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

        public Anuncio Obter(int id_usuario, long id_anuncio)
        {
            try
            {
                return this.FindSingleBy(f => f.id_usuario == id_usuario &&  f.id_anuncio == id_anuncio);
            }
            catch (Exception ex)
            {
                LogUtil.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

        public Anuncio Obter(long id_anuncio)
        {
            try
            {
                return this.FindSingleBy(f => f.id_anuncio == id_anuncio);
            }
            catch (Exception ex)
            {
                LogUtil.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

        public Pagination<Anuncio> Listar(int id_usuario, Anuncio.TypeStatusAnuncio status, string ocorrencia, int? page, int? limit)
        {
            try
            {
                if (string.IsNullOrEmpty(ocorrencia))
                {
                    return this.FindAllBy(f => f.id_usuario == id_usuario && f.status_anuncio == status, o => o.d_jogo, SortOrder.Ascending, page, limit);
                }
                else
                {
                    return this.FindAllBy(f => f.id_usuario == id_usuario && f.status_anuncio == status &&
                                         (f.descricao_anuncio.Contains(ocorrencia)), o => o.d_jogo, SortOrder.Ascending, page, limit);
                }
            }
            catch (Exception ex)
            {
                LogUtil.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

        public void Publicar(int id_usuario, long id_anuncio)
        {
            try
            {
                var anuncio = this.Obter(id_usuario, id_anuncio);

                if (anuncio != null)
                {
                    anuncio.publicado_anuncio = true;
                    this.Update(anuncio);
                }
                else
                {
                    throw new Exception(MessagesPortal.PortalDataRecordNotFound);
                }
            }
            catch (Exception ex)
            {
                LogUtil.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

        public void AceitarProposta(long id_anuncio, int id_usuario, string informacao_entrega)
        {
            if (string.IsNullOrWhiteSpace(informacao_entrega))
                throw new PortalException(MessagesPortal.PortalAnuncioInformacaoInvalida);

            var anuncio = this.Obter(id_anuncio);

            anuncio.id_usuario_comprador = id_usuario;
            anuncio.status_anuncio = Anuncio.TypeStatusAnuncio.Reservado;
            anuncio.informacao_entrega_vendedor_anuncio = informacao_entrega;

            this.Update(anuncio);
        }

        public void ResponderProposta(long id_anuncio, string informacao_entrega)
        {
            if (string.IsNullOrWhiteSpace(informacao_entrega))
                throw new PortalException(MessagesPortal.PortalAnuncioInformacaoInvalida);

            var anuncio = this.Obter(id_anuncio);
      
            anuncio.informacao_entrega_comprador_anuncio = informacao_entrega;

            this.Update(anuncio);
        }

        public Pagination<Anuncio> ListarCompras(int id_usuario, Anuncio.TypeStatusAnuncio status, string ocorrencia, int? page, int? limit)
        {
            try
            {
                if (string.IsNullOrEmpty(ocorrencia))
                {
                    return this.FindAllBy(f => f.id_usuario_comprador == id_usuario && f.status_anuncio == status, o => o.d_jogo, SortOrder.Descending, page, limit);
                }
                else
                {
                    return this.FindAllBy(f => f.id_usuario_comprador == id_usuario && f.status_anuncio == status &&
                                         (f.descricao_anuncio.Contains(ocorrencia)), o => o.d_jogo, SortOrder.Descending, page, limit);
                }
            }
            catch (Exception ex)
            {
                LogUtil.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }
    }
}