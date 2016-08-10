using Portal.Business.Helpers;
using Portal.Business.Models;
using Portal.Business.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Portal.Business.Repositories
{
    public partial class AnuncioComentarioRepository : EFRepository<AnuncioComentario>
    {
        public AnuncioComentarioRepository() : base("dbEF") { }

        public void Salvar(AnuncioComentario entity)
        {
            try
            {
                entity.dh_cad_anuncio_comentario = DateTime.Now;

                if (!this.IsValidEntity(entity))
                    throw new PortalException(string.Format("{0}{1}{2}", MessagesPortal.PortalDataValidation, Environment.NewLine, string.Join(Environment.NewLine, this.GetErrorsEntity())));
                else
                    this.Save(entity);
            }
            catch (Exception ex)
            {
                LogUtil.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }

        public Pagination<AnuncioComentario> Listar(long id_anuncio, int? page, int? limit)
        {
            try
            {
                return this.FindAllBy(f => f.id_anuncio == id_anuncio, o => o.id_anuncio_comentario, SortOrder.Descending, page, limit);
            }
            catch (Exception ex)
            {
                LogUtil.Gravar(ex);
                throw new Exception(ex.Message);
            }
        }
    }
}