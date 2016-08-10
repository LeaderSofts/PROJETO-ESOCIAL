using Portal.Business.Helpers;
using Portal.Business.Models;
using Portal.Business.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Portal.Business.Repositories
{
    public partial class AnuncioComentarioVisualizacaoRepository : EFRepository<AnuncioComentarioVisualizacao>
    {
        public AnuncioComentarioVisualizacaoRepository() : base("dbEF") { }

        public void Salvar(AnuncioComentarioVisualizacao entity)
        {
            try
            {
                var anuncio = EFUnitOfWork.GetRepository<AnuncioRepository>().Obter(entity.id_anuncio);

                if(anuncio!= null)
                {
                    entity.dh_msg_visualizada = DateTime.Now;
                    entity.id_usuario_vendedor = anuncio.id_usuario;

                    if (anuncio.id_usuario == entity.id_usuario)
                    {
                        entity.id_usuario_vendedor = anuncio.id_usuario;
                        entity.msg_usuario_visualizada = true;
                        entity.dh_msg_usuario_visualizada = DateTime.Now;
                    }
                   
                    if (!this.IsValidEntity(entity))
                        throw new PortalException(string.Format("{0}{1}{2}", MessagesPortal.PortalDataValidation, Environment.NewLine, string.Join(Environment.NewLine, this.GetErrorsEntity())));
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

        public void Marcar(long id_anuncio, int id_usuario_vendedor)
        {
            try
            {
                string sql = string.Format("UPDATE anuncio_comentario_visualizacao SET dh_msg_usuario_visualizada='{0:yyyy-MM-dd HH:mm:ss}', msg_usuario_visualizada = 1 WHERE id_anuncio = {1} AND id_usuario_vendedor = {2}", DateTime.Now, id_anuncio, id_usuario_vendedor);

                this.Database.ExecuteSqlCommand(sql);
            }
            catch (Exception ex)
            {
                LogUtil.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

        public int Contar(long id_usuario_vendedor)
        {
            try
            {
                return this.FindAllBy(f => f.id_usuario_vendedor == id_usuario_vendedor && !f.msg_usuario_visualizada).Count();
            }
            catch (Exception ex)
            {
                LogUtil.Gravar(ex);
                throw new Exception(ex.Message);            
            }
        }
    
    }
}